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
            menuStrip1 = new MenuStrip();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            rangListToolStripMenuItem = new ToolStripMenuItem();
            byNameToolStripMenuItem = new ToolStripMenuItem();
            yellowCardsToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            cbFavoriteNationalTeam = new ComboBox();
            tabPage1 = new TabPage();
            btnRemoveFromFav = new Button();
            btnMoveToFav = new Button();
            flpnlPlayers = new FlowLayoutPanel();
            btnAddPicture = new Button();
            playerControl = new PlayerControl();
            label2 = new Label();
            flpnlFavoritePlayers = new FlowLayoutPanel();
            label4 = new Label();
            label3 = new Label();
            tabControl1 = new TabControl();
            tabPage2 = new TabPage();
            btnPdfCards = new Button();
            btnShowPlayersCards = new Button();
            dgwCardsTable = new DataGridView();
            ImageColumn = new DataGridViewImageColumn();
            PlayerNameColumn = new DataGridViewTextBoxColumn();
            NumberOfOccurrencesColumn = new DataGridViewTextBoxColumn();
            tabPage3 = new TabPage();
            btnPdfGoals = new Button();
            btnShowPlayersGoals = new Button();
            dgwPlayersGoals = new DataGridView();
            dataGridViewImageColumn1 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            tabPage4 = new TabPage();
            btnPdfAttendance = new Button();
            button1 = new Button();
            dgwAttendance = new DataGridView();
            location = new DataGridViewTextBoxColumn();
            AttendanceNumber = new DataGridViewTextBoxColumn();
            HomeTeam = new DataGridViewTextBoxColumn();
            AwayTeam = new DataGridViewTextBoxColumn();
            menuStrip1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgwCardsTable).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgwPlayersGoals).BeginInit();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgwAttendance).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, rangListToolStripMenuItem });
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
            // 
            // rangListToolStripMenuItem
            // 
            rangListToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { byNameToolStripMenuItem, yellowCardsToolStripMenuItem });
            rangListToolStripMenuItem.Name = "rangListToolStripMenuItem";
            rangListToolStripMenuItem.Size = new Size(125, 36);
            rangListToolStripMenuItem.Text = "Rang list";
            // 
            // byNameToolStripMenuItem
            // 
            byNameToolStripMenuItem.Name = "byNameToolStripMenuItem";
            byNameToolStripMenuItem.Size = new Size(285, 44);
            byNameToolStripMenuItem.Text = "Scored Goals";
            // 
            // yellowCardsToolStripMenuItem
            // 
            yellowCardsToolStripMenuItem.Name = "yellowCardsToolStripMenuItem";
            yellowCardsToolStripMenuItem.Size = new Size(285, 44);
            yellowCardsToolStripMenuItem.Text = "Yellow Cards";
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
            cbFavoriteNationalTeam.SelectedIndexChanged += cbFavoriteNationalTeam_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnRemoveFromFav);
            tabPage1.Controls.Add(btnMoveToFav);
            tabPage1.Controls.Add(flpnlPlayers);
            tabPage1.Controls.Add(btnAddPicture);
            tabPage1.Controls.Add(playerControl);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(flpnlFavoritePlayers);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label3);
            tabPage1.Location = new Point(8, 46);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1799, 809);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Players";
            tabPage1.UseVisualStyleBackColor = true;
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(89, 25);
            label2.Name = "label2";
            label2.Size = new Size(93, 32);
            label2.TabIndex = 3;
            label2.Text = "Players:";
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1274, 25);
            label4.Name = "label4";
            label4.Size = new Size(83, 32);
            label4.TabIndex = 7;
            label4.Text = "Player:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(658, 25);
            label3.Name = "label3";
            label3.Size = new Size(185, 32);
            label3.TabIndex = 4;
            label3.Text = "Favorite players:";
            // 
            // tabControl1
            // 
            tabControl1.AccessibleName = "";
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(39, 171);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1815, 863);
            tabControl1.TabIndex = 14;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btnPdfCards);
            tabPage2.Controls.Add(btnShowPlayersCards);
            tabPage2.Controls.Add(dgwCardsTable);
            tabPage2.Location = new Point(8, 46);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1799, 809);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Ranking by yellow cards";
            tabPage2.UseVisualStyleBackColor = true;
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
            // tabPage3
            // 
            tabPage3.Controls.Add(btnPdfGoals);
            tabPage3.Controls.Add(btnShowPlayersGoals);
            tabPage3.Controls.Add(dgwPlayersGoals);
            tabPage3.Location = new Point(8, 46);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1799, 809);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Ranking by scored goals";
            tabPage3.UseVisualStyleBackColor = true;
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
            dgwPlayersGoals.Columns.AddRange(new DataGridViewColumn[] { dataGridViewImageColumn1, dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2 });
            dgwPlayersGoals.Location = new Point(111, 37);
            dgwPlayersGoals.Name = "dgwPlayersGoals";
            dgwPlayersGoals.RowHeadersWidth = 82;
            dgwPlayersGoals.Size = new Size(1581, 551);
            dgwPlayersGoals.TabIndex = 1;
            // 
            // dataGridViewImageColumn1
            // 
            dataGridViewImageColumn1.HeaderText = "Image";
            dataGridViewImageColumn1.MinimumWidth = 10;
            dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            dataGridViewImageColumn1.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn1.SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridViewImageColumn1.Width = 500;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Player Name";
            dataGridViewTextBoxColumn1.MinimumWidth = 10;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 500;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Number Of Occurrences";
            dataGridViewTextBoxColumn2.MinimumWidth = 10;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 500;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(btnPdfAttendance);
            tabPage4.Controls.Add(button1);
            tabPage4.Controls.Add(dgwAttendance);
            tabPage4.Location = new Point(8, 46);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(1799, 809);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Ranking by number of visitors";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnPdfAttendance
            // 
            btnPdfAttendance.Location = new Point(1001, 641);
            btnPdfAttendance.Name = "btnPdfAttendance";
            btnPdfAttendance.Size = new Size(246, 127);
            btnPdfAttendance.TabIndex = 2;
            btnPdfAttendance.Text = "Print PDF";
            btnPdfAttendance.UseVisualStyleBackColor = true;
            btnPdfAttendance.Click += btnPdfAttendance_Click;
            // 
            // button1
            // 
            button1.Location = new Point(341, 641);
            button1.Name = "button1";
            button1.Size = new Size(245, 127);
            button1.TabIndex = 1;
            button1.Text = "Show Attendance";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dgwAttendance
            // 
            dgwAttendance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwAttendance.Columns.AddRange(new DataGridViewColumn[] { location, AttendanceNumber, HomeTeam, AwayTeam });
            dgwAttendance.Location = new Point(145, 48);
            dgwAttendance.Name = "dgwAttendance";
            dgwAttendance.RowHeadersWidth = 82;
            dgwAttendance.Size = new Size(1486, 558);
            dgwAttendance.TabIndex = 0;
            // 
            // location
            // 
            location.HeaderText = "Location";
            location.MinimumWidth = 10;
            location.Name = "location";
            location.Width = 350;
            // 
            // AttendanceNumber
            // 
            AttendanceNumber.HeaderText = "Attendance number";
            AttendanceNumber.MinimumWidth = 10;
            AttendanceNumber.Name = "AttendanceNumber";
            AttendanceNumber.Width = 350;
            // 
            // HomeTeam
            // 
            HomeTeam.HeaderText = "Home Team";
            HomeTeam.MinimumWidth = 10;
            HomeTeam.Name = "HomeTeam";
            HomeTeam.Width = 350;
            // 
            // AwayTeam
            // 
            AwayTeam.HeaderText = "Away Team";
            AwayTeam.MinimumWidth = 10;
            AwayTeam.Name = "AwayTeam";
            AwayTeam.Width = 350;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1970, 1062);
            Controls.Add(tabControl1);
            Controls.Add(cbFavoriteNationalTeam);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Main";
            FormClosing += MainForm_FormClosing;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgwCardsTable).EndInit();
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgwPlayersGoals).EndInit();
            tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgwAttendance).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem rangListToolStripMenuItem;
        private Label label1;
        private ComboBox cbFavoriteNationalTeam;
        private ToolStripMenuItem byNameToolStripMenuItem;
        private ToolStripMenuItem yellowCardsToolStripMenuItem;
        private TabPage tabPage1;
        private Button btnRemoveFromFav;
        private Button btnMoveToFav;
        private FlowLayoutPanel flpnlPlayers;
        private Button btnAddPicture;
        private PlayerControl playerControl;
        private Label label2;
        private FlowLayoutPanel flpnlFavoritePlayers;
        private Label label4;
        private Label label3;
        private TabControl tabControl1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private DataGridView dgwCardsTable;
        private Button btnShowPlayersCards;
        private DataGridViewTextBoxColumn PlayerNameColumn;
        private DataGridViewTextBoxColumn NumberOfOccurrencesColumn;
        private DataGridViewImageColumn ImageColumn;
        private Button btnShowPlayersGoals;
        private DataGridView dgwPlayersGoals;
        private DataGridViewImageColumn dataGridViewImageColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private Button button1;
        private DataGridView dgwAttendance;
        private DataGridViewTextBoxColumn location;
        private DataGridViewTextBoxColumn AttendanceNumber;
        private DataGridViewTextBoxColumn HomeTeam;
        private DataGridViewTextBoxColumn AwayTeam;
        private Button btnPdfAttendance;
        private Button btnPdfGoals;
        private Button btnPdfCards;
    }
}