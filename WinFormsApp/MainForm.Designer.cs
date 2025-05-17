namespace WinFormsApp
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip1 = new MenuStrip();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            lblFavoriteTeam = new Label();
            cbFavoriteNationalTeam = new ComboBox();
            tpPlayers = new TabPage();
            btnRemoveFromFav = new Button();
            btnMoveToFav = new Button();
            flpnlPlayers = new FlowLayoutPanel();
            btnAddPicture = new Button();
            playerControl = new PlayerControl();
            lblPlayers = new Label();
            flpnlFavoritePlayers = new FlowLayoutPanel();
            lblMainPlayer = new Label();
            lblFavoritePl = new Label();
            tabControl1 = new TabControl();
            tpRankingCards = new TabPage();
            btnPdfCards = new Button();
            btnShowPlayersCards = new Button();
            dgwCardsTable = new DataGridView();
            ImageColumn = new DataGridViewImageColumn();
            PlayerNameColumn = new DataGridViewTextBoxColumn();
            NumberOfOccurrencesColumn = new DataGridViewTextBoxColumn();
            tpRankingGoals = new TabPage();
            btnPdfGoals = new Button();
            btnShowPlayersGoals = new Button();
            dgwPlayersGoals = new DataGridView();
            ImageCol = new DataGridViewImageColumn();
            PlNameCol = new DataGridViewTextBoxColumn();
            NumOfOccurrencesCol = new DataGridViewTextBoxColumn();
            tpRankingVisitors = new TabPage();
            btnPdfAttendance = new Button();
            btnShowAttendance = new Button();
            dgwAttendance = new DataGridView();
            locationCol = new DataGridViewTextBoxColumn();
            AttendanceNumberCol = new DataGridViewTextBoxColumn();
            HomeTeamCol = new DataGridViewTextBoxColumn();
            AwayTeamCol = new DataGridViewTextBoxColumn();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            printPreviewDialog1 = new PrintPreviewDialog();
            menuStrip1.SuspendLayout();
            tpPlayers.SuspendLayout();
            tabControl1.SuspendLayout();
            tpRankingCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgwCardsTable).BeginInit();
            tpRankingGoals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgwPlayersGoals).BeginInit();
            tpRankingVisitors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgwAttendance).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1970, 40);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(120, 36);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // lblFavoriteTeam
            // 
            lblFavoriteTeam.AutoSize = true;
            lblFavoriteTeam.Font = new Font("Microsoft Sans Serif", 12F);
            lblFavoriteTeam.Location = new Point(39, 110);
            lblFavoriteTeam.Name = "lblFavoriteTeam";
            lblFavoriteTeam.Size = new Size(343, 37);
            lblFavoriteTeam.TabIndex = 1;
            lblFavoriteTeam.Text = "Favorite national team:";
            // 
            // cbFavoriteNationalTeam
            // 
            cbFavoriteNationalTeam.FormattingEnabled = true;
            cbFavoriteNationalTeam.Location = new Point(450, 107);
            cbFavoriteNationalTeam.Name = "cbFavoriteNationalTeam";
            cbFavoriteNationalTeam.Size = new Size(515, 40);
            cbFavoriteNationalTeam.TabIndex = 2;
            cbFavoriteNationalTeam.SelectedIndexChanged += cbFavoriteNationalTeam_SelectedIndexChanged;
            // 
            // tpPlayers
            // 
            tpPlayers.Controls.Add(btnRemoveFromFav);
            tpPlayers.Controls.Add(btnMoveToFav);
            tpPlayers.Controls.Add(flpnlPlayers);
            tpPlayers.Controls.Add(btnAddPicture);
            tpPlayers.Controls.Add(playerControl);
            tpPlayers.Controls.Add(lblPlayers);
            tpPlayers.Controls.Add(flpnlFavoritePlayers);
            tpPlayers.Controls.Add(lblMainPlayer);
            tpPlayers.Controls.Add(lblFavoritePl);
            tpPlayers.Location = new Point(8, 46);
            tpPlayers.Name = "tpPlayers";
            tpPlayers.Padding = new Padding(3);
            tpPlayers.Size = new Size(1799, 809);
            tpPlayers.TabIndex = 0;
            tpPlayers.Text = "Players";
            tpPlayers.UseVisualStyleBackColor = true;
            // 
            // btnRemoveFromFav
            // 
            btnRemoveFromFav.Location = new Point(692, 625);
            btnRemoveFromFav.Name = "btnRemoveFromFav";
            btnRemoveFromFav.Size = new Size(411, 114);
            btnRemoveFromFav.TabIndex = 9;
            btnRemoveFromFav.Text = "Remove from favorites";
            btnRemoveFromFav.UseVisualStyleBackColor = true;
            btnRemoveFromFav.Click += btnRemoveFromFav_Click;
            // 
            // btnMoveToFav
            // 
            btnMoveToFav.Location = new Point(126, 625);
            btnMoveToFav.Name = "btnMoveToFav";
            btnMoveToFav.Size = new Size(411, 114);
            btnMoveToFav.TabIndex = 8;
            btnMoveToFav.Text = "Move to favorites";
            btnMoveToFav.UseVisualStyleBackColor = true;
            btnMoveToFav.Click += btnMoveToFav_Click;
            // 
            // flpnlPlayers
            // 
            flpnlPlayers.AllowDrop = true;
            flpnlPlayers.AutoScroll = true;
            flpnlPlayers.BackColor = Color.LightBlue;
            flpnlPlayers.Location = new Point(98, 79);
            flpnlPlayers.Name = "flpnlPlayers";
            flpnlPlayers.Size = new Size(508, 517);
            flpnlPlayers.TabIndex = 11;
            flpnlPlayers.DragEnter += flpnlPlayers_DragEnter;
            // 
            // btnAddPicture
            // 
            btnAddPicture.Location = new Point(1323, 625);
            btnAddPicture.Name = "btnAddPicture";
            btnAddPicture.Size = new Size(267, 114);
            btnAddPicture.TabIndex = 10;
            btnAddPicture.Text = "Add picture";
            btnAddPicture.UseVisualStyleBackColor = true;
            btnAddPicture.Click += btnAddPicture_Click;
            // 
            // playerControl
            // 
            playerControl.Location = new Point(1226, 79);
            playerControl.Name = "playerControl";
            playerControl.Size = new Size(446, 517);
            playerControl.TabIndex = 13;
            // 
            // lblPlayers
            // 
            lblPlayers.AutoSize = true;
            lblPlayers.Location = new Point(89, 25);
            lblPlayers.Name = "lblPlayers";
            lblPlayers.Size = new Size(93, 32);
            lblPlayers.TabIndex = 3;
            lblPlayers.Text = "Players:";
            // 
            // flpnlFavoritePlayers
            // 
            flpnlFavoritePlayers.AllowDrop = true;
            flpnlFavoritePlayers.AutoScroll = true;
            flpnlFavoritePlayers.BackColor = Color.LightGreen;
            flpnlFavoritePlayers.Location = new Point(658, 79);
            flpnlFavoritePlayers.Name = "flpnlFavoritePlayers";
            flpnlFavoritePlayers.Size = new Size(508, 517);
            flpnlFavoritePlayers.TabIndex = 12;
            flpnlFavoritePlayers.DragDrop += flpnlPlayers_DragDrop;
            flpnlFavoritePlayers.DragEnter += flpnlPlayers_DragEnter;
            // 
            // lblMainPlayer
            // 
            lblMainPlayer.AutoSize = true;
            lblMainPlayer.Location = new Point(1274, 25);
            lblMainPlayer.Name = "lblMainPlayer";
            lblMainPlayer.Size = new Size(83, 32);
            lblMainPlayer.TabIndex = 7;
            lblMainPlayer.Text = "Player:";
            // 
            // lblFavoritePl
            // 
            lblFavoritePl.AutoSize = true;
            lblFavoritePl.Location = new Point(658, 25);
            lblFavoritePl.Name = "lblFavoritePl";
            lblFavoritePl.Size = new Size(185, 32);
            lblFavoritePl.TabIndex = 4;
            lblFavoritePl.Text = "Favorite players:";
            // 
            // tabControl1
            // 
            tabControl1.AccessibleName = "";
            tabControl1.Controls.Add(tpPlayers);
            tabControl1.Controls.Add(tpRankingCards);
            tabControl1.Controls.Add(tpRankingGoals);
            tabControl1.Controls.Add(tpRankingVisitors);
            tabControl1.Location = new Point(39, 171);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1815, 863);
            tabControl1.TabIndex = 14;
            // 
            // tpRankingCards
            // 
            tpRankingCards.Controls.Add(btnPdfCards);
            tpRankingCards.Controls.Add(btnShowPlayersCards);
            tpRankingCards.Controls.Add(dgwCardsTable);
            tpRankingCards.Location = new Point(8, 46);
            tpRankingCards.Name = "tpRankingCards";
            tpRankingCards.Padding = new Padding(3);
            tpRankingCards.Size = new Size(1799, 809);
            tpRankingCards.TabIndex = 1;
            tpRankingCards.Text = "Ranking by yellow cards";
            tpRankingCards.UseVisualStyleBackColor = true;
            // 
            // btnPdfCards
            // 
            btnPdfCards.Location = new Point(969, 628);
            btnPdfCards.Name = "btnPdfCards";
            btnPdfCards.Size = new Size(257, 140);
            btnPdfCards.TabIndex = 2;
            btnPdfCards.Text = "Print to PDF";
            btnPdfCards.UseVisualStyleBackColor = true;
            btnPdfCards.Click += btnPdfCards_Click;
            // 
            // btnShowPlayersCards
            // 
            btnShowPlayersCards.Location = new Point(311, 628);
            btnShowPlayersCards.Name = "btnShowPlayersCards";
            btnShowPlayersCards.Size = new Size(267, 140);
            btnShowPlayersCards.TabIndex = 1;
            btnShowPlayersCards.Text = "Show players";
            btnShowPlayersCards.UseVisualStyleBackColor = true;
            btnShowPlayersCards.Click += btnShowPlayersCards_Click;
            // 
            // dgwCardsTable
            // 
            dgwCardsTable.BackgroundColor = SystemColors.ControlLight;
            dgwCardsTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwCardsTable.Columns.AddRange(new DataGridViewColumn[] { ImageColumn, PlayerNameColumn, NumberOfOccurrencesColumn });
            dgwCardsTable.Location = new Point(101, 30);
            dgwCardsTable.Name = "dgwCardsTable";
            dgwCardsTable.RowHeadersWidth = 82;
            dgwCardsTable.Size = new Size(1581, 551);
            dgwCardsTable.TabIndex = 0;
            // 
            // ImageColumn
            // 
            ImageColumn.HeaderText = "Image";
            ImageColumn.MinimumWidth = 10;
            ImageColumn.Name = "ImageColumn";
            ImageColumn.Resizable = DataGridViewTriState.True;
            ImageColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            ImageColumn.Width = 500;
            // 
            // PlayerNameColumn
            // 
            PlayerNameColumn.HeaderText = "Player Name";
            PlayerNameColumn.MinimumWidth = 10;
            PlayerNameColumn.Name = "PlayerNameColumn";
            PlayerNameColumn.Width = 500;
            // 
            // NumberOfOccurrencesColumn
            // 
            NumberOfOccurrencesColumn.HeaderText = "Number Of Occurrences";
            NumberOfOccurrencesColumn.MinimumWidth = 10;
            NumberOfOccurrencesColumn.Name = "NumberOfOccurrencesColumn";
            NumberOfOccurrencesColumn.Width = 500;
            // 
            // tpRankingGoals
            // 
            tpRankingGoals.Controls.Add(btnPdfGoals);
            tpRankingGoals.Controls.Add(btnShowPlayersGoals);
            tpRankingGoals.Controls.Add(dgwPlayersGoals);
            tpRankingGoals.Location = new Point(8, 46);
            tpRankingGoals.Name = "tpRankingGoals";
            tpRankingGoals.Size = new Size(1799, 809);
            tpRankingGoals.TabIndex = 2;
            tpRankingGoals.Text = "Ranking by scored goals";
            tpRankingGoals.UseVisualStyleBackColor = true;
            // 
            // btnPdfGoals
            // 
            btnPdfGoals.Location = new Point(988, 626);
            btnPdfGoals.Name = "btnPdfGoals";
            btnPdfGoals.Size = new Size(245, 140);
            btnPdfGoals.TabIndex = 3;
            btnPdfGoals.Text = "Print to PDF";
            btnPdfGoals.UseVisualStyleBackColor = true;
            btnPdfGoals.Click += btnPdfGoals_Click;
            // 
            // btnShowPlayersGoals
            // 
            btnShowPlayersGoals.Location = new Point(291, 626);
            btnShowPlayersGoals.Name = "btnShowPlayersGoals";
            btnShowPlayersGoals.Size = new Size(267, 140);
            btnShowPlayersGoals.TabIndex = 2;
            btnShowPlayersGoals.Text = "Show players";
            btnShowPlayersGoals.UseVisualStyleBackColor = true;
            btnShowPlayersGoals.Click += btnShowPlayersGoals_Click;
            // 
            // dgwPlayersGoals
            // 
            dgwPlayersGoals.BackgroundColor = SystemColors.ControlLight;
            dgwPlayersGoals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwPlayersGoals.Columns.AddRange(new DataGridViewColumn[] { ImageCol, PlNameCol, NumOfOccurrencesCol });
            dgwPlayersGoals.Location = new Point(111, 37);
            dgwPlayersGoals.Name = "dgwPlayersGoals";
            dgwPlayersGoals.RowHeadersWidth = 82;
            dgwPlayersGoals.Size = new Size(1581, 551);
            dgwPlayersGoals.TabIndex = 1;
            // 
            // ImageCol
            // 
            ImageCol.HeaderText = "Image";
            ImageCol.MinimumWidth = 10;
            ImageCol.Name = "ImageCol";
            ImageCol.Resizable = DataGridViewTriState.True;
            ImageCol.SortMode = DataGridViewColumnSortMode.Automatic;
            ImageCol.Width = 500;
            // 
            // PlNameCol
            // 
            PlNameCol.HeaderText = "Player Name";
            PlNameCol.MinimumWidth = 10;
            PlNameCol.Name = "PlNameCol";
            PlNameCol.Width = 500;
            // 
            // NumOfOccurrencesCol
            // 
            NumOfOccurrencesCol.HeaderText = "Number Of Occurrences";
            NumOfOccurrencesCol.MinimumWidth = 10;
            NumOfOccurrencesCol.Name = "NumOfOccurrencesCol";
            NumOfOccurrencesCol.Width = 500;
            // 
            // tpRankingVisitors
            // 
            tpRankingVisitors.Controls.Add(btnPdfAttendance);
            tpRankingVisitors.Controls.Add(btnShowAttendance);
            tpRankingVisitors.Controls.Add(dgwAttendance);
            tpRankingVisitors.Location = new Point(8, 46);
            tpRankingVisitors.Name = "tpRankingVisitors";
            tpRankingVisitors.Size = new Size(1799, 809);
            tpRankingVisitors.TabIndex = 3;
            tpRankingVisitors.Text = "Ranking by number of visitors";
            tpRankingVisitors.UseVisualStyleBackColor = true;
            // 
            // btnPdfAttendance
            // 
            btnPdfAttendance.Location = new Point(1001, 641);
            btnPdfAttendance.Name = "btnPdfAttendance";
            btnPdfAttendance.Size = new Size(246, 127);
            btnPdfAttendance.TabIndex = 2;
            btnPdfAttendance.Text = "Print to PDF";
            btnPdfAttendance.UseVisualStyleBackColor = true;
            btnPdfAttendance.Click += btnPdfAttendance_Click;
            // 
            // btnShowAttendance
            // 
            btnShowAttendance.Location = new Point(341, 641);
            btnShowAttendance.Name = "btnShowAttendance";
            btnShowAttendance.Size = new Size(245, 127);
            btnShowAttendance.TabIndex = 1;
            btnShowAttendance.Text = "Show attendance";
            btnShowAttendance.UseVisualStyleBackColor = true;
            btnShowAttendance.Click += button1_Click;
            // 
            // dgwAttendance
            // 
            dgwAttendance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwAttendance.Columns.AddRange(new DataGridViewColumn[] { locationCol, AttendanceNumberCol, HomeTeamCol, AwayTeamCol });
            dgwAttendance.Location = new Point(145, 48);
            dgwAttendance.Name = "dgwAttendance";
            dgwAttendance.RowHeadersWidth = 82;
            dgwAttendance.Size = new Size(1486, 558);
            dgwAttendance.TabIndex = 0;
            // 
            // locationCol
            // 
            locationCol.HeaderText = "Location";
            locationCol.MinimumWidth = 10;
            locationCol.Name = "locationCol";
            locationCol.Width = 350;
            // 
            // AttendanceNumberCol
            // 
            AttendanceNumberCol.HeaderText = "Attendance number";
            AttendanceNumberCol.MinimumWidth = 10;
            AttendanceNumberCol.Name = "AttendanceNumberCol";
            AttendanceNumberCol.Width = 350;
            // 
            // HomeTeamCol
            // 
            HomeTeamCol.HeaderText = "Home Team";
            HomeTeamCol.MinimumWidth = 10;
            HomeTeamCol.Name = "HomeTeamCol";
            HomeTeamCol.Width = 350;
            // 
            // AwayTeamCol
            // 
            AwayTeamCol.HeaderText = "Away Team";
            AwayTeamCol.MinimumWidth = 10;
            AwayTeamCol.Name = "AwayTeamCol";
            AwayTeamCol.Width = 350;
            // 
            // printDocument1
            // 
            printDocument1.PrintPage += printDocument1_PrintPage;
            // 
            // printPreviewDialog1
            // 
            printPreviewDialog1.AutoScrollMargin = new Size(0, 0);
            printPreviewDialog1.AutoScrollMinSize = new Size(0, 0);
            printPreviewDialog1.ClientSize = new Size(400, 300);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Enabled = true;
            printPreviewDialog1.Icon = (Icon)resources.GetObject("printPreviewDialog1.Icon");
            printPreviewDialog1.Name = "printPreviewDialog1";
            printPreviewDialog1.Visible = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1970, 1062);
            Controls.Add(tabControl1);
            Controls.Add(cbFavoriteNationalTeam);
            Controls.Add(lblFavoriteTeam);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main";
            FormClosing += MainForm_FormClosing;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tpPlayers.ResumeLayout(false);
            tpPlayers.PerformLayout();
            tabControl1.ResumeLayout(false);
            tpRankingCards.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgwCardsTable).EndInit();
            tpRankingGoals.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgwPlayersGoals).EndInit();
            tpRankingVisitors.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgwAttendance).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem rangListToolStripMenuItem;
        private Label lblFavoriteTeam;
        private ComboBox cbFavoriteNationalTeam;
        private ToolStripMenuItem byNameToolStripMenuItem;
        private ToolStripMenuItem yellowCardsToolStripMenuItem;
        private TabPage tpPlayers;
        private Button btnRemoveFromFav;
        private Button btnMoveToFav;
        private FlowLayoutPanel flpnlPlayers;
        private Button btnAddPicture;
        private PlayerControl playerControl;
        private Label lblPlayers;
        private FlowLayoutPanel flpnlFavoritePlayers;
        private Label lblMainPlayer;
        private Label lblFavoritePl;
        private TabControl tabControl1;
        private TabPage tpRankingCards;
        private TabPage tpRankingGoals;
        private TabPage tpRankingVisitors;
        private DataGridView dgwCardsTable;
        private Button btnShowPlayersCards;
        private DataGridViewTextBoxColumn PlayerNameColumn;
        private DataGridViewTextBoxColumn NumberOfOccurrencesColumn;
        private DataGridViewImageColumn ImageColumn;
        private Button btnShowPlayersGoals;
        private DataGridView dgwPlayersGoals;
        private Button btnShowAttendance;
        private DataGridView dgwAttendance;
        private Button btnPdfAttendance;
        private Button btnPdfGoals;
        private Button btnPdfCards;
        private DataGridViewImageColumn ImageCol;
        private DataGridViewTextBoxColumn PlNameCol;
        private DataGridViewTextBoxColumn NumOfOccurrencesCol;
        private DataGridViewTextBoxColumn locationCol;
        private DataGridViewTextBoxColumn AttendanceNumberCol;
        private DataGridViewTextBoxColumn HomeTeamCol;
        private DataGridViewTextBoxColumn AwayTeamCol;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private PrintPreviewDialog printPreviewDialog1;
    }
}