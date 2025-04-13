namespace WinFormsApp
{
    partial class StartDisplay
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            cbChampionship = new ComboBox();
            label2 = new Label();
            cbLanguage = new ComboBox();
            btnApply = new Button();
            btnNext = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 16F, FontStyle.Bold);
            label1.Location = new Point(63, 63);
            label1.Name = "label1";
            label1.Size = new Size(568, 59);
            label1.TabIndex = 0;
            label1.Text = "Choose the championship";
            label1.Click += this.label1_Click;
            // 
            // cbChampionship
            // 
            cbChampionship.FormattingEnabled = true;
            cbChampionship.Location = new Point(76, 157);
            cbChampionship.Name = "cbChampionship";
            cbChampionship.Size = new Size(555, 40);
            cbChampionship.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Black", 16F, FontStyle.Bold);
            label2.Location = new Point(63, 284);
            label2.Name = "label2";
            label2.Size = new Size(438, 59);
            label2.TabIndex = 2;
            label2.Text = "Select the language";
            // 
            // cbLanguage
            // 
            cbLanguage.FormattingEnabled = true;
            cbLanguage.Location = new Point(76, 394);
            cbLanguage.Name = "cbLanguage";
            cbLanguage.Size = new Size(555, 40);
            cbLanguage.TabIndex = 3;
            // 
            // btnApply
            // 
            btnApply.Font = new Font("Segoe UI Black", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnApply.Location = new Point(222, 616);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(279, 124);
            btnApply.TabIndex = 4;
            btnApply.Text = "Apply";
            btnApply.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            btnNext.Font = new Font("Segoe UI Black", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNext.Location = new Point(731, 616);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(279, 124);
            btnNext.TabIndex = 5;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            // 
            // StartDisplay
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1293, 860);
            Controls.Add(btnNext);
            Controls.Add(btnApply);
            Controls.Add(cbLanguage);
            Controls.Add(label2);
            Controls.Add(cbChampionship);
            Controls.Add(label1);
            Name = "StartDisplay";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cbChampionship;
        private Label label2;
        private ComboBox cbLanguage;
        private Button btnApply;
        private Button btnNext;
    }
}
