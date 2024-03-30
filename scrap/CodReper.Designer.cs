namespace WinFormsApp3
{
    partial class CodReper
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            button2 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            button3 = new Button();
            label2 = new Label();
            textBox2 = new TextBox();
            label4 = new Label();
            textBox4 = new TextBox();
            label6 = new Label();
            textBox6 = new TextBox();
            textBox3 = new TextBox();
            Adauga = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.Location = new Point(369, 33);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(459, 539);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button2
            // 
            button2.Location = new Point(93, 295);
            button2.Name = "button2";
            button2.Size = new Size(217, 60);
            button2.TabIndex = 7;
            button2.Text = "Actualizare BD";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 170);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 3;
            label1.Text = "codReper";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(110, 162);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(200, 23);
            textBox1.TabIndex = 4;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button3
            // 
            button3.Location = new Point(715, 587);
            button3.Name = "button3";
            button3.Size = new Size(154, 40);
            button3.TabIndex = 15;
            button3.Text = "Inapoi";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(4, 206);
            label2.Name = "label2";
            label2.Size = new Size(88, 15);
            label2.TabIndex = 11;
            label2.Text = "denumireReper";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(110, 206);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(200, 23);
            textBox2.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(59, 33);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 11;
            label4.Text = "Cautare:";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(116, 33);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(184, 23);
            textBox4.TabIndex = 13;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(34, 250);
            label6.Name = "label6";
            label6.Size = new Size(39, 15);
            label6.TabIndex = 12;
            label6.Text = "Status";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(110, 247);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(200, 23);
            textBox6.TabIndex = 6;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(110, 121);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(200, 23);
            textBox3.TabIndex = 19;
            textBox3.Visible = false;
            // 
            // Adauga
            // 
            Adauga.Location = new Point(93, 372);
            Adauga.Name = "Adauga";
            Adauga.Size = new Size(217, 54);
            Adauga.TabIndex = 8;
            Adauga.Text = "ADAUGA";
            Adauga.UseVisualStyleBackColor = true;
            Adauga.Click += Adauga_Click;
            // 
            // CodReper
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Yellow;
            ClientSize = new Size(881, 644);
            Controls.Add(Adauga);
            Controls.Add(textBox3);
            Controls.Add(textBox6);
            Controls.Add(label6);
            Controls.Add(textBox4);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(button3);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Name = "CodReper";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CodReper";
            Load += CodReper_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button2;
        private Label label1;
        private TextBox textBox1;
        private Button button3;
        private Label label2;
        private TextBox textBox2;
        private Label label4;
        private TextBox textBox4;
        private Label label6;
        private TextBox textBox6;
        private TextBox textBox3;
        private Button Adauga;
    }
}