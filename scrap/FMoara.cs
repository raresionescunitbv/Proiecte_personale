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

    public partial class FMoara : Form
    {
        public SqlConnection conn;
        public FMoara()
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

        }
        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {

            ;
            Application.ExitThread();
            Environment.Exit(0);
        }
        private void FMoara_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conn.ConnectionString)) ;
            {
                conn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT TOP 50 * FROM FormularMoara", conn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                conn.Close();

            }

            dataGridView1.CellClick += dataGridView1_CellClick;

        }
        public void search2(string valueToSearch)
        {
            string query = "SELECT TOP 50 * FROM FormularMoara WHERE CONVERT(varchar, dataOra, 101) LIKE @search";

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
                textBox4.Text = selectedRow.Cells["schimbul"].Value.ToString();
                textBox5.Text = selectedRow.Cells["dataOra"].Value.ToString();
                textBox6.Text = selectedRow.Cells["sefSchimb"].Value.ToString();
                textBox7.Text = selectedRow.Cells["sefEchipa"].Value.ToString();
                textBox8.Text = selectedRow.Cells["codReper"].Value.ToString();
                textBox9.Text = selectedRow.Cells["denumireReper"].Value.ToString();
                textBox10.Text = selectedRow.Cells["bucati"].Value.ToString();
                textBox11.Text = selectedRow.Cells["defect"].Value.ToString();
                textBox12.Text = selectedRow.Cells["intern"].Value.ToString();
                textBox13.Text = selectedRow.Cells["furnizor"].Value.ToString();
                textBox14.Text = selectedRow.Cells["status"].Value.ToString();
                textBox16.Text = selectedRow.Cells["Fabrica"].Value.ToString();




            }
            conn.Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            {

                string NrCrt = textBox2.Text;
                string linia = textBox3.Text;
                string dataOra = textBox5.Text;
                string schimb = textBox4.Text;
                string sefSchimb = textBox6.Text;
                string sefEchipa = textBox7.Text;
                string codReper = textBox8.Text;
                string denumireReper = textBox9.Text;
                string bucati = textBox10.Text;
                string defect = textBox11.Text;
                string intern = textBox12.Text;
                string furnizor = textBox13.Text;
                string status = textBox14.Text;
                string Fabrica = textBox16.Text;


                if (status != "0" && status != "1")
                {
                    MessageBox.Show("Status trebuie să fie 0 sau 1.");
                    return;
                }


                conn.Open();
                SqlCommand updateCmd = new SqlCommand("UPDATE FormularMoara SET linia = @linia, dataOra = @dataOra, schimbul = @schimbul, sefSchimb = @sefSchimb, sefEchipa = @sefEchipa, codReper = @codReper, denumireReper = @denumireReper,bucati=@bucati, defect = @defect, intern = @intern, furnizor=@furnizor,status=@status, Fabrica = @Fabrica WHERE NrCrt = @NrCrt ", conn);

                updateCmd.Parameters.AddWithValue("@NrCrt", NrCrt);
                updateCmd.Parameters.AddWithValue("@linia", linia);
                updateCmd.Parameters.AddWithValue("@dataOra", dataOra);
                updateCmd.Parameters.AddWithValue("@schimbul", schimb);
                updateCmd.Parameters.AddWithValue("@sefSchimb", sefSchimb);
                updateCmd.Parameters.AddWithValue("@sefEchipa", sefEchipa);
                updateCmd.Parameters.AddWithValue("@codReper", codReper);
                updateCmd.Parameters.AddWithValue("@denumireReper", denumireReper);
                updateCmd.Parameters.AddWithValue("@defect", defect);
                updateCmd.Parameters.AddWithValue("@bucati", bucati);
                updateCmd.Parameters.AddWithValue("@intern", intern);
                updateCmd.Parameters.AddWithValue("@furnizor", furnizor);
                updateCmd.Parameters.AddWithValue("@status", status);
                updateCmd.Parameters.AddWithValue("@Fabrica", Fabrica);





                try
                {
                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Modificare reușită!");
                        conn.Close();
                    }
                    else
                    {
                        MessageBox.Show("Modificare eșuată.");
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
            using (SqlConnection sqlCon = new SqlConnection(conn.ConnectionString))
            {
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT TOP 50 * FROM FormularMoara", conn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                conn.Close();

            }

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


        }
        public void searchWithinDateRange1(string valueToSearch, DateTime startDate, DateTime endDate)
        {
            conn.Open();

            string query = "SELECT * FROM FormularMoara WHERE (NrCrt LIKE @search OR linia LIKE @search OR schimbul LIKE @search OR dataOra LIKE @search OR sefschimb LIKE @search OR sefechipa LIKE @search OR codReper LIKE @search OR denumireReper LIKE @search OR bucati LIKE @search OR defect LIKE @search OR intern  LIKE @search OR furnizor LIKE @search OR status LIKE @search  OR Fabrica LIKE @search)" +
                           "AND dataOra  BETWEEN @startDate  AND @endDate";

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
                using (SqlConnection sqlCon = new SqlConnection(conn.ConnectionString)) ;
                {
                    conn.Open();
                    SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT TOP 50 * FROM FormularMoara ", conn);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;
                    conn.Close();

                }


                //dateTimePicker1.ResetText();
                // dateTimePicker2.ResetText();
                textBox15.Clear();
                using (SqlConnection sqlCon = new SqlConnection(conn.ConnectionString)) ;
                {
                    conn.Open();
                    SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT TOP 50 * FROM FormularMoara ", conn);
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
        private void search1(string valueToSearch, DateTime startDate, DateTime endDate)
        {
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
                using (SqlConnection sqlCon = new SqlConnection(conn.ConnectionString)) ;
                {
                    conn.Open();
                    SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT TOP 50 * FROM FormularMoara ", conn);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;
                    conn.Close();

                }


                //dateTimePicker2.ResetText();
                //textBox15.Clear();
                using (SqlConnection sqlCon = new SqlConnection(conn.ConnectionString)) ;
                {
                    conn.Open();
                    SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT TOP 50 * FROM FormularMoara ", conn);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string valueToSearch = textBox1.Text.ToString();
            search(valueToSearch);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conn.ConnectionString)) ;
            {
                conn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT TOP 50 * FROM FormularMoara", conn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                conn.Close();

            }
            textBox15.Clear();
            textBox1.Clear();
            dateTimePicker2.ResetText();
            dateTimePicker1.ResetText();

            using (SqlConnection con = new SqlConnection(conn.ConnectionString)) ;
            {
                conn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT TOP 50 * FROM FormularMoara", conn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                conn.Close();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }
        public void search12(string valueToSearch)
        {

            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;

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
        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            string valueToSearch = textBox15.Text.ToString();
            search12(valueToSearch);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            conn.Open();
            string fabrica = "@Fabrica";
            string query = "SELECT * FROM FormularMoara WHERE Fabrica = 'CER1'";

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

        private void button3_Click_1(object sender, EventArgs e)
        {

            conn.Open();
            string fabrica = "@Fabrica";
            string query = "SELECT * FROM FormularMoara WHERE Fabrica = 'CER2'";

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

        private void button2_Click(object sender, EventArgs e)
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
