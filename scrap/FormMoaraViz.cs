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

namespace WinFormsApp3
{
    public partial class FormMoaraViz : Form
    {
        public SqlConnection conn;
        public FormMoaraViz()
        {
            InitializeComponent();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "config.txt");
            string connectionString = File.ReadAllText(path);
            conn = new SqlConnection(connectionString);
        }
        private void FormMoaraViz_Load(object sender, EventArgs e)
        {
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

        public void search3(string valueToSearch)
        {
            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;

            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            {
                string query = "SELECT * FROM FormularMoara WHERE (NrCrt LIKE @search OR linia LIKE @search OR schimbul LIKE @search OR dataOra LIKE @search OR sefschimb LIKE @search OR sefechipa LIKE @search OR codReper LIKE @search OR denumireReper LIKE @search OR bucati LIKE @search OR defect LIKE @search OR defect LIKE @search OR intern LIKE @search OR furnizor LIKE @search OR status LIKE @search ) " +
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
        private void LoadData()
        {
            using (SqlConnection sqlCon = new SqlConnection(conn.ConnectionString))
            {
                conn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT TOP 50 * FROM FormularMoara WHERE status = 1", conn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                conn.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        public void search1(string valueToSearch)
        {


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from FormularMoara where dataOra between @data1-1 And @data2 Order By dataOra Desc", conn);
            cmd.Parameters.Add("data1", SqlDbType.DateTime).Value = dateTimePicker1.Value;
            cmd.Parameters.Add("data2", SqlDbType.DateTime).Value = dateTimePicker2.Value;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from FormularMoara where dataOra between @data1-1 And @data2 Order By dataOra Desc", conn);
            cmd.Parameters.Add("data1", SqlDbType.DateTime).Value = dateTimePicker1.Value;
            cmd.Parameters.Add("data2", SqlDbType.DateTime).Value = dateTimePicker2.Value;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string valueToSearch = textBox1.Text.ToString();
            search4(valueToSearch);
        }
        public void search0(string valueToSearch)
        {

            string query = "SELECT TOP 50 * FROM FormularMoara WHERE schimbul LIKE @search  ";

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
        public void search4(string valueToSearch)
        {

            string query = "SELECT TOP 50 * FROM FormularMoara WHERE linia LIKE @search  ";

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

        private void button2_Click(object sender, EventArgs e)
        {
            Alege alege = new Alege();
            alege.Show();
            this.Hide();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(conn.ConnectionString))
            {
                conn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT TOP 50 * FROM FormularMoara WHERE status = 1", conn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                conn.Close();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string valueToSearch = textBox3.Text.ToString();
            search3(valueToSearch);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string valueToSearch = textBox2.Text.ToString();
            search0(valueToSearch);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(conn.ConnectionString)) ;
            {
                conn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM FormularMoara WHERE status = 1", conn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                conn.Close();

            }
        }
    }
}
