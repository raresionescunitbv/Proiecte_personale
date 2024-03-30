using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Configuration;
using System.Xml;
using System.Diagnostics;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        private Size formOriginalSize;
        private Rectangle but1;
        private Rectangle tb1;
        private Rectangle tb2;
        public SqlConnection conn;


        public Form1()
        {


            InitializeComponent();

            formOriginalSize = this.Size;
            but1 = new Rectangle(button1.Location, button1.Size);
            tb1 = new Rectangle(textBox1.Location, textBox1.Size);
            tb2 = new Rectangle(textBox1.Location, textBox1.Size);
            textBox2.PasswordChar = '*';
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

        }


        private void button2_Click(object sender, EventArgs e)
        {
            ;
        }
        private void Form1_Resiz(object sender, EventArgs e)
        {
            resize_Control(button1, but1);
            resize_Control(textBox1, tb1);
            resize_Control(textBox2, tb2);

        }
        private void resize_Control(Control c, Rectangle r)
        {
            float xRatio = (float)(this.Width) / (float)(formOriginalSize.Width);
            float yRatio = (float)(this.Height) / (float)(formOriginalSize.Height);
            int newX = (int)(r.X * xRatio);
            int newY = (int)(r.Y * yRatio);
            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);
            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Completați toate câmpurile!");
                return;
            }

            try
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Utilizatori WHERE Utilizator = @Utilizator AND Parola = @Parola AND Sters = 0";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Utilizator", username);
                cmd.Parameters.AddWithValue("@Parola", password);
                int rowCount = (int)cmd.ExecuteScalar();

                if (rowCount > 0)
                {
                    string userQuery = "SELECT Activitate, Sters FROM Utilizatori WHERE Utilizator = @Utilizator";
                    SqlCommand userCmd = new SqlCommand(userQuery, conn);
                    userCmd.Parameters.AddWithValue("@Utilizator", username);

                    using (SqlDataReader reader = userCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            bool isActive = !reader.IsDBNull(reader.GetOrdinal("Activitate")) && reader.GetBoolean(reader.GetOrdinal("Activitate"));
                            bool isDeleted = !reader.IsDBNull(reader.GetOrdinal("Sters")) && reader.GetBoolean(reader.GetOrdinal("Sters"));

                            if (!isDeleted)
                            {
                                if (isActive)
                                {
                                    Form3 form3 = new Form3();
                                    form3.Show();
                                }
                                else
                                {
                                    Alege k = new Alege();
                                    k.Show();
                                }
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Utilizatorul a fost șters din baza de date.");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Utilizatorul nu există în baza de date sau parola este incorectă.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            conn.Close();

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.AcceptButton = button1;
            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            {
                conn.Open();
                string query = "SELECT versiunea FROM Version";
                double versiuneCurenta = 2.0;
 
                using (SqlCommand cmdSelect = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmdSelect.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            double versiuneDB = reader.GetDouble(0);
                            if (versiuneDB > versiuneCurenta)
                            {
                                if (MessageBox.Show("Exista o versiune noua a aplicatiei. Instalati acum?", "Versiune noua", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    
                                    ProcessStartInfo start = new ProcessStartInfo();
                                    start.FileName = @"G:\Shared drives\RO30 OPN ORG\IT\scrap exe\ScrapSetup.exe";
                                    Process.Start(start);
                                    this.Close();  
                                }
                                else
                                {
                                   
                                }
                            }
                        }
                    }
                }
                conn.Close();

            }
        }
    } }


