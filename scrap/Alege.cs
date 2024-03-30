using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Alege : Form
    {
        public Alege()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
        }
        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {


            Application.ExitThread();
            Environment.Exit(0);

        }
        private void Alege_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Karcher1 karcher = new Karcher1();
            karcher.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormMoaraView formMoaraViz = new FormMoaraView();
            formMoaraViz.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
