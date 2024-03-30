namespace WinFormsApp3
{
    partial class FormMoaraViz
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
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            button2 = new Button();
            Refresh = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(220, 27);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(228, 25);
            dateTimePicker1.TabIndex = 1;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(527, 28);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(230, 25);
            dateTimePicker2.TabIndex = 2;
            dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(875, 34);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(1067, 33);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 25);
            textBox2.TabIndex = 4;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(1280, 33);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(120, 25);
            textBox3.TabIndex = 5;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1001, 36);
            label1.Name = "label1";
            label1.Size = new Size(60, 19);
            label1.TabIndex = 6;
            label1.Text = "SCHIMB";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(816, 36);
            label2.Name = "label2";
            label2.Size = new Size(43, 19);
            label2.TabIndex = 7;
            label2.Text = "LINIA";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(454, 31);
            label3.Name = "label3";
            label3.Size = new Size(67, 19);
            label3.TabIndex = 8;
            label3.Text = "PANA LA:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(164, 34);
            label4.Name = "label4";
            label4.Size = new Size(49, 19);
            label4.TabIndex = 9;
            label4.Text = "DE LA:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 35);
            label5.Name = "label5";
            label5.Size = new Size(151, 19);
            label5.TabIndex = 10;
            label5.Text = "FILTREAZA DUPA DATA";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1206, 38);
            label6.Name = "label6";
            label6.Size = new Size(67, 19);
            label6.TabIndex = 11;
            label6.Text = "CAUTARE";
            // 
            // button2
            // 
            button2.Location = new Point(1284, 831);
            button2.Name = "button2";
            button2.Size = new Size(120, 76);
            button2.TabIndex = 13;
            button2.Text = "INCHIDE";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Refresh
            // 
            Refresh.Location = new Point(1151, 831);
            Refresh.Name = "Refresh";
            Refresh.Size = new Size(122, 76);
            Refresh.TabIndex = 14;
            Refresh.Text = "RESET";
            Refresh.UseVisualStyleBackColor = true;
            Refresh.Click += Refresh_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 81);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1388, 744);
            dataGridView1.TabIndex = 15;
            // 
            // FormMoaraViz
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Yellow;
            ClientSize = new Size(1430, 920);
            Controls.Add(dataGridView1);
            Controls.Add(Refresh);
            Controls.Add(button2);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "FormMoaraViz";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormMoaraViz";
            Load += FormMoaraViz_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button button2;
        private Button Refresh;
        private DataGridView dataGridView1;
    }
}