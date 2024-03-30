namespace WinFormsApp3
{
    partial class DenumireDefect
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
            textBox2 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            textBox5 = new TextBox();
            label5 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.Location = new Point(324, 21);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(383, 356);
            dataGridView1.TabIndex = 0;
            // 
            // button2
            // 
            button2.Location = new Point(43, 319);
            button2.Name = "button2";
            button2.Size = new Size(233, 46);
            button2.TabIndex = 20;
            button2.Text = "Actualizare";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(565, 423);
            button3.Name = "button3";
            button3.Size = new Size(173, 45);
            button3.TabIndex = 10;
            button3.Text = "Inapoi";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 234);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 5;
            label2.Text = "Defect";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(79, 226);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(161, 23);
            textBox2.TabIndex = 18;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(125, 105);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 9;
            label3.Text = "Cautare";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(79, 123);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(137, 23);
            textBox3.TabIndex = 10;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(79, 273);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(161, 23);
            textBox5.TabIndex = 19;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(28, 276);
            label5.Name = "label5";
            label5.Size = new Size(39, 15);
            label5.TabIndex = 15;
            label5.Text = "Status";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(79, 183);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(161, 23);
            textBox1.TabIndex = 17;
            textBox1.Visible = false;
            // 
            // button1
            // 
            button1.Location = new Point(43, 371);
            button1.Name = "button1";
            button1.Size = new Size(233, 45);
            button1.TabIndex = 21;
            button1.Text = "Adauga";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // DenumireDefect
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Yellow;
            ClientSize = new Size(750, 480);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(textBox5);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            MaximizeBox = false;
            Name = "DenumireDefect";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DenumireDefect";
            Load += DenumireDefect_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button2;
        private Button button3;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox3;
        private TextBox textBox5;
        private Label label5;
        private TextBox textBox1;
        private Button button1;
    }
}