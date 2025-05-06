namespace WinFormsApp
{
    partial class PlayerControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerControl));
            pbPlayer = new PictureBox();
            lblName = new Label();
            lblShirtNum = new Label();
            lblPosition = new Label();
            lblCaptain = new Label();
            lblFavoritePlayer = new Label();
            ((System.ComponentModel.ISupportInitialize)pbPlayer).BeginInit();
            SuspendLayout();
            // 
            // pbPlayer
            // 
            pbPlayer.Image = (Image)resources.GetObject("pbPlayer.Image");
            pbPlayer.Location = new Point(53, 28);
            pbPlayer.Name = "pbPlayer";
            pbPlayer.Size = new Size(340, 241);
            pbPlayer.SizeMode = PictureBoxSizeMode.Zoom;
            pbPlayer.TabIndex = 0;
            pbPlayer.TabStop = false;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(53, 289);
            lblName.Name = "lblName";
            lblName.Size = new Size(83, 32);
            lblName.TabIndex = 1;
            lblName.Text = "Name:";
            // 
            // lblShirtNum
            // 
            lblShirtNum.AutoSize = true;
            lblShirtNum.Location = new Point(53, 338);
            lblShirtNum.Name = "lblShirtNum";
            lblShirtNum.Size = new Size(159, 32);
            lblShirtNum.TabIndex = 2;
            lblShirtNum.Text = "Shirt number:";
            // 
            // lblPosition
            // 
            lblPosition.AutoSize = true;
            lblPosition.Location = new Point(53, 384);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(103, 32);
            lblPosition.TabIndex = 3;
            lblPosition.Text = "Position:";
            // 
            // lblCaptain
            // 
            lblCaptain.AutoSize = true;
            lblCaptain.Location = new Point(53, 432);
            lblCaptain.Name = "lblCaptain";
            lblCaptain.Size = new Size(100, 32);
            lblCaptain.TabIndex = 4;
            lblCaptain.Text = "Captain:";
            // 
            // lblFavoritePlayer
            // 
            lblFavoritePlayer.AutoSize = true;
            lblFavoritePlayer.Location = new Point(53, 473);
            lblFavoritePlayer.Name = "lblFavoritePlayer";
            lblFavoritePlayer.Size = new Size(175, 32);
            lblFavoritePlayer.TabIndex = 5;
            lblFavoritePlayer.Text = "Favorite player:";
            // 
            // PlayerControl
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblFavoritePlayer);
            Controls.Add(lblCaptain);
            Controls.Add(lblPosition);
            Controls.Add(lblShirtNum);
            Controls.Add(lblName);
            Controls.Add(pbPlayer);
            Name = "PlayerControl";
            Size = new Size(444, 545);
            ((System.ComponentModel.ISupportInitialize)pbPlayer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbPlayer;
        private Label lblName;
        private Label lblShirtNum;
        private Label lblPosition;
        private Label lblCaptain;
        private Label lblFavoritePlayer;
    }
}
