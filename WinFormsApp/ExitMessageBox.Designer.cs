namespace WinFormsApp
{
    partial class ExitMessageBox
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
            lblExit = new Label();
            btnYes = new Button();
            btnNo = new Button();
            SuspendLayout();
            // 
            // lblExit
            // 
            lblExit.AutoSize = true;
            lblExit.Font = new Font("Segoe UI", 10F);
            lblExit.Location = new Point(109, 81);
            lblExit.Name = "lblExit";
            lblExit.Size = new Size(558, 37);
            lblExit.TabIndex = 0;
            lblExit.Text = "Are you sure you want to exit the application?";
            // 
            // btnYes
            // 
            btnYes.Location = new Point(109, 224);
            btnYes.Name = "btnYes";
            btnYes.Size = new Size(150, 46);
            btnYes.TabIndex = 1;
            btnYes.Text = "Yes";
            btnYes.UseVisualStyleBackColor = true;
            btnYes.Click += btnYes_Click;
            // 
            // btnNo
            // 
            btnNo.Location = new Point(517, 224);
            btnNo.Name = "btnNo";
            btnNo.Size = new Size(150, 46);
            btnNo.TabIndex = 2;
            btnNo.Text = "No";
            btnNo.UseVisualStyleBackColor = true;
            btnNo.Click += btnNo_Click;
            // 
            // ExitMessageBox
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 326);
            Controls.Add(btnNo);
            Controls.Add(btnYes);
            Controls.Add(lblExit);
            Name = "ExitMessageBox";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ExitMessageBox";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblExit;
        private Button btnYes;
        private Button btnNo;
    }
}