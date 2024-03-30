using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
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
    public partial class CodReper : Form
    {
        public SqlConnection conn;




        public CodReper()
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
        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {


            Application.ExitThread();
            Environment.Exit(0);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(conn.ConnectionString))
            {
                conn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT TOP 50 * FROM codReper", conn);
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

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            {
                string codReper = textBox1.Text;
                string denumireReper = textBox2.Text;
                string StatusReper = textBox6.Text;
                string NrCrt = textBox3.Text;



                if (StatusReper != "0" && StatusReper != "1")
                {
                    MessageBox.Show("Status trebuie să fie 0 sau 1.");
                    return;
                }

                conn.Open();

                try
                {
                    SqlCommand updateCmd = new SqlCommand("UPDATE codReper SET codReper = @codReper, denumireReper = @denumireReper, StatusReper = @StatusReper WHERE NrCrt = @NrCrt", conn);
                    updateCmd.Parameters.AddWithValue("@codReper", codReper);
                    updateCmd.Parameters.AddWithValue("@denumireReper", denumireReper);
                    updateCmd.Parameters.AddWithValue("@NrCrt", NrCrt);
                    updateCmd.Parameters.AddWithValue("@StatusReper", StatusReper);


                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Modificare reușită!");
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox6.Clear();
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
                    SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT TOP 50 * FROM codReper", conn);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;
                }
            }




        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                textBox1.Text = selectedRow.Cells["codReper"].Value.ToString();
                textBox3.Text = selectedRow.Cells["NrCrt"].Value.ToString();
                textBox2.Text = selectedRow.Cells["denumireReper"].Value.ToString();

                textBox6.Text = selectedRow.Cells["StatusReper"].Value.ToString();

            }
        }
        public void search1(string valueToSearch)
        {

            string query = "SELECT * FROM Formular WHERE NrCrt LIKE @search OR linia LIKE @search OR dataTimp LIKE @search OR schimb LIKE @search OR sefSchimb LIKE @search OR sefEchipa LIKE @search OR inspCalitate LIKE @search OR respLogistica LIKE @search OR codReper LIKE @search OR denumireReper LIKE @search OR bucati LIKE @search OR defect LIKE @search OR RI LIKE @search OR RF LIKE @search OR RL LIKE @search";


            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@search", "%" + valueToSearch + "%");

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable datatable = new DataTable();
                sqlDataAdapter.Fill(datatable);
                dataGridView1.DataSource = datatable;
            }
        }

        private void CodReper_Load(object sender, EventArgs e)
        {
            dataGridView1.CellClick += dataGridView1_CellClick;
            using (SqlConnection sqlCon = new SqlConnection(conn.ConnectionString))
            {
                conn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT TOP 50 * FROM codReper", conn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                conn.Close();

            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            string valueToSearch = textBox4.Text.ToString();
            search1(valueToSearch);
            string tx4 = textBox4.Text;
            if (!string.IsNullOrEmpty(tx4))
            {
                int selectedCriteriu;
                if (int.TryParse(tx4, out selectedCriteriu))
                {
                    using (SqlConnection con = new SqlConnection(conn.ConnectionString))
                    {
                        conn.Open();
                        SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM codReper WHERE codReper = @codReper", con);

                        sqlDa.SelectCommand.Parameters.AddWithValue("@codReper", selectedCriteriu);



                        DataTable dtbl = new DataTable();
                        sqlDa.Fill(dtbl);
                        dataGridView1.DataSource = dtbl;


                    }
                }
                else
                {
                    MessageBox.Show("Numar invalid.");
                }
            }
            else
            {
                MessageBox.Show("Eroare.");
            }
            string valueToSearch1 = textBox4.Text.ToString();
            search1(valueToSearch1);
            conn.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

            string valueToSearch = textBox4.Text.ToString();
            search(valueToSearch);
        }
        public void search(string valueToSearch)
        {

            string query = "SELECT TOP 50 * FROM codReper WHERE NrCrt LIKE @search OR codReper LIKE @search OR denumireReper LIKE @search";

            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            {


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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Adauga_Click(object sender, EventArgs e)
        {
            string codReper = textBox1.Text;
            string denumireReper = textBox2.Text;
            string StatusReper = textBox6.Text;


            if (string.IsNullOrWhiteSpace(codReper) || string.IsNullOrWhiteSpace(denumireReper) || string.IsNullOrWhiteSpace(StatusReper))
            {
                MessageBox.Show("Completați toate câmpurile!");
                return;
            }


            conn.Open();

            try
            {
                string enableIdentityInsert = "SET IDENTITY_INSERT codReper ON";
                using (SqlCommand enableCmd = new SqlCommand(enableIdentityInsert, conn))
                {
                    enableCmd.ExecuteNonQuery();
                }

                string insertQuery = "INSERT INTO codReper (NrCrt, codReper, denumireReper, StatusReper) VALUES (@NrCrt, @codReper, @denumireReper, @StatusReper)";
                using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                {
                    int nextNrCrt = 1;
                    using (SqlCommand maxCmd = new SqlCommand("SELECT MAX(NrCrt) FROM codReper", conn))
                    {
                        object result = maxCmd.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            nextNrCrt = Convert.ToInt32(result) + 1;
                        }
                    }
                    insertCmd.Parameters.AddWithValue("@NrCrt", nextNrCrt);
                    insertCmd.Parameters.AddWithValue("@codReper", codReper);
                    insertCmd.Parameters.AddWithValue("@denumireReper", denumireReper);
                    insertCmd.Parameters.AddWithValue("@StatusReper", StatusReper);

                    if (StatusReper != "0" && StatusReper != "1")
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
                        textBox6.Clear();

                    }
                    else
                    {
                        MessageBox.Show("Adaugare eșuată.");
                    }
                }

                string disableIdentityInsert = "SET IDENTITY_INSERT codReper OFF";
                using (SqlCommand disableCmd = new SqlCommand(disableIdentityInsert, conn))
                {
                    disableCmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Reperul exista deja");
            }
            finally
            {
                conn.Close();

            }
            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            {
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT TOP 50 * FROM codReper", conn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }

        }
    }
}


