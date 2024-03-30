namespace WinFormsApp3
{
    partial class Alege
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(295, 64);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(98, 21);
            label1.TabIndex = 0;
            label1.Text = "SELECTATI ";
            // 
            // button1
            // 
            button1.Location = new Point(115, 126);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(444, 70);
            button1.TabIndex = 1;
            button1.Text = "Formular Scrap";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(115, 241);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(444, 75);
            button2.TabIndex = 2;
            button2.Text = "Formular Moara";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(554, 374);
            button3.Name = "button3";
            button3.Size = new Size(124, 37);
            button3.TabIndex = 3;
            button3.Text = "Inchide";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Alege
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            BackColor = Color.Yellow;
            ClientSize = new Size(690, 423);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Font = new Font("Segoe UI Black", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "Alege";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Alege";
            Load += Alege_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}