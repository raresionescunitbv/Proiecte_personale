using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace WinFormsApp3
{
    public partial class formular1 : Form
    {
        public SqlConnection conn;
        private string strMyOriginalText;
        public formular1()
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
        private void label4_Click(object sender, EventArgs e)
        {
        }
        private void Formular_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conn.ConnectionString)) ;
            {
                conn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT TOP 50 * FROM Formular", conn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                conn.Close();

            }
            dataGridView1.CellClick += dataGridView1_CellClick;
        }
        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
            Environment.Exit(0);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string valueToSearch = textBox4.Text.ToString();
            search(valueToSearch);
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }
        public void search2(string valueToSearch)
        {
            string query = "SELECT * FROM Formular WHERE CONVERT(varchar, dataTimp, 101) LIKE @search";
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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            conn.Open();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                textBox2.Text = selectedRow.Cells["NrCrt"].Value.ToString();
                textBox3.Text = selectedRow.Cells["linia"].Value.ToString();
                textBox4.Text = selectedRow.Cells["dataTimp"].Value.ToString();
                textBox5.Text = selectedRow.Cells["schimb"].Value.ToString();
                textBox6.Text = selectedRow.Cells["sefSchimb"].Value.ToString();
                textBox7.Text = selectedRow.Cells["sefEchipa"].Value.ToString();
                textBox8.Text = selectedRow.Cells["inspCalitate"].Value.ToString();
                textBox9.Text = selectedRow.Cells["respLogistica"].Value.ToString();
                textBox10.Text = selectedRow.Cells["denumireReper"].Value.ToString();
                textBox11.Text = selectedRow.Cells["bucati"].Value.ToString();
                textBox12.Text = selectedRow.Cells["defect"].Value.ToString();
                textBox14.Text = selectedRow.Cells["RI"].Value.ToString();
                textBox15.Text = selectedRow.Cells["RF"].Value.ToString();
                textBox1.Text = selectedRow.Cells["RL"].Value.ToString();
                textBox13.Text = selectedRow.Cells["codReper"].Value.ToString();
                textBox19.Text = selectedRow.Cells["Status"].Value.ToString();
                textBox20.Text = selectedRow.Cells["Observatie"].Value.ToString();
                textBox21.Text = selectedRow.Cells["Fabrica"].Value.ToString();



                conn.Close();

            }
            conn.Close();
        }
        private void label16_Click(object sender, EventArgs e)
        {
        }
        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            {
                string linia = textBox3.Text;
                string dataTimp = textBox4.Text;
                string schimb = textBox5.Text;
                string sefSchimb = textBox6.Text;
                string sefEchipa = textBox7.Text;
                string inspCalitate = textBox8.Text;
                string respLogistica = textBox9.Text;
                string denumireReper = textBox10.Text;
                string bucati = textBox11.Text;
                string defect = textBox12.Text;
                string RI = textBox14.Text;
                string RF = textBox15.Text;
                string RL = textBox1.Text;
                string codReper = textBox13.Text;
                string Status = textBox19.Text;
                string Observatie = textBox20.Text;
                string NrCrt = textBox2.Text;
                string Fabrica = textBox21.Text;
                if (Status != "0" && Status != "1")
                {
                    MessageBox.Show("Status trebuie să fie 0 sau 1.");
                    return;
                }
                conn.Open();
                SqlCommand updateCmd = new SqlCommand("UPDATE Formular SET linia = @linia, dataTimp = @dataTimp, schimb = @schimb, sefSchimb = @sefSchimb, sefEchipa = @sefEchipa, inspCalitate = @inspCalitate, respLogistica = @respLogistica, codReper = @codReper, denumireReper = @denumireReper, bucati = @bucati, defect = @defect, RI = @RI, RF = @RF, RL = @RL, Status = @Status, Observatie = @Observatie, Fabrica=@Fabrica WHERE NrCrt = @NrCrt", conn);
                updateCmd.Parameters.AddWithValue("@linia", linia);
                updateCmd.Parameters.AddWithValue("@dataTimp", dataTimp);
                updateCmd.Parameters.AddWithValue("@schimb", schimb);
                updateCmd.Parameters.AddWithValue("@sefSchimb", sefSchimb);
                updateCmd.Parameters.AddWithValue("@sefEchipa", sefEchipa);
                updateCmd.Parameters.AddWithValue("@inspCalitate", inspCalitate);
                updateCmd.Parameters.AddWithValue("@respLogistica", respLogistica);
                updateCmd.Parameters.AddWithValue("@codReper", codReper);
                updateCmd.Parameters.AddWithValue("@denumireReper", denumireReper);
                updateCmd.Parameters.AddWithValue("@defect", defect);
                updateCmd.Parameters.AddWithValue("@bucati", bucati);
                updateCmd.Parameters.AddWithValue("@RI", RI);
                updateCmd.Parameters.AddWithValue("@RF", RF);
                updateCmd.Parameters.AddWithValue("@RL", RL);
                updateCmd.Parameters.AddWithValue("@Status", Status);
                updateCmd.Parameters.AddWithValue("@Observatie", Observatie);
                updateCmd.Parameters.AddWithValue("@NrCrt", NrCrt);
                updateCmd.Parameters.AddWithValue("@Fabrica", Fabrica);
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
                using (SqlConnection sqlCon = new SqlConnection(conn.ConnectionString))
                {
                    SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT TOP 50 * FROM Formular", conn);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;
                    conn.Close();
                }
            }
            textBox17.Clear();
            textBox16.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox1.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            textBox17.Clear();
            textBox19.Clear();
            textBox20.Clear();
            textBox21.Clear();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }
        public void search(string valueToSearch)
        {
            conn.Open();
            string query = "SELECT * FROM Formular WHERE NrCrt LIKE @search OR linia LIKE @search OR dataTimp LIKE @search OR schimb LIKE @search OR sefSchimb LIKE @search OR sefEchipa LIKE @search OR inspCalitate LIKE @search OR respLogistica LIKE @search OR codReper LIKE @search OR denumireReper LIKE @search OR bucati LIKE @search OR defect LIKE @search OR RI LIKE @search OR RF LIKE @search OR RL LIKE @search  OR Fabrica LIKE @search";
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
        }
        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            string valueToSearch = textBox16.Text.ToString();
            search(valueToSearch);
        }
        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            string valueToSearch = textBox17.Text.ToString();
            search12(valueToSearch);
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;

            if (startDate.Date == endDate.Date)
            {
                string valueToSearch = textBox17.Text.Trim();
                search13(valueToSearch, startDate, endDate);
            }
            else
            {
                string valueToSearch = textBox17.Text.Trim();
                search13(valueToSearch, startDate, endDate);
            }
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;

            if (startDate.Date == endDate.Date)
            {
                string valueToSearch = textBox17.Text.Trim();
                search13(valueToSearch, startDate, endDate);
            }
            else
            {
                string valueToSearch = textBox17.Text.Trim();
                search13(valueToSearch, startDate, endDate);
            }
        }

        public void search13(string valueToSearch, DateTime startDate, DateTime endDate)
        {
            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            {
                string query = "SELECT * FROM Formular WHERE (NrCrt LIKE @search OR linia LIKE @search OR dataTimp LIKE @search OR schimb LIKE @search OR sefschimb LIKE @search OR sefechipa LIKE @search OR inspCalitate LIKE @search OR respLogistica LIKE @search OR codReper LIKE @search OR denumireReper LIKE @search OR bucati LIKE @search OR defect LIKE @search OR RI LIKE @search OR RF LIKE @search OR RL LIKE @search  OR Fabrica LIKE @search) " +
                   "AND dataTimp BETWEEN @startDate AND @endDate";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@search", "%" + valueToSearch + "%");
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable datatable = new DataTable();
                sqlDataAdapter.Fill(datatable);
                dataGridView1.DataSource = datatable;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            conn.Open();
            if (int.TryParse(textBox18.Text, out int numRowsToShow))
            {
                using (SqlConnection con = new SqlConnection(conn.ConnectionString))
                {
                    string query = $"SELECT TOP {numRowsToShow} * FROM Formular";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    DataTable datatable = new DataTable();
                    sqlDataAdapter.Fill(datatable);
                    dataGridView1.DataSource = datatable;
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("Introduceți un număr valid.");
            }
        }
        private void searchWithinDateRange(DateTime startDate, DateTime endDate)
        {
            conn.Open();
            string query = "SELECT * FROM Formular WHERE dataTimp BETWEEN @startDate AND @endDate";
            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable datatable = new DataTable();
                sqlDataAdapter.Fill(datatable);
                dataGridView1.DataSource = datatable;
            }

            conn.Close();
        }
        private void search1(string valueToSearch, DateTime startDate, DateTime endDate)
        {
            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            {
                string query = "SELECT * FROM Formular WHERE (NrCrt LIKE @search OR linia LIKE @search OR dataTimp LIKE @search OR schimb LIKE @search OR sefschimb LIKE @search OR sefechipa LIKE @search OR inspCalitate LIKE @search OR respLogistica LIKE @search OR codReper LIKE @search OR denumireReper LIKE @search OR bucati LIKE @search OR defect LIKE @search OR RI LIKE @search OR RF LIKE @search OR RL LIKE @search) " +
               "AND dataTimp BETWEEN @startDate AND  @endDate";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@search", "%" + valueToSearch + "%");
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable datatable = new DataTable();
                sqlDataAdapter.Fill(datatable);
                dataGridView1.DataSource = datatable;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void button5_Click(object sender, EventArgs e)
        {
            dateTimePicker2.ResetText();
            dateTimePicker1.ResetText();
            using (SqlConnection sqlCon = new SqlConnection(conn.ConnectionString)) ;
            {
                conn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT TOP 50 * FROM Formular", conn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                conn.Close();
            }
            textBox17.Clear();
            textBox16.Clear();
            textBox3.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox1.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            textBox17.Clear();
            textBox19.Clear();
            textBox20.Clear();
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        public void search12(string valueToSearch)
        {
            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;
            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            {
                string query = "SELECT * FROM Formular WHERE (NrCrt LIKE @search OR linia LIKE @search OR dataTimp LIKE @search OR schimb LIKE @search OR sefschimb LIKE @search OR sefechipa LIKE @search OR inspCalitate LIKE @search OR respLogistica LIKE @search OR codReper LIKE @search OR denumireReper LIKE @search OR bucati LIKE @search OR defect LIKE @search OR RI LIKE @search OR RF LIKE @search OR RL LIKE @search OR Fabrica LIKE @search) " +
                   "AND dataTimp BETWEEN @startDate AND @endDate";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@search", "%" + valueToSearch + "%");
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable datatable = new DataTable();
                sqlDataAdapter.Fill(datatable);
                dataGridView1.DataSource = datatable;
            }
        }
        private void textBox17_TextChanged_1(object sender, EventArgs e)
        {
            string valueToSearch = textBox17.Text.ToString();
            search12(valueToSearch);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            conn.Open();
            string fabrica = "@Fabrica";
            string query = "SELECT * FROM Formular WHERE Fabrica = 'CER1'";

            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Fabrica", fabrica);


                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable datatable = new DataTable();
                sqlDataAdapter.Fill(datatable);
                dataGridView1.DataSource = datatable;
            }

            conn.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            conn.Open();
            string fabrica = "@Fabrica";
            string query = "SELECT * FROM Formular WHERE Fabrica = 'CER2'";

            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Fabrica", fabrica);


                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable datatable = new DataTable();
                sqlDataAdapter.Fill(datatable);
                dataGridView1.DataSource = datatable;
            }

            conn.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
                xlapp.Visible = true;
                Microsoft.Office.Interop.Excel.Workbook xlWbook;
                Microsoft.Office.Interop.Excel.Worksheet xlsheet;
                object missingData = System.Reflection.Missing.Value;
                xlWbook = xlapp.Workbooks.Add(missingData);
                xlsheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWbook.Worksheets.get_Item(1);

                for (int i = 1; i <= dataGridView1.Columns.Count; i++)
                {
                    xlsheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }

                int rowOffset = 2;

                foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
                {
                    for (int col = 0; col < dataGridView1.Columns.Count; col++)
                    {
                        if (selectedRow.Cells[col].Value != null)
                        {
                            xlsheet.Cells[rowOffset, col + 1] = selectedRow.Cells[col].Value.ToString();
                        }
                    }
                    rowOffset++;
                }
            }
            else
            {
          
                Microsoft.Office.Interop.Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
                xlapp.Visible = true;
                Microsoft.Office.Interop.Excel.Workbook xlWbook;
                Microsoft.Office.Interop.Excel.Worksheet xlsheet;
                object missingData = System.Reflection.Missing.Value;
                xlWbook = xlapp.Workbooks.Add(missingData);
                xlsheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWbook.Worksheets.get_Item(1);

                for (int i = 1; i <= dataGridView1.Columns.Count; i++)
                {
                    xlsheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }

                int rowOffset = 2; 

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    for (int col = 0; col < dataGridView1.Columns.Count; col++)
                    {
                        if (row.Cells[col].Value != null)
                        {
                            xlsheet.Cells[rowOffset, col + 1] = row.Cells[col].Value.ToString();
                        }
                    }
                    rowOffset++;
                }
            }



        }
    }

}

