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

namespace WinFormsApp3
{
    public partial class FormMoaraView : Form
    {
        public SqlConnection conn;
        public FormMoaraView()
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
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;
            if (startDate.Date == endDate.Date)
            {
                searchWithinDateRange(startDate, endDate);
            }
            else if (startDate.Date > endDate.Date)
            {
                MessageBox.Show("Data de inceput trebuie sa fie mai mica decat data de sfarsit");
                textBox4.Clear();
                using (SqlConnection sqlCon = new SqlConnection(conn.ConnectionString)) ;
                {
                    conn.Open();
                    SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT TOP 50 * FROM FormularMoara WHERE status = 1", conn);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;
                    conn.Close();
                }
            }
            else
            {
                string valueToSearch = textBox4.Text.Trim();
                search1(valueToSearch, startDate, endDate);
            }
        }
        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
            Environment.Exit(0);
        }
        private void FormMoaraView_Load(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(conn.ConnectionString)) ;
            {
                conn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM FormularMoara", conn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                conn.Close();
            }
        }
        public void search17(string valueToSearch)
        {
            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;
            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            {
                string query = "SELECT * FROM FormularMoara WHERE (NrCrt LIKE @search OR linia LIKE @search OR dataOra LIKE @search OR sefschimb LIKE @search OR sefechipa LIKE @search OR codReper LIKE @search OR denumireReper LIKE @search OR bucati LIKE @search OR defect LIKE @search OR intern LIKE @search OR furnizor LIKE @search OR status LIKE @search ) ";
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
        public void search12(string valueToSearch)
        {
            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;
            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            {
                string query = "SELECT * FROM FormularMoara WHERE (NrCrt LIKE @search OR linia LIKE @search OR schimbul LIKE @search OR dataOra LIKE @search OR sefschimb LIKE @search OR sefechipa LIKE @search OR codReper LIKE @search OR denumireReper LIKE @search OR bucati LIKE @search OR defect LIKE @search OR intern  LIKE @search OR furnizor LIKE @search OR status LIKE @search  OR Fabrica LIKE @search)" +
                "AND dataOra  BETWEEN @startDate AND @endDate";
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
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string valueToSearch = textBox4.Text.ToString();
            search12(valueToSearch);
        }
        public void search14(string valueToSearch)
        {
            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            {
                string query = "SELECT * FROM FormularMoara WHERE linia LIKE @search";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@search", "%" + valueToSearch + "%");

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable datatable = new DataTable();
                sqlDataAdapter.Fill(datatable);
                dataGridView1.DataSource = datatable;
            }
        }
        public void searchWithinDateRange1(string valueToSearch, DateTime startDate, DateTime endDate)
        {
            conn.Open();

            string query = "SELECT * FROM FormularMoara WHERE (NrCrt LIKE @search OR linia LIKE @search OR schimbul LIKE @search OR dataOra LIKE @search OR sefschimb LIKE @search OR sefechipa LIKE @search OR codReper LIKE @search OR denumireReper LIKE @search OR bucati LIKE @search OR defect LIKE @search OR intern  LIKE @search OR furnizor LIKE @search OR status LIKE @search)" +
                     "AND dataOra  BETWEEN @startDate AND @endDate";
            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@search", "%" + valueToSearch + "%");
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable datatable = new DataTable();
                sqlDataAdapter.Fill(datatable);
                dataGridView1.DataSource = datatable;
            }
            conn.Close();
        }

        public void search15(string valueToSearch)
        {
            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            {
                string query = "SELECT * FROM FormularMoara WHERE schimbul LIKE @search";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@search", "%" + valueToSearch + "%");
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable datatable = new DataTable();
                sqlDataAdapter.Fill(datatable);
                dataGridView1.DataSource = datatable;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string valueToSearch = textBox1.Text.ToString();
            search14(valueToSearch);
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string valueToSearch = textBox2.Text.ToString();
            search15(valueToSearch);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Alege alege = new Alege();
            alege.Show();
            this.Hide();
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
        public void search(string valueToSearch)
        {
            conn.Open();
            string query = "SELECT * FROM FormularMoara WHERE NrCrt LIKE @search OR linia LIKE @search OR schimbul LIKE @search OR dataOra LIKE @search OR sefschimb LIKE @search OR sefechipa LIKE @search OR codReper LIKE @search OR denumireReper LIKE @search OR bucati LIKE @search OR defect LIKE @search OR intern  LIKE @search OR furnizor LIKE @search OR status LIKE @search  OR Fabrica LIKE @search";
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
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string valueToSearch = textBox3.Text.ToString();
            search(valueToSearch);
        }
        private void SearchDateRange(string startDate, string endDate)
        {
            string query = "SELECT TOP 50 * FROM Formular WHERE CONVERT(varchar, dataTimp, 101) BETWEEN @startDate AND @endDate";
            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable datatable = new DataTable();
                sqlDataAdapter.Fill(datatable);
                dataGridView1.DataSource = datatable;
            }
        }
        private void Refresh_Click(object sender, EventArgs e)
        {
            dateTimePicker2.ResetText();
            dateTimePicker1.ResetText();
            using (SqlConnection sqlCon = new SqlConnection(conn.ConnectionString)) ;
            {
                conn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT TOP 50 * FROM FormularMoara WHERE status = 1", conn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                conn.Close();
            }
            textBox4.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            dateTimePicker2.ResetText();
            dateTimePicker1.ResetText();
            using (SqlConnection sqlCon = new SqlConnection(conn.ConnectionString)) ;
            {
                conn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT TOP 50 * FROM FormularMoara WHERE status = 1", conn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                conn.Close();
            }
        }
        private void search1(string valueToSearch, DateTime startDate, DateTime endDate)
        {
            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            {
                string query = "SELECT * FROM FormularMoara WHERE (NrCrt LIKE @search OR linia LIKE @search OR schimbul LIKE @search OR dataOra LIKE @search OR sefschimb LIKE @search OR sefechipa LIKE @search OR codReper LIKE @search OR denumireReper LIKE @search OR bucati LIKE @search OR defect LIKE @search OR intern  LIKE @search OR furnizor LIKE @search OR status LIKE @search  OR Fabrica LIKE @search)" +
  "AND dataOra BETWEEN @startDate AND @endDate";
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
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;
            if (startDate.Date == endDate.Date)
            {
                searchWithinDateRange(startDate, endDate);
            }
            else if (startDate.Date > endDate.Date)
            {
                MessageBox.Show("Data de inceput trebuie sa fie mai mica decat data de sfarsit");
                textBox4.Clear();
                using (SqlConnection sqlCon = new SqlConnection(conn.ConnectionString)) ;
                {
                    conn.Open();
                    SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT TOP 50 * FROM FormularMoara WHERE status = 1", conn);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;
                    conn.Close();
                }
            }
            else
            {
                string valueToSearch = textBox4.Text.Trim();
                search1(valueToSearch, startDate, endDate);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            conn.Open();
            string query = "SELECT * FROM FormularMoara WHERE Fabrica = 'CER1' ORDER BY dataOra desc";
            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable datatable = new DataTable();
                sqlDataAdapter.Fill(datatable);
                dataGridView1.DataSource = datatable;
            }
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            conn.Open();
            string query = "SELECT * FROM FormularMoara WHERE Fabrica = 'CER2' ORDER BY dataOra ASC";
            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable datatable = new DataTable();
                sqlDataAdapter.Fill(datatable);
                dataGridView1.DataSource = datatable;
            }
            conn.Close();
        }
        private void buttonSortDateForCER1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "SELECT * FROM FormularMoara WHERE Fabrica = 'CER1' ORDER BY dataOra ASC"; 
            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable datatable = new DataTable();
                sqlDataAdapter.Fill(datatable);
                dataGridView1.DataSource = datatable;
            }
            conn.Close();
        }


        private void button4_Click(object sender, EventArgs e)
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
