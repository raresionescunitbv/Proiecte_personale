using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WinFormsApp3
{
    public partial class DenumireDefect : Form
    {
        public SqlConnection conn;
        public DenumireDefect()
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



        private void button2_Click(object sender, EventArgs e)
        {

            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            {
                string Defect = textBox2.Text;
                string StatusDesign = textBox5.Text;
                string NrCrt = textBox1.Text;


                if (StatusDesign != "0" && StatusDesign != "1")
                {
                    MessageBox.Show("Status trebuie să fie 0 sau 1.");
                    return;
                }

                conn.Open();

                try
                {
                    SqlCommand updateCmd = new SqlCommand("UPDATE Defect SET Defect = @Defect, StatusDesign = @StatusDesign WHERE NrCrt = @NrCrt", conn);

                    updateCmd.Parameters.AddWithValue("@Defect", Defect);
                    updateCmd.Parameters.AddWithValue("@StatusDesign", StatusDesign);
                    updateCmd.Parameters.AddWithValue("@NrCrt", NrCrt);

                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Modificare reușită!");
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox5.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Selectati un rand din baza de date.");
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
                using (SqlConnection coan = new SqlConnection(conn.ConnectionString))
                {
                    SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT TOP 50 * FROM Defect", conn);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;
                }
            }



        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(conn.ConnectionString)) ;
            {
                conn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Defect", conn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                conn.Close();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }
        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {


            Application.ExitThread();
            Environment.Exit(0);
        }
        private void DenumireDefect_Load(object sender, EventArgs e)
        {
            dataGridView1.CellClick += dataGridView1_CellClick;
            using (SqlConnection sqlCon = new SqlConnection(conn.ConnectionString)) ;
            {
                conn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT TOP 50 * FROM Defect", conn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                conn.Close();

            }
        }
        public void search(string valueToSearch)
        {


            string query = "SELECT TOP 50 * FROM Defect WHERE NrCrt LIKE @search OR Defect LIKE @search ";


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
            conn.Close();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                textBox2.Text = selectedRow.Cells["Defect"].Value.ToString();
                textBox5.Text = selectedRow.Cells["StatusDesign"].Value.ToString();

                textBox1.Text = selectedRow.Cells["NrCrt"].Value.ToString();

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string valueToSearch = textBox3.Text.ToString();
            search(valueToSearch);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string valueToSearch = textBox3.Text.ToString();
            search(valueToSearch);
        }

        private void button5_Click(object sender, EventArgs e)
        {



        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string Defect = textBox2.Text;
            string StatusDesign = textBox5.Text;



            if (string.IsNullOrWhiteSpace(Defect) || string.IsNullOrWhiteSpace(StatusDesign))
            {

                MessageBox.Show("Completați toate câmpurile!");
                return;
            }


            conn.Open();

            try
            {
                string enableIdentityInsert = "SET IDENTITY_INSERT Defect ON";
                using (SqlCommand enableCmd = new SqlCommand(enableIdentityInsert, conn))
                {
                    enableCmd.ExecuteNonQuery();
                }
                string insertQuery = "INSERT INTO Defect (NrCrt, Defect, StatusDesign) VALUES (@NrCrt, @Defect, @StatusDesign)";
                using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                {
                    int nextNrCrt = 1;
                    using (SqlCommand maxCmd = new SqlCommand("SELECT MAX(NrCrt) FROM Defect", conn))
                    {
                        object result = maxCmd.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            nextNrCrt = Convert.ToInt32(result) + 1;
                        }
                    }
                    insertCmd.Parameters.AddWithValue("@NrCrt", nextNrCrt);
                    insertCmd.Parameters.AddWithValue("@Defect", Defect);
                    insertCmd.Parameters.AddWithValue("@StatusDesign", StatusDesign);

                    if (StatusDesign != "0" && StatusDesign != "1")
                    {
                        MessageBox.Show("Status trebuie să fie 0 sau 1.");
                        return;
                    }

                    int rowsAffected = insertCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Adăugare reușită!");
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox5.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Adaugare eșuată.");
                    }
                }

                string disableIdentityInsert = "SET IDENTITY_INSERT Defect OFF";
                using (SqlCommand disableCmd = new SqlCommand(disableIdentityInsert, conn))
                {
                    disableCmd.ExecuteNonQuery();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Defectul exista deja");
            }
            finally
            {

                conn.Close();
            }
            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            {
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT TOP 50 * FROM Defect", conn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }
    }
}



