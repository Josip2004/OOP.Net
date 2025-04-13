namespace WinFormsApp
{
    partial class Main
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
            menuStrip1 = new MenuStrip();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            rangListToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            cbFavoriteNationalTeam = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            pnlPlayers = new Panel();
            pnlFavoritePlayers = new Panel();
            label4 = new Label();
            btnMoveToFav = new Button();
            btnRemoveFromFav = new Button();
            button1 = new Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, rangListToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1399, 40);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(120, 36);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // rangListToolStripMenuItem
            // 
            rangListToolStripMenuItem.Name = "rangListToolStripMenuItem";
            rangListToolStripMenuItem.Size = new Size(125, 36);
            rangListToolStripMenuItem.Text = "Rang list";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F);
            label1.Location = new Point(39, 110);
            label1.Name = "label1";
            label1.Size = new Size(343, 37);
            label1.TabIndex = 1;
            label1.Text = "Favorite national team:";
            // 
            // cbFavoriteNationalTeam
            // 
            cbFavoriteNationalTeam.FormattingEnabled = true;
            cbFavoriteNationalTeam.Location = new Point(450, 107);
            cbFavoriteNationalTeam.Name = "cbFavoriteNationalTeam";
            cbFavoriteNationalTeam.Size = new Size(515, 40);
            cbFavoriteNationalTeam.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 190);
            label2.Name = "label2";
            label2.Size = new Size(93, 32);
            label2.TabIndex = 3;
            label2.Text = "Players:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(554, 190);
            label3.Name = "label3";
            label3.Size = new Size(185, 32);
            label3.TabIndex = 4;
            label3.Text = "Favorite players:";
            // 
            // pnlPlayers
            // 
            pnlPlayers.Location = new Point(39, 243);
            pnlPlayers.Name = "pnlPlayers";
            pnlPlayers.Size = new Size(411, 517);
            pnlPlayers.TabIndex = 5;
            // 
            // pnlFavoritePlayers
            // 
            pnlFavoritePlayers.Location = new Point(554, 243);
            pnlFavoritePlayers.Name = "pnlFavoritePlayers";
            pnlFavoritePlayers.Size = new Size(411, 517);
            pnlFavoritePlayers.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1041, 190);
            label4.Name = "label4";
            label4.Size = new Size(83, 32);
            label4.TabIndex = 7;
            label4.Text = "Player:";
            // 
            // btnMoveToFav
            // 
            btnMoveToFav.Location = new Point(39, 797);
            btnMoveToFav.Name = "btnMoveToFav";
            btnMoveToFav.Size = new Size(411, 114);
            btnMoveToFav.TabIndex = 8;
            btnMoveToFav.Text = "Move to favorites";
            btnMoveToFav.UseVisualStyleBackColor = true;
            // 
            // btnRemoveFromFav
            // 
            btnRemoveFromFav.Location = new Point(554, 797);
            btnRemoveFromFav.Name = "btnRemoveFromFav";
            btnRemoveFromFav.Size = new Size(411, 114);
            btnRemoveFromFav.TabIndex = 9;
            btnRemoveFromFav.Text = "Remove from favorites";
            btnRemoveFromFav.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(1041, 797);
            button1.Name = "button1";
            button1.Size = new Size(267, 114);
            button1.TabIndex = 10;
            button1.Text = "Add picture";
            button1.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1399, 939);
            Controls.Add(button1);
            Controls.Add(btnRemoveFromFav);
            Controls.Add(btnMoveToFav);
            Controls.Add(label4);
            Controls.Add(pnlFavoritePlayers);
            Controls.Add(pnlPlayers);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cbFavoriteNationalTeam);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Main";
            Text = "Main";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem rangListToolStripMenuItem;
        private Label label1;
        private ComboBox cbFavoriteNationalTeam;
        private Label label2;
        private Label label3;
        private Panel pnlPlayers;
        private Panel pnlFavoritePlayers;
        private Label label4;
        private Button btnMoveToFav;
        private Button btnRemoveFromFav;
        private Button button1;
    }
}