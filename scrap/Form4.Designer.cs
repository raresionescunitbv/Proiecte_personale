namespace WinFormsApp3
{
    partial class Form4
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button2 = new Button();
            dataGridView1 = new DataGridView();
            checkBox1 = new CheckBox();
            button4 = new Button();
            checkBox2 = new CheckBox();
            label4 = new Label();
            textBox3 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 89);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(85, 21);
            label1.TabIndex = 0;
            label1.Text = "Utilizator";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(54, 144);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(60, 21);
            label2.TabIndex = 1;
            label2.Text = "Parola";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(-4, 9);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(241, 21);
            label3.TabIndex = 2;
            label3.Text = "CONECTAT:ADMINISTRATOR";
            // 
            // button1
            // 
            button1.Location = new Point(147, 328);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(167, 70);
            button1.TabIndex = 10;
            button1.Text = "ADAUGARE";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(147, 86);
            textBox1.Margin = new Padding(4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(208, 29);
            textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(147, 144);
            textBox2.Margin = new Padding(4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(208, 29);
            textBox2.TabIndex = 7;
            // 
            // button2
            // 
            button2.Location = new Point(646, 459);
            button2.Name = "button2";
            button2.Size = new Size(161, 32);
            button2.TabIndex = 8;
            button2.Text = "INAPOI";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_2;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.Location = new Point(383, 86);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(424, 304);
            dataGridView1.TabIndex = 9;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(147, 180);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(142, 25);
            checkBox1.TabIndex = 8;
            checkBox1.Text = "Seteaza admin";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // button4
            // 
            button4.Location = new Point(147, 251);
            button4.Name = "button4";
            button4.Size = new Size(167, 70);
            button4.TabIndex = 11;
            button4.Text = "ACTUALIZARE";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(147, 211);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(80, 25);
            checkBox2.TabIndex = 9;
            checkBox2.Text = "Sterge";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(452, 400);
            label4.Name = "label4";
            label4.Size = new Size(62, 21);
            label4.TabIndex = 14;
            label4.Text = "Nume:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(535, 397);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(146, 29);
            textBox3.TabIndex = 15;
            textBox3.TextChanged += textBox3_TextChanged_1;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Yellow;
            ClientSize = new Size(822, 503);
            Controls.Add(textBox3);
            Controls.Add(label4);
            Controls.Add(checkBox2);
            Controls.Add(button4);
            Controls.Add(checkBox1);
            Controls.Add(dataGridView1);
            Controls.Add(button2);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI Black", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "Form4";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Utilizatori";
            Load += Form4_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button2;
        private DataGridView dataGridView1;
        private CheckBox checkBox1;
        private Button button4;
        private CheckBox checkBox2;
        private Label label4;
        private TextBox textBox3;
    }
}