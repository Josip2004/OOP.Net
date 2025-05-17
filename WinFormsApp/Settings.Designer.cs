namespace WinFormsApp
{
    partial class Settings
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
            lblChampionshipSettings = new Label();
            cbChooseChampionShip = new ComboBox();
            lblChooseLanguage = new Label();
            cbChooseLanguage = new ComboBox();
            btnApplySettings = new Button();
            SuspendLayout();
            // 
            // lblChampionshipSettings
            // 
            lblChampionshipSettings.AutoSize = true;
            lblChampionshipSettings.Font = new Font("Segoe UI Black", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblChampionshipSettings.Location = new Point(56, 38);
            lblChampionshipSettings.Name = "lblChampionshipSettings";
            lblChampionshipSettings.Size = new Size(381, 40);
            lblChampionshipSettings.TabIndex = 0;
            lblChampionshipSettings.Text = "Choose the championship";
            // 
            // cbChooseChampionShip
            // 
            cbChooseChampionShip.FormattingEnabled = true;
            cbChooseChampionShip.Location = new Point(66, 117);
            cbChooseChampionShip.Name = "cbChooseChampionShip";
            cbChooseChampionShip.Size = new Size(447, 40);
            cbChooseChampionShip.TabIndex = 1;
            // 
            // lblChooseLanguage
            // 
            lblChooseLanguage.AutoSize = true;
            lblChooseLanguage.Font = new Font("Segoe UI Black", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblChooseLanguage.Location = new Point(66, 247);
            lblChooseLanguage.Name = "lblChooseLanguage";
            lblChooseLanguage.Size = new Size(294, 40);
            lblChooseLanguage.TabIndex = 2;
            lblChooseLanguage.Text = "Select the language";
            // 
            // cbChooseLanguage
            // 
            cbChooseLanguage.FormattingEnabled = true;
            cbChooseLanguage.Location = new Point(70, 341);
            cbChooseLanguage.Name = "cbChooseLanguage";
            cbChooseLanguage.Size = new Size(443, 40);
            cbChooseLanguage.TabIndex = 3;
            // 
            // btnApplySettings
            // 
            btnApplySettings.Font = new Font("Segoe UI Black", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnApplySettings.Location = new Point(371, 432);
            btnApplySettings.Name = "btnApplySettings";
            btnApplySettings.Size = new Size(201, 62);
            btnApplySettings.TabIndex = 4;
            btnApplySettings.Text = "Apply";
            btnApplySettings.UseVisualStyleBackColor = true;
            btnApplySettings.Click += btnApplySettings_Click;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(955, 559);
            Controls.Add(btnApplySettings);
            Controls.Add(cbChooseLanguage);
            Controls.Add(lblChooseLanguage);
            Controls.Add(cbChooseChampionShip);
            Controls.Add(lblChampionshipSettings);
            Name = "Settings";
            Text = "Settings";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblChampionshipSettings;
        private ComboBox cbChooseChampionShip;
        private Label lblChooseLanguage;
        private ComboBox cbChooseLanguage;
        private Button btnApplySettings;
    }
}