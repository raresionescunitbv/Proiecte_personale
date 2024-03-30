namespace WinFormsApp3
{
    partial class Form3
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
            pictureBox1 = new PictureBox();
            label1 = new Label();
            button3 = new Button();
            button4 = new Button();
            button1 = new Button();
            button5 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button2 = new Button();
            button6 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logobun;
            pictureBox1.Location = new Point(-1, 17);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(207, 70);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(345, 34);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(66, 21);
            label1.TabIndex = 1;
            label1.Text = "MENIU";
            // 
            // button3
            // 
            button3.Location = new Point(282, 63);
            button3.Margin = new Padding(4);
            button3.Name = "button3";
            button3.Size = new Size(200, 56);
            button3.TabIndex = 1;
            button3.Text = "Utilizatori";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(282, 480);
            button4.Margin = new Padding(4);
            button4.Name = "button4";
            button4.Size = new Size(200, 45);
            button4.TabIndex = 8;
            button4.Text = "Inapoi";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button1
            // 
            button1.Location = new Point(282, 361);
            button1.Name = "button1";
            button1.Size = new Size(200, 52);
            button1.TabIndex = 6;
            button1.Text = "Denumire defect";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button5
            // 
            button5.Location = new Point(282, 188);
            button5.Name = "button5";
            button5.Size = new Size(200, 56);
            button5.TabIndex = 3;
            button5.Text = " Formular";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button7
            // 
            button7.Location = new Point(282, 126);
            button7.Name = "button7";
            button7.Size = new Size(200, 56);
            button7.TabIndex = 2;
            button7.Text = "Cod reper";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(282, 419);
            button8.Name = "button8";
            button8.Size = new Size(200, 54);
            button8.TabIndex = 7;
            button8.Text = "Linii";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Location = new Point(282, 299);
            button9.Name = "button9";
            button9.Size = new Size(200, 56);
            button9.TabIndex = 5;
            button9.Text = "Supervizori";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button2
            // 
            button2.Location = new Point(282, 250);
            button2.Name = "button2";
            button2.Size = new Size(200, 43);
            button2.TabIndex = 4;
            button2.Text = "Formular Moara";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // button6
            // 
            button6.Location = new Point(6, 94);
            button6.Name = "button6";
            button6.Size = new Size(200, 49);
            button6.TabIndex = 9;
            button6.Text = "Tablete";
            button6.UseVisualStyleBackColor = true;
            button6.Visible = false;
            button6.Click += button6_Click_1;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Yellow;
            ClientSize = new Size(789, 536);
            Controls.Add(button6);
            Controls.Add(button2);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button5);
            Controls.Add(button1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Font = new Font("Segoe UI Black", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "Form3";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Meniu";
            Load += Form3_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Button button3;
        private Button button4;
        private Button button1;
        private Button button5;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button2;
        private Button button6;
    }
}