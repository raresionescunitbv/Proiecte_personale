namespace WinFormsApp3
{
    partial class FormMoaraView
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
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker1 = new DateTimePicker();
            dataGridView1 = new DataGridView();
            Refresh = new Button();
            button2 = new Button();
            label5 = new Label();
            textBox4 = new TextBox();
            button1 = new Button();
            button3 = new Button();
            button4 = new Button();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(10, 206);
            label6.Name = "label6";
            label6.Size = new Size(162, 19);
            label6.TabIndex = 22;
            label6.Text = "CAUTARE IN FORMULAR";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(23, 13);
            label4.Name = "label4";
            label4.Size = new Size(49, 19);
            label4.TabIndex = 20;
            label4.Text = "DE LA:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(0, 41);
            label3.Name = "label3";
            label3.Size = new Size(67, 19);
            label3.TabIndex = 19;
            label3.Text = "PANA LA:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(111, 133);
            label2.Name = "label2";
            label2.Size = new Size(43, 19);
            label2.TabIndex = 18;
            label2.Text = "LINIA";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(100, 169);
            label1.Name = "label1";
            label1.Size = new Size(60, 19);
            label1.TabIndex = 17;
            label1.Text = "SCHIMB";
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBox3.Location = new Point(195, 202);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(185, 23);
            textBox3.TabIndex = 16;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(195, 169);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(185, 23);
            textBox2.TabIndex = 15;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(195, 133);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(185, 23);
            textBox1.TabIndex = 14;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePicker2.Location = new Point(88, 39);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(252, 23);
            dateTimePicker2.TabIndex = 13;
            dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePicker1.Location = new Point(88, 10);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(252, 23);
            dateTimePicker1.TabIndex = 12;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.Location = new Point(386, 10);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1265, 630);
            dataGridView1.TabIndex = 23;
            // 
            // Refresh
            // 
            Refresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Refresh.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            Refresh.Location = new Point(1387, 646);
            Refresh.Name = "Refresh";
            Refresh.Size = new Size(122, 76);
            Refresh.TabIndex = 25;
            Refresh.Text = "Refresh";
            Refresh.UseVisualStyleBackColor = true;
            Refresh.Click += Refresh_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(1531, 646);
            button2.Name = "button2";
            button2.Size = new Size(120, 76);
            button2.TabIndex = 24;
            button2.Text = "INCHIDE";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(0, 92);
            label5.Name = "label5";
            label5.Size = new Size(149, 19);
            label5.TabIndex = 26;
            label5.Text = "CAUTARE IN INTERVAL";
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBox4.Location = new Point(195, 91);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(185, 23);
            textBox4.TabIndex = 27;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(72, 270);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 28;
            button1.Text = "CER1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.Location = new Point(153, 270);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 29;
            button3.Text = "CER2";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            button4.Location = new Point(1236, 646);
            button4.Name = "button4";
            button4.Size = new Size(127, 76);
            button4.TabIndex = 30;
            button4.Text = "Export excel";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(12, 272);
            label7.Name = "label7";
            label7.Size = new Size(52, 17);
            label7.TabIndex = 31;
            label7.Text = "AFISATI:";
            // 
            // FormMoaraView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Yellow;
            ClientSize = new Size(1657, 734);
            Controls.Add(label7);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(label5);
            Controls.Add(Refresh);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            MinimizeBox = false;
            Name = "FormMoaraView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Formular moara";
            Load += FormMoaraView_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label6;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private DataGridView dataGridView1;
        private Button Refresh;
        private Button button2;
        private Label label5;
        private TextBox textBox4;
        private Button button1;
        private Button button3;
        private Button button4;
        private Label label7;
    }
}