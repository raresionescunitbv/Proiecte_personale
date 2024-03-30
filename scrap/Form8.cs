using System;
using System.Collections;
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

namespace WinFormsApp3
{
    public partial class Form8 : Form
    {
        public SqlConnection conn;
        private string strMyOriginalText;

        public Form8()
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

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];


                textBox3.Text = selectedRow.Cells["numeLinie"].Value.ToString();
                textBox2.Text = selectedRow.Cells["NrCrt"].Value.ToString();
                textBox5.Text = selectedRow.Cells["StatusLinii"].Value.ToString();


            }
        }
        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {


            Application.ExitThread();
            Environment.Exit(0);
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            dataGridView1.CellClick += dataGridView1_CellClick;
            using (SqlConnection sqlCon = new SqlConnection(conn.ConnectionString))
            {
                conn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT TOP 50 * FROM linii", conn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                conn.Close();

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string valueToSearch = textBox1.Text.ToString();
            search(valueToSearch);
        }
        public void search(string valueToSearch)
        {


            string query = "SELECT * FROM linii WHERE NrCrt LIKE @search OR numeLinie LIKE @search OR StatusLinii LIKE @search";

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

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            {

                string numeLinie = textBox3.Text;
                string Status = textBox5.Text;
                string NrCrt = textBox2.Text;
                if (Status != "0" && Status != "1")
                {
                    MessageBox.Show("Status trebuie să fie 0 sau 1.");
                    return;
                }

                conn.Open();

                SqlCommand updateCmd = new SqlCommand("UPDATE linii SET numeLinie = @numeLinie,StatusLinii=@StatusLinii WHERE NrCrt = @NrCrt ", conn);

                updateCmd.Parameters.AddWithValue("@numeLinie", numeLinie);
                updateCmd.Parameters.AddWithValue("@StatusLinii", Status);
                updateCmd.Parameters.AddWithValue("@NrCrt", NrCrt);

                try
                {

                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Modificare reușită!");
                    }
                    else
                    {
                        MessageBox.Show("Selectati un rand din baza de date.");
                        return;
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

                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT TOP 50 * FROM linii", conn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;


            }
            textBox3.Clear();
            textBox5.Clear();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void search2(string valueToSearch)
        {

            string query = "SELECT TOP 50 * FROM linii WHERE NrCrt LIKE @search OR numeLinie LIKE @search OR StatusLinii LIKE @search";

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


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string valueToSearch = textBox1.Text.ToString();
            search2(valueToSearch);

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string numeLinie = textBox3.Text;
            string StatusLinii = textBox5.Text;



            if (string.IsNullOrWhiteSpace(numeLinie) || string.IsNullOrWhiteSpace(StatusLinii))
            {
                MessageBox.Show("Completați toate câmpurile!");
                return;
            }


            conn.Open();

            try
            {
                string enableIdentityInsert = "SET IDENTITY_INSERT linii ON";
                using (SqlCommand enableCmd = new SqlCommand(enableIdentityInsert, conn))
                {
                    enableCmd.ExecuteNonQuery();
                }

                string insertQuery = "INSERT INTO linii (NrCrt, numeLinie, StatusLinii) VALUES (@NrCrt, @numeLinie, @StatusLinii)";
                using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                {
                    int nextNrCrt = 1;
                    using (SqlCommand maxCmd = new SqlCommand("SELECT MAX(NrCrt) FROM linii", conn))
                    {
                        object result = maxCmd.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            nextNrCrt = Convert.ToInt32(result) + 1;
                        }
                    }

                    insertCmd.Parameters.AddWithValue("@NrCrt", nextNrCrt);
                    insertCmd.Parameters.AddWithValue("@numeLinie", numeLinie);
                    insertCmd.Parameters.AddWithValue("@StatusLinii", StatusLinii);

                    if (StatusLinii != "0" && StatusLinii != "1")
                    {
                        MessageBox.Show("Status trebuie să fie 0 sau 1.");
                        return;
                    }

                    int rowsAffected = insertCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Adăugare reușită!");
                        textBox3.Clear();
                        textBox5.Clear();
                        textBox2.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Adaugare eșuată.");
                    }
                }

                string disableIdentityInsert = "SET IDENTITY_INSERT linii OFF";
                using (SqlCommand disableCmd = new SqlCommand(disableIdentityInsert, conn))
                {
                    disableCmd.ExecuteNonQuery();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Linia exista deja");
            }
            finally
            {

                conn.Close();
            }
        }
    }
}

