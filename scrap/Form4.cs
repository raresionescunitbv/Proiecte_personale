using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp3
{
    public partial class Form4 : Form
    {
        public SqlConnection conn;
        private string strMyOriginalText;

        public Form4()
        {
            InitializeComponent();
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load("conectare.xml");

                XmlNode serverNode = xmlDoc.SelectSingleNode("/DatabaseConfig/DataSource");
                XmlNode dbNameNode = xmlDoc.SelectSingleNode("/DatabaseConfig/database");
                XmlNode usernameNode = xmlDoc.SelectSingleNode("/DatabaseConfig/user");
                XmlNode passwordNode = xmlDoc.SelectSingleNode("/DatabaseConfig/password");


                if (serverNode != null && dbNameNode != null && usernameNode != null && passwordNode != null)
                {
                    string server = serverNode.InnerText;
                    string dbName = dbNameNode.InnerText;
                    string username = usernameNode.InnerText;
                    string password = passwordNode.InnerText;
                    string connectionString = $"Server={server};Database={dbName};User Id={username};Password={password};";
                    conn = new SqlConnection(connectionString);
                }
                else
                {
                    MessageBox.Show("Invalid XML content or structure.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading or parsing XML: " + ex.Message);
            }
            this.FormClosing += Form1_FormClosing;

        }





        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e, bool sters)
        {
            string Utilizator = textBox1.Text;
            string Parola = textBox2.Text;

            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            {
                conn.Open();


                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Utilizatori WHERE Utilizator  = @Utilizator", conn);
                checkCmd.Parameters.AddWithValue("@Utilizator", Utilizator);
                int userCount = (int)checkCmd.ExecuteScalar();

                if (userCount > 0)
                {
                    MessageBox.Show("Utilizatorul " + Utilizator + " deja există.");
                }
                else
                {
                    string username = textBox1.Text;
                    string password = textBox2.Text;
                    bool activitate = checkBox1.Checked;
                    bool sters1 = checkBox2.Checked;



                    if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                    {
                        MessageBox.Show("Completati toate campurile!");
                        return;
                    }


                    try
                    {
                        conn.Open();
                        string query = "INSERT INTO Utilizatori (Utilizator, Parola, Activitate) VALUES (@Utilizator, @Parola, @Activitate)";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Utilizator", username);
                        cmd.Parameters.AddWithValue("@Parola", password);


                        if (checkBox1.Checked)
                        {

                            cmd.Parameters.AddWithValue("@Activitate", true);
                        }
                        else
                        {

                            cmd.Parameters.AddWithValue("@Activitate", false);
                        }

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Adăugare reușită!");
                        }
                        else
                        {
                            MessageBox.Show("Înregistrare eșuată. Verificați utilizatorul și parola.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Eroare: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ;


        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                textBox1.Text = selectedRow.Cells["Utilizator"].Value.ToString();
                textBox2.Text = selectedRow.Cells["Parola"].Value.ToString();


                object activitateValue = selectedRow.Cells["Activitate"].Value;
                checkBox1.Checked = activitateValue != DBNull.Value && Convert.ToBoolean(activitateValue);

                object stersValue = selectedRow.Cells["Sters"].Value;
                checkBox2.Checked = stersValue != DBNull.Value && Convert.ToBoolean(stersValue);
            }
        }
        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {


            Application.ExitThread();
            Environment.Exit(0);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            dataGridView1.CellClick += dataGridView1_CellClick;
            using (SqlConnection sqlCon = new SqlConnection(conn.ConnectionString)) ;
            {
                conn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT TOP 50 * FROM Utilizatori", conn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                conn.Close();

            }
            conn.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(conn.ConnectionString)) ;
            {
                conn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM UTILIZATORI", conn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;

                conn.Close();
            }
            conn.Close();
            conn.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)

        {

            string Utilizator = textBox1.Text;
            string Parola = textBox2.Text;


            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            {
                conn.Open();
                if (string.IsNullOrWhiteSpace(Utilizator) || string.IsNullOrWhiteSpace(Parola))
                {
                    MessageBox.Show("Completați toate câmpurile!");
                    return;
                }

                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM UTILIZATORI WHERE Utilizator = @Utilizator", conn);
                checkCmd.Parameters.AddWithValue("@Utilizator", Utilizator);

                int userCount = (int)checkCmd.ExecuteScalar();



                if (userCount == 0)
                {
                    MessageBox.Show("Utilizatorul " + Utilizator + " nu există.");
                    return;
                }

                string username = textBox1.Text;
                string password = textBox2.Text;

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Completati toate campurile!");
                    return;
                }

                try
                {
                    SqlCommand updateCmd = new SqlCommand("UPDATE UTILIZATORI SET Parola = @Parola, Activitate = @Activitate,Sters=@Sters WHERE Utilizator = @Utilizator", conn);
                    updateCmd.Parameters.AddWithValue("@Parola", password);

                    if (checkBox1.Checked)
                    {
                        updateCmd.Parameters.AddWithValue("@Activitate", true);
                    }
                    else
                    {
                        updateCmd.Parameters.AddWithValue("@Activitate", false);
                    }

                    if (checkBox2.Checked)
                    {
                        updateCmd.Parameters.AddWithValue("@Sters", true);

                    }
                    else
                    {
                        updateCmd.Parameters.AddWithValue("@Sters", false);
                    }

                    updateCmd.Parameters.AddWithValue("@Utilizator", Utilizator);

                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Modificare reușită!");
                        textBox1.Clear();
                        textBox2.Clear();
                        checkBox1.Checked = false;
                        checkBox2.Checked = false;

                    }
                    else
                    {
                        MessageBox.Show("Modificare eșuată. Verificați utilizatorul și parola.");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare: " + ex.Message);
                }
                finally
                {
                    conn.Close();

                }



            }

            using (SqlConnection sqlCon = new SqlConnection(conn.ConnectionString)) ;
            {
                conn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT TOP 50 * FROM Utilizatori", conn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                conn.Close();

            }
            conn.Close();




        }

        private void SetUserStatus(string utilizator, bool sters)
        {
            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            {
                conn.Open();

                try
                {
                    SqlCommand updateCmd = new SqlCommand("UPDATE UTILIZATORI SET Parola = @Parola, Activitate = @Activitate, Sters = @Sters WHERE Utilizator = @Utilizator", conn);
                    updateCmd.Parameters.AddWithValue("@Parola", textBox2.Text);

                    if (checkBox1.Checked)
                    {
                        updateCmd.Parameters.AddWithValue("@Activitate", false);
                    }
                    else
                    {
                        updateCmd.Parameters.AddWithValue("@Activitate", true);
                    }

                    updateCmd.Parameters.AddWithValue("@Sters", sters);
                    updateCmd.Parameters.AddWithValue("@Utilizator", utilizator);

                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show(sters ? "Utilizator sters și dezactivat." : "Utilizator reactivat.");
                    }
                    else
                    {
                        MessageBox.Show("Modificare eșuată. Verificați utilizatorul și parola.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare: " + ex.Message);
                }
                conn.Close();
            }
            conn.Close();
        }




        private void textBox3_TextChanged(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Utilizator = textBox1.Text;
            string Parola = textBox2.Text;
            bool activitate = checkBox1.Checked;
            bool sters = checkBox2.Checked;

            if (string.IsNullOrWhiteSpace(Utilizator) || string.IsNullOrWhiteSpace(Parola))
            {
                MessageBox.Show("Completați toate câmpurile!");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(conn.ConnectionString))
                {
                    conn.Open();

                    string selectQuery = "SELECT COUNT(*) FROM Utilizatori WHERE Utilizator = @Utilizator";
                    using (SqlCommand selectCmd = new SqlCommand(selectQuery, conn))
                    {
                        selectCmd.Parameters.AddWithValue("@Utilizator", Utilizator);
                        int existingUserCount = (int)selectCmd.ExecuteScalar();

                        if (existingUserCount > 0)
                        {
                            MessageBox.Show("Utilizatorul există deja în baza de date!");
                            textBox1.Clear();
                            textBox2.Clear();
                            checkBox1.Checked = false;
                            checkBox2.Checked = false;
                            conn.Close();
                            return;


                        }
                    }

                    string insertQuery = "INSERT INTO Utilizatori (Utilizator, Parola, Activitate, Sters) VALUES (@Utilizator, @Parola, @Activitate, @Sters)";
                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@Utilizator", Utilizator);
                        insertCmd.Parameters.AddWithValue("@Parola", Parola);
                        insertCmd.Parameters.AddWithValue("@Activitate", activitate);
                        insertCmd.Parameters.AddWithValue("@Sters", sters);

                        int rowsAffected = insertCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Adăugare reușită!");
                            textBox1.Clear();
                            textBox2.Clear();
                            checkBox1.Checked = false;
                            checkBox2.Checked = false;
                        }
                        else
                        {
                            MessageBox.Show("Înregistrare eșuată. Verificați utilizatorul și parola.");
                        }
                    }
                }

                using (SqlConnection con = new SqlConnection(conn.ConnectionString))
                {
                    SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT TOP 50 * FROM Utilizatori", conn);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Incercati din nou.");
            }
            conn.Close();

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            string valueToSearch = textBox3.Text.ToString();
            search(valueToSearch);
        }
        public void search(string valueToSearch)
        {


            string query = "SELECT * FROM Utilizatori WHERE Parola LIKE @search OR Utilizator LIKE @search";

            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@search", "%" + valueToSearch + "%");

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable datatable = new DataTable();
                sqlDataAdapter.Fill(datatable);
                dataGridView1.DataSource = datatable;
                conn.Close();
            }
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            string valueToSearch = textBox3.Text.ToString();
            search(valueToSearch);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}