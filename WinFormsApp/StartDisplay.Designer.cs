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
            lblChooserChampionship = new Label();
            cbChampionship = new ComboBox();
            lblSelectLanguage = new Label();
            cbLanguage = new ComboBox();
            btnApply = new Button();
            btnNext = new Button();
            SuspendLayout();
            // 
            // lblChooserChampionship
            // 
            lblChooserChampionship.AutoSize = true;
            lblChooserChampionship.Font = new Font("Segoe UI Black", 16F, FontStyle.Bold);
            lblChooserChampionship.Location = new Point(63, 63);
            lblChooserChampionship.Name = "lblChooserChampionship";
            lblChooserChampionship.Size = new Size(568, 59);
            lblChooserChampionship.TabIndex = 0;
            lblChooserChampionship.Text = "Choose the championship";
            // 
            // cbChampionship
            // 
            cbChampionship.FormattingEnabled = true;
            cbChampionship.Location = new Point(76, 157);
            cbChampionship.Name = "cbChampionship";
            cbChampionship.Size = new Size(555, 40);
            cbChampionship.TabIndex = 1;
            // 
            // lblSelectLanguage
            // 
            lblSelectLanguage.AutoSize = true;
            lblSelectLanguage.Font = new Font("Segoe UI Black", 16F, FontStyle.Bold);
            lblSelectLanguage.Location = new Point(63, 284);
            lblSelectLanguage.Name = "lblSelectLanguage";
            lblSelectLanguage.Size = new Size(438, 59);
            lblSelectLanguage.TabIndex = 2;
            lblSelectLanguage.Text = "Select the language";
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
            btnApply.Location = new Point(134, 612);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(290, 124);
            btnApply.TabIndex = 4;
            btnApply.Text = "Apply";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // btnNext
            // 
            btnNext.Font = new Font("Segoe UI Black", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNext.Location = new Point(729, 613);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(236, 123);
            btnNext.TabIndex = 5;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // StartDisplay
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1293, 860);
            Controls.Add(btnNext);
            Controls.Add(btnApply);
            Controls.Add(cbLanguage);
            Controls.Add(lblSelectLanguage);
            Controls.Add(cbChampionship);
            Controls.Add(lblChooserChampionship);
            Name = "StartDisplay";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblChooserChampionship;
        private ComboBox cbChampionship;
        private Label lblSelectLanguage;
        private ComboBox cbLanguage;
        private Button btnApply;
        private Button btnNext;
    }
}
