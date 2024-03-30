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

namespace WinFormsApp3
{
    public partial class Form3 : Form
    {
        public SqlConnection conn;
        public Form3()
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
            this.FormClosing += Form3_FormClosing;
        }


        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 fo4 = new Form4();
            fo4.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CodReper codReper = new CodReper();
            codReper.Show();
            this.Hide();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            DenumireDefect denumireDefect = new DenumireDefect();
            denumireDefect.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Supervizori supervizori = new Supervizori();
            supervizori.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            formular1 formular1 = new formular1();
            formular1.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
        private void Form3_FormClosing(Object sender, FormClosingEventArgs e)
        {


            Application.ExitThread();
            Environment.Exit(0);
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form8 form = new Form8();
            form.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            FMoara fMoara = new FMoara();
            fMoara.Show();
            this.Hide();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Tablete tablete = new Tablete();
            tablete.Show();
            this.Hide();
        }
    }
}
