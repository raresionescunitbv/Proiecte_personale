namespace WinFormsApp3
{
    partial class Form8
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
            button3 = new Button();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            textBox1 = new TextBox();
            textBox3 = new TextBox();
            textBox5 = new TextBox();
            label4 = new Label();
            label5 = new Label();
            button2 = new Button();
            textBox2 = new TextBox();
            button1 = new Button();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button3
            // 
            button3.Location = new Point(465, 436);
            button3.Name = "button3";
            button3.Size = new Size(178, 38);
            button3.TabIndex = 2;
            button3.Text = "Inapoi";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.Location = new Point(304, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(339, 403);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 113);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 4;
            label1.Text = "CAUTARE:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(90, 110);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 23);
            textBox1.TabIndex = 5;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(90, 245);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(133, 23);
            textBox3.TabIndex = 11;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(90, 286);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(133, 23);
            textBox5.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 245);
            label4.Name = "label4";
            label4.Size = new Size(65, 15);
            label4.TabIndex = 14;
            label4.Text = "Nume linie";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(9, 286);
            label5.Name = "label5";
            label5.Size = new Size(39, 15);
            label5.TabIndex = 15;
            label5.Text = "Status";
            // 
            // button2
            // 
            button2.Location = new Point(86, 326);
            button2.Name = "button2";
            button2.Size = new Size(137, 41);
            button2.TabIndex = 16;
            button2.Text = "Actualizare";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(87, 201);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(136, 23);
            textBox2.TabIndex = 17;
            textBox2.Visible = false;
            // 
            // button1
            // 
            button1.Location = new Point(115, 139);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 18;
            button1.Text = "cauta";
            button1.UseVisualStyleBackColor = true;
            button1.Visible = false;
            // 
            // button4
            // 
            button4.Location = new Point(86, 372);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(137, 37);
            button4.TabIndex = 19;
            button4.Text = "Adauga linie";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click_1;
            // 
            // Form8
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Yellow;
            ClientSize = new Size(657, 486);
            Controls.Add(button4);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(button2);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(textBox5);
            Controls.Add(textBox3);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(button3);
            MaximizeBox = false;
            Name = "Form8";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Linii";
            Load += Form8_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button3;
        private DataGridView dataGridView1;
        private Label label1;
        private TextBox textBox1;
        private TextBox textBox3;
        private TextBox textBox5;
        private Label label4;
        private Label label5;
        private Button button2;
        private TextBox textBox2;
        private Button button1;
        private Button button4;
    }
}