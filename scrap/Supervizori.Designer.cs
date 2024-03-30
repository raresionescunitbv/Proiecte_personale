namespace WinFormsApp3
{
    partial class Supervizori
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
            button3 = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            label8 = new Label();
            textBox8 = new TextBox();
            label9 = new Label();
            textBox9 = new TextBox();
            textBox1 = new TextBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.Location = new Point(352, 46);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(844, 502);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button2
            // 
            button2.Location = new Point(74, 559);
            button2.Name = "button2";
            button2.Size = new Size(187, 47);
            button2.TabIndex = 2;
            button2.Text = "Actualizare";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button3.Location = new Point(1031, 571);
            button3.Name = "button3";
            button3.Size = new Size(187, 46);
            button3.TabIndex = 3;
            button3.Text = "Inapoi";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 192);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 5;
            label2.Text = "Linia";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 236);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 6;
            label3.Text = "Schimb";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 282);
            label4.Name = "label4";
            label4.Size = new Size(62, 15);
            label4.TabIndex = 7;
            label4.Text = "sefSchimb";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 329);
            label5.Name = "label5";
            label5.Size = new Size(57, 15);
            label5.TabIndex = 8;
            label5.Text = "sefEchipa";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(21, 379);
            label6.Name = "label6";
            label6.Size = new Size(69, 15);
            label6.TabIndex = 9;
            label6.Text = "InspCalitate";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(10, 428);
            label7.Name = "label7";
            label7.Size = new Size(79, 15);
            label7.TabIndex = 10;
            label7.Text = "RespLogistica";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(102, 184);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(148, 23);
            textBox2.TabIndex = 12;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(102, 228);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(148, 23);
            textBox3.TabIndex = 13;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(102, 279);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(148, 23);
            textBox4.TabIndex = 14;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(102, 329);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(148, 23);
            textBox5.TabIndex = 15;
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(102, 376);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(148, 23);
            textBox6.TabIndex = 16;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(102, 425);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(148, 23);
            textBox7.TabIndex = 17;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(16, 89);
            label8.Name = "label8";
            label8.Size = new Size(41, 15);
            label8.TabIndex = 18;
            label8.Text = "Cauta:";
            // 
            // textBox8
            // 
            textBox8.Location = new Point(63, 89);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(187, 23);
            textBox8.TabIndex = 20;
            textBox8.TextChanged += textBox8_TextChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(40, 474);
            label9.Name = "label9";
            label9.Size = new Size(39, 15);
            label9.TabIndex = 21;
            label9.Text = "Status";
            // 
            // textBox9
            // 
            textBox9.Location = new Point(102, 471);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(148, 23);
            textBox9.TabIndex = 22;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(102, 143);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(148, 23);
            textBox1.TabIndex = 24;
            textBox1.Visible = false;
            // 
            // button1
            // 
            button1.Location = new Point(74, 505);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(187, 49);
            button1.TabIndex = 25;
            button1.Text = "Adauga supervizor";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // Supervizori
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Yellow;
            ClientSize = new Size(1230, 629);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(textBox9);
            Controls.Add(label9);
            Controls.Add(textBox8);
            Controls.Add(label8);
            Controls.Add(textBox7);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            MaximizeBox = false;
            Name = "Supervizori";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Supervizori";
            Load += Supervizori_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button2;
        private Button button3;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private Label label8;
        private TextBox textBox8;
        private Label label9;
        private TextBox textBox9;
        private TextBox textBox1;
        private Button button1;
    }
}