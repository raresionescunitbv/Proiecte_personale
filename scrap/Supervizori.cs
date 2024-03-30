using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp3
{
    public partial class Supervizori : Form
    {
        public SqlConnection conn;
        private string strMyOriginalText;

        public Supervizori()
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
            this.FormClosing += Supervizori_FormClosing;

        }
        private void Supervizori_FormClosing(Object sender, FormClosingEventArgs e)
        {



            Application.ExitThread();
            Environment.Exit(0);
        }


        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(conn.ConnectionString)) ;
            {
                conn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Supervizori", conn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                conn.Close();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            {
                conn.Open();
                string linia = textBox2.Text;
                string schimb = textBox3.Text;
                string sefSchimb = textBox4.Text;
                string sefEchipa = textBox5.Text;
                string inspCalitate = textBox6.Text;
                string respLogistica = textBox7.Text;
                string status = textBox9.Text;
                string NrCrt = textBox1.Text;

                SqlCommand updateCmd = new SqlCommand("UPDATE Supervizori SET linia = @linia, schimb = @schimb, sefSchimb = @sefSchimb, sefEchipa = @sefEchipa, inspCalitate = @inspCalitate, respLogistica = @respLogistica, status = @status WHERE NrCrt = @NrCrt", conn);

                updateCmd.Parameters.AddWithValue("@linia", linia);
                updateCmd.Parameters.AddWithValue("@schimb", schimb);
                updateCmd.Parameters.AddWithValue("@sefSchimb", sefSchimb);
                updateCmd.Parameters.AddWithValue("@sefEchipa", sefEchipa);
                updateCmd.Parameters.AddWithValue("@inspCalitate", inspCalitate);
                updateCmd.Parameters.AddWithValue("@respLogistica", respLogistica);
                updateCmd.Parameters.AddWithValue("@status", status);
                updateCmd.Parameters.AddWithValue("@NrCrt", NrCrt);



                try
                {
                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        if (status != "0" && status != "1")
                        {
                            MessageBox.Show("Status trebuie să fie 0 sau 1.");
                            return;

                        }
                        {
                            MessageBox.Show("Modificare reușită!");
                            conn.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Selectati un rand din baza de date.");
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare");
                }
                finally
                {
                    conn.Close();
                }
            }


            using (SqlConnection sqlConnection = new SqlConnection(conn.ConnectionString))
            {
                conn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT TOP 50 * FROM Supervizori", conn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
            conn.Close();

            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }
        private void Supervizori_Load(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(conn.ConnectionString)) ;
            {
                conn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT TOP 50 * FROM Supervizori", conn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                conn.Close();

            }
            dataGridView1.CellClick += dataGridView1_CellClick;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                textBox2.Text = selectedRow.Cells["linia"].Value.ToString();
                textBox3.Text = selectedRow.Cells["schimb"].Value.ToString();
                textBox4.Text = selectedRow.Cells["sefSchimb"].Value.ToString();
                textBox5.Text = selectedRow.Cells["sefEchipa"].Value.ToString();
                textBox6.Text = selectedRow.Cells["inspCalitate"].Value.ToString();
                textBox7.Text = selectedRow.Cells["respLogistica"].Value.ToString();
                textBox9.Text = selectedRow.Cells["status"].Value.ToString();
                textBox1.Text = selectedRow.Cells["NrCrt"].Value.ToString();
            }
        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            string valueToSearch = textBox8.Text.ToString();
            search(valueToSearch);
        }
        public void Close()
        {
            Application.Exit();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string valueToSearch = textBox8.Text.ToString();
            search(valueToSearch);
        }
        public void search(string valueToSearch)
        {
            string query = "SELECT * FROM Supervizori WHERE NrCrt LIKE @search OR linia LIKE @search OR schimb LIKE @search OR sefSchimb LIKE @search OR sefEchipa LIKE @search OR inspCalitate LIKE @search OR respLogistica LIKE @search ";

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            string linia = textBox2.Text;
            string schimb = textBox3.Text;
            string sefSchimb = textBox4.Text;
            string sefEchipa = textBox5.Text;
            string InspCalitate = textBox6.Text;
            string respLogistica = textBox7.Text;
            string status = textBox9.Text;
            if (string.IsNullOrWhiteSpace(linia) || string.IsNullOrWhiteSpace(schimb) || string.IsNullOrWhiteSpace(sefSchimb) || string.IsNullOrWhiteSpace(sefEchipa) || string.IsNullOrWhiteSpace(InspCalitate) || string.IsNullOrWhiteSpace(respLogistica) || string.IsNullOrWhiteSpace(status))
            {
                MessageBox.Show("Completați toate câmpurile!");
                return;
            }
            conn.Open();
            try
            {
                string enableIdentityInsert = "SET IDENTITY_INSERT Supervizori ON";
                using (SqlCommand enableCmd = new SqlCommand(enableIdentityInsert, conn))
                {
                    enableCmd.ExecuteNonQuery();
                }
                string insertQuery = "INSERT INTO Supervizori (NrCrt, linia, schimb,sefSchimb,sefEchipa,inspCalitate,respLogistica,status) VALUES (@NrCrt, @linia, @schimb,@sefSchimb,@sefEchipa,@inspCalitate,@respLogistica,@status)";
                using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                {
                    int nextNrCrt = 1;
                    using (SqlCommand maxCmd = new SqlCommand("SELECT MAX(NrCrt) FROM Supervizori", conn))
                    {
                        object result = maxCmd.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            nextNrCrt = Convert.ToInt32(result) + 1;
                        }
                    }
                    insertCmd.Parameters.AddWithValue("@NrCrt", nextNrCrt);
                    insertCmd.Parameters.AddWithValue("@linia", linia);
                    insertCmd.Parameters.AddWithValue("@schimb", schimb);
                    insertCmd.Parameters.AddWithValue("@sefSchimb", sefSchimb);
                    insertCmd.Parameters.AddWithValue("@sefEchipa", sefEchipa);
                    insertCmd.Parameters.AddWithValue("@inspCalitate", InspCalitate);
                    insertCmd.Parameters.AddWithValue("@respLogistica", respLogistica);
                    insertCmd.Parameters.AddWithValue("@status", status);
                    if (status != "0" && status != "1")
                    {
                        MessageBox.Show("Status trebuie să fie 0 sau 1.");
                        return;
                    }
                    int rowsAffected = insertCmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Adăugare reușită!");
                    }
                    else
                    {
                        MessageBox.Show("Adaugare eșuată.");
                    }
                }

                string disableIdentityInsert = "SET IDENTITY_INSERT Supervizori OFF";
                using (SqlCommand disableCmd = new SqlCommand(disableIdentityInsert, conn))
                {
                    disableCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Supervizorul exista deja");
            }
            finally
            {

                conn.Close();
            }
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }
    }
}


