namespace WinFormsApp
{
    partial class ConfirmSettingsBox
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
            lblConfirmLabel = new Label();
            btnSettingsYes = new Button();
            btnSettingsNo = new Button();
            SuspendLayout();
            // 
            // lblConfirmLabel
            // 
            lblConfirmLabel.AutoSize = true;
            lblConfirmLabel.Location = new Point(187, 108);
            lblConfirmLabel.Name = "lblConfirmLabel";
            lblConfirmLabel.Size = new Size(400, 32);
            lblConfirmLabel.TabIndex = 0;
            lblConfirmLabel.Text = "Are you sure you want this settings?";
            // 
            // btnSettingsYes
            // 
            btnSettingsYes.DialogResult = DialogResult.Yes;
            btnSettingsYes.Location = new Point(124, 255);
            btnSettingsYes.Name = "btnSettingsYes";
            btnSettingsYes.Size = new Size(150, 46);
            btnSettingsYes.TabIndex = 1;
            btnSettingsYes.Text = "Yes";
            btnSettingsYes.UseVisualStyleBackColor = true;
            btnSettingsYes.Click += btnSettingsYes_Click;
            // 
            // btnSettingsNo
            // 
            btnSettingsNo.DialogResult = DialogResult.No;
            btnSettingsNo.Location = new Point(526, 255);
            btnSettingsNo.Name = "btnSettingsNo";
            btnSettingsNo.Size = new Size(150, 46);
            btnSettingsNo.TabIndex = 2;
            btnSettingsNo.Text = "No";
            btnSettingsNo.UseVisualStyleBackColor = true;
            btnSettingsNo.Click += btnSettingsNo_Click;
            // 
            // ConfirmSettingsBox
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSettingsNo);
            Controls.Add(btnSettingsYes);
            Controls.Add(lblConfirmLabel);
            Name = "ConfirmSettingsBox";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ConfirmSettingsBox";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblConfirmLabel;
        private Button btnSettingsYes;
        private Button btnSettingsNo;
    }
}