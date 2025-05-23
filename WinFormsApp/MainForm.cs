using Dao.Enums;
using Dao.Models;
using Dao.Repositories;
using GavranovicJankovicJosipOOP.Models;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Font;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime;
using WinFormsApp.Properties;
using iText.IO.Image;


namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        private readonly IApiRepository _apiRepository;
        private readonly IFileRepository _fileRepository;
        private List<Team> _teams;
        private List<Match> _matches;
        private List<Panel> _selectedPlayers = new();
        private string _savedTeamCode;
        private string _saveFavoriteTeam;
        private List<Player> favoritePlayers = new List<Player>();

        public MainForm(IApiRepository apiRepository, IFileRepository fileRepository)
        {
            InitializeComponent();
            _apiRepository = apiRepository;
            _fileRepository = fileRepository;

            _savedTeamCode = _fileRepository.GetCurrentTeam();

            flpnlPlayers.DragEnter += flpnlPlayers_DragEnter;
            flpnlFavoritePlayers.DragEnter += flpnlPlayers_DragEnter;

            flpnlPlayers.DragDrop += flpnlPlayers_DragDrop;
            flpnlFavoritePlayers.DragDrop += flpnlPlayers_DragDrop;

            ApplyLocalization();

            Load += async (s, e) =>
            {
                playerControl.ApplyLocalization();
                await LoadTeams();
            };
        }

        private async Task LoadTeams()
        {
            try
            {
                _teams = await _apiRepository.GetTeamsAsync();

                cbFavoriteNationalTeam.DisplayMember = "Name";
                cbFavoriteNationalTeam.ValueMember = "Code";
                cbFavoriteNationalTeam.DataSource = _teams;


                if (!string.IsNullOrWhiteSpace(_savedTeamCode))
                {
                    var savedTeam = _teams.FirstOrDefault(t =>
                        t.Code.Trim().Equals(_savedTeamCode.Trim(), StringComparison.OrdinalIgnoreCase));

                    if (savedTeam != null)
                    {
                        cbFavoriteNationalTeam.SelectedItem = savedTeam;

                        await Task.Delay(50); 
                        Application.DoEvents();

                        await LoadPlayersByTeam(savedTeam);
                    }
                }
                else
                {
                    cbFavoriteNationalTeam.SelectedIndex = 0;
                }

                cbFavoriteNationalTeam.SelectedIndexChanged += async (s, e) =>
                {
                    if (cbFavoriteNationalTeam.SelectedItem is Team team)
                        await LoadPlayersByTeam(team);
                };

                await LoadFavoritePlayers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju timova: " + ex.Message);
            }
        }

        private async Task LoadPlayersByTeam(Team selectedTeam)
        {
            if (selectedTeam == null || string.IsNullOrWhiteSpace(selectedTeam.Code)) return;


            flpnlPlayers.Controls.Clear();
            flpnlFavoritePlayers.Controls.Clear();

            _matches = await _apiRepository.GetMatchesAsync(selectedTeam.Code);

            if (_matches == null || !_matches.Any())
            {
                MessageBox.Show($"There are no matches for the selected team...");
                return;
            }

            var firstMatch = _matches.First();

            var teamStats = firstMatch.HomeTeam.Country == selectedTeam.Country
                ? firstMatch.HomeTeamStatistics
                : firstMatch.AwayTeamStatistics;

            var players = teamStats.StartingEleven.Concat(teamStats.Substitutes).ToList();

            foreach (var p in players)
            {
                var label = new Label { Text = p.Name, AutoSize = true, Margin = new Padding(5) };

                var panel = new Panel
                {
                    Width = flpnlPlayers.Width - 15,
                    Height = 30,
                    BackColor = Color.Gainsboro,
                    Margin = new Padding(5),
                    BorderStyle = BorderStyle.FixedSingle
                };

                panel.Controls.Add(label);
                panel.Tag = new PlayerWithImage
                {
                    Player = p,
                    ImagePath = $"Images/{p.Name}.jpg"
                };

                label.MouseClick += PlayerPanel_Click;
                panel.MouseClick += PlayerPanel_Click;
                label.MouseMove += PlayerPanel_MouseMove;
                panel.MouseMove += PlayerPanel_MouseMove;

                flpnlPlayers.Controls.Add(panel);
            }
        }

        private void ApplyLocalization()
        {
            lblFavoritePl.Text = Strings.lblFavoritePl;
            lblFavoriteTeam.Text = Strings.lblFavoriteTeam;
            lblMainPlayer.Text = Strings.lblMainPlayer;
            lblPlayers.Text = Strings.lblPlayers;

            btnAddPicture.Text = Strings.btnAddPicture;
            btnMoveToFav.Text = Strings.btnMoveToFav;
            btnRemoveFromFav.Text = Strings.btnRemoveFromFav;
            btnShowAttendance.Text = Strings.btnShowAttendance;
            btnShowPlayersGoals.Text = Strings.btnShowPlayersGoals;
            btnShowPlayersCards.Text = Strings.btnShowPlayersCards;
            btnPdfCards.Text = Strings.btnPdfCards;
            btnPdfGoals.Text = Strings.btnPdfGoals;
            btnPdfAttendance.Text = Strings.btnPdfAttendance;

            tpRankingCards.Text = Strings.tpRankingCards;
            tpPlayers.Text = Strings.tpPlayers;
            tpRankingGoals.Text = Strings.tpRankingGoals;
            tpRankingVisitors.Text = Strings.tpRankingVisitors;

            dgwCardsTable.Columns[0].HeaderText = Strings.ImageColumn;
            dgwCardsTable.Columns[1].HeaderText = Strings.PlayerNameColumn;
            dgwCardsTable.Columns[2].HeaderText = Strings.NumberOfOccurrencesColumn;

            dgwPlayersGoals.Columns[0].HeaderText = Strings.ImageCol;
            dgwPlayersGoals.Columns[1].HeaderText = Strings.PlNameCol;
            dgwPlayersGoals.Columns[2].HeaderText = Strings.NumOfOccurrencesCol;

            dgwAttendance.Columns[0].HeaderText = Strings.locationCol;
            dgwAttendance.Columns[1].HeaderText = Strings.AttendanceNumberCol;
            dgwAttendance.Columns[2].HeaderText = Strings.HomeTeamCol;
            dgwAttendance.Columns[3].HeaderText = Strings.AwayTeamCol;

            settingsToolStripMenuItem.Text = Strings.settingsToolStripMenuItem;
        }

        private async Task LoadFavoritePlayers()
        {
            try
            {
                var favoritePlayers = _fileRepository.GetFavoritePlayersList();
                flpnlFavoritePlayers.Controls.Clear();

                foreach (var playerObj in favoritePlayers)
                {
                    var label = new Label { Text = playerObj.Name, AutoSize = true };
                    var panel = new Panel
                    {
                        Width = flpnlFavoritePlayers.Width - 15,
                        Height = 30,
                        BackColor = Color.Gainsboro,
                        Margin = new Padding(5),
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    panel.Controls.Add(label);

                    panel.Tag = new PlayerWithImage
                    {
                        Player = playerObj,
                        ImagePath = $"Images/{playerObj.Name}.jpg"
                    };

                    panel.MouseClick += PlayerPanel_Click;
                    panel.MouseMove += PlayerPanel_MouseMove;

                    flpnlFavoritePlayers.Controls.Add(panel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private async void cbFavoriteNationalTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFavoriteNationalTeam.SelectedItem is not Team selectedTeam)
                return;

            if (!string.IsNullOrWhiteSpace(_savedTeamCode))
            {
                if (!selectedTeam.Code.Equals(_savedTeamCode, StringComparison.OrdinalIgnoreCase))
                    return;

                _savedTeamCode = null;
            }

            string gender = _fileRepository.GetStoredGender();
            string language = _fileRepository.GetStoredLanguage();
            string teamCode = selectedTeam.Code;
            _fileRepository.SaveSettings($"{gender}#{language}#{teamCode}");

            flpnlPlayers.Controls.Clear();
            flpnlFavoritePlayers.Controls.Clear();

            if (string.IsNullOrWhiteSpace(selectedTeam.Code))
                return;

            _matches = await _apiRepository.GetMatchesAsync(selectedTeam.Code);

            if (_matches == null || !_matches.Any())
            {
                MessageBox.Show("There are no matches for the selected team...");
                return;
            }

            var firstMatch = _matches.First();
            var teamSelected = firstMatch.HomeTeam.Country == selectedTeam.Country
                ? firstMatch.HomeTeamStatistics
                : firstMatch.AwayTeamStatistics;

            var players = teamSelected.StartingEleven.Concat(teamSelected.Substitutes).ToList();

            flpnlPlayers.VerticalScroll.Visible = true;
            flpnlPlayers.VerticalScroll.Enabled = true;

            foreach (var p in players)
            {
                Label lbl = new Label
                {
                    Text = p.Name,
                    AutoSize = true,
                    Margin = new Padding(5)
                };

                Panel playerPanel = new Panel
                {
                    Width = flpnlPlayers.Width - 15,
                    Height = 30,
                    BackColor = Color.Gainsboro,
                    Margin = new Padding(5),
                    BorderStyle = BorderStyle.FixedSingle
                };

                p.Name = ExtractOnlyName(p.Name);

                playerPanel.Tag = new PlayerWithImage
                {
                    Player = p,
                    ImagePath = $"Images/{p.Name}.jpg"
                };

                Cursor = Cursors.Hand;

                lbl.MouseClick += PlayerPanel_Click;
                playerPanel.MouseClick += PlayerPanel_Click;

                lbl.MouseMove += PlayerPanel_MouseMove;
                playerPanel.MouseMove += PlayerPanel_MouseMove;

                playerPanel.Controls.Add(lbl);
                flpnlPlayers.Controls.Add(playerPanel);
            }
        }


        private string ExtractOnlyName(string name)
        {
            var parts = name.Split(' ');
            return parts.Length >= 2 ? $"{parts[0]} {parts[1]}" : name;
        }

        private void PlayerPanel_MouseMove(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Control ctrl = sender as Control;
                if (ctrl is Label && ctrl.Parent is Panel)
                    ctrl = ctrl.Parent;

                if (ctrl is Panel)
                    DoDragDrop(ctrl, DragDropEffects.Move);
            }
        }

        private void PlayerPanel_Click(object? sender, EventArgs e)
        {
            try
            {
                Panel clickedPanel = sender as Panel;

                if (clickedPanel == null && sender is Label lbl && lbl.Parent is Panel)
                    clickedPanel = lbl.Parent as Panel;

                if (clickedPanel != null)
                {
                    if (_selectedPlayers.Contains(clickedPanel))
                    {
                        _selectedPlayers.Remove(clickedPanel);
                        clickedPanel.BackColor = Color.Gainsboro;
                    }
                    else
                    {
                        _selectedPlayers.Add(clickedPanel);
                        clickedPanel.BackColor = Color.White;

                        PlayerWithImage player = clickedPanel.Tag as PlayerWithImage;

                        if (player != null)
                        {
                            bool isFavorite = flpnlFavoritePlayers.Controls
                                .OfType<Panel>()
                                .Select(p => p.Tag)
                                .OfType<PlayerWithImage>()
                                .Any(pwi => pwi.Player.Name == player.Player.Name);

                            playerControl.LoadPlayer(player, isFavorite);

                            string actualName = player.Player.Name;
                            if (_fileRepository.ImageExists(actualName))
                            {

                                string imagePath = _fileRepository.RetrieveImagePath(player.Player.Name);

                                if (File.Exists(imagePath))
                                {
                                    playerControl.SetImage(imagePath);
                                }

                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void flpnlPlayers_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Panel)))
                e.Effect = DragDropEffects.Move;
        }

        private void flpnlPlayers_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(typeof(Panel)) is Panel ctrl && sender is FlowLayoutPanel panel)
            {
                if (ctrl.Parent == panel)
                    return;

                if (panel == flpnlFavoritePlayers && flpnlFavoritePlayers.Controls.Count >= 3)
                {
                    MessageBox.Show("You can have a maximum of 3 favorite players.");
                    return;
                }

                ctrl.Parent.Controls.Remove(ctrl);
                panel.Controls.Add(ctrl);

                var favoritesToSave = new List<Player>();
                foreach (var control in flpnlFavoritePlayers.Controls)
                {
                    if (control is Panel p && p.Tag is PlayerWithImage pwi)
                    {
                        favoritesToSave.Add(pwi.Player);
                    }
                }

                _fileRepository.SaveFavoritePlayers(favoritesToSave);
            }
        }


        private void btnMoveToFav_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedPlayers.Count > 0)
                {
                    int numberOfFavorites = 3 - flpnlFavoritePlayers.Controls.Count;

                    if (_selectedPlayers.Count > numberOfFavorites)
                    {
                        MessageBox.Show("You can have a maximum of 3 favorite players.");
                        return;
                    }

                    foreach (var player in _selectedPlayers)
                    {
                        if (player != flpnlFavoritePlayers)
                        {
                            player.Parent.Controls.Remove(player);
                            flpnlFavoritePlayers.Controls.Add(player);
                        }
                        player.BackColor = Color.Gainsboro;
                    }



                    var favoritesToSave = new List<Player>();

                    foreach (var control in flpnlFavoritePlayers.Controls)
                    {
                        if (control is Panel panel && panel.Tag is PlayerWithImage pwi)
                        {
                            favoritesToSave.Add(pwi.Player);
                        }
                    }

                    _fileRepository.SaveFavoritePlayers(favoritesToSave);
                    _selectedPlayers.Clear();

                }
                else
                {
                    MessageBox.Show("Select at least one player");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred " + ex.Message);
                return;
            }
        }

        private void btnRemoveFromFav_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedPlayers.Count > 0)
                {
                    foreach (var player in _selectedPlayers)
                    {
                        if (player is Panel clickedPanel)
                        {
                            if (clickedPanel.Parent == flpnlFavoritePlayers)
                            {
                                clickedPanel.Parent.Controls.Remove(clickedPanel);
                                flpnlPlayers.Controls.Add(clickedPanel);
                            }
                        }
                    }

                    _selectedPlayers.Clear();

                    SaveFavoritePlayers();
                }
                else
                {
                    MessageBox.Show("Morate odabrati barem jednog igrača za uklanjanje.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri uklanjanju igrača: " + ex.Message);
            }
        }

        private void SaveFavoritePlayers()
        {
            try
            {
                var favoritePlayers = new List<Player>();

                foreach (var control in flpnlFavoritePlayers.Controls)
                {
                    if (control is Panel panel && panel.Tag is PlayerWithImage playerWithImage)
                    {
                        favoritePlayers.Add(playerWithImage.Player);
                    }
                }

                _fileRepository.SaveFavoritePlayers(favoritePlayers);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri spremanju omiljenih igrača: " + ex.Message);
            }
        }
        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedImagePath = openFileDialog.FileName;

                string playerName = ExtractOnlyName(playerControl.CurrentPlayer.Player.Name);

                string safeFileName = playerName.Replace(" ", "_") + ".jpg";

                string solutionRoot = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.FullName;
                string imagesFolder = Path.Combine(solutionRoot, "WpfApp", "bin", "Debug", "net8.0-windows", "Images");
                Directory.CreateDirectory(imagesFolder);

                string destinationPath = Path.Combine(imagesFolder, safeFileName);
                File.Copy(selectedImagePath, destinationPath, true);

                string relativePath = Path.Combine("Images", safeFileName);

                _fileRepository.AppendToFile("images.txt", $"{playerName}#{relativePath}");

                playerControl.SetImage(destinationPath);
            }
        }



        private void FillAndSortByCards()
        {
            if (_matches == null)
            {
                MessageBox.Show("There is no loaded matches");
                return;
            }

            string selectedTeam = cbFavoriteNationalTeam.SelectedItem?.ToString();

            if (selectedTeam == null)
            {
                MessageBox.Show("Not selected country");
                return;
            }

            selectedTeam = selectedTeam.Split('(')[0].Trim();

            dgwCardsTable.Rows.Clear();

            IDictionary<string, int> yellowCards = new Dictionary<string, int>();

            foreach (var match in _matches)
            {
                var allEvents = new List<TeamEvent>();

                if (match.HomeTeam.Country == selectedTeam && match.HomeTeamEvents != null)
                {
                    allEvents.AddRange(match.HomeTeamEvents
                        .Where(e => e.TypeOfEvent == TypeOfEvent.YellowCard));
                }

                if (match.AwayTeam.Country == selectedTeam && match.AwayTeamEvents != null)
                {
                    allEvents.AddRange(match.AwayTeamEvents
                        .Where(e => e.TypeOfEvent == TypeOfEvent.YellowCard));
                }

                foreach (var ev in allEvents)
                {
                    if (yellowCards.ContainsKey(ev.Player))
                    {
                        yellowCards[ev.Player]++;
                    }
                    else
                    {
                        yellowCards[ev.Player] = 1;
                    }
                }
            }

            dgwCardsTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgwCardsTable.RowTemplate.Height = 60;

            var sorted = yellowCards.OrderByDescending(x => x.Value);

            foreach (var e in sorted)
            {
                string playerName = e.Key;
                int numberOfCards = e.Value;

                string imagePath = _fileRepository.RetrieveImagePath(playerName);
                System.Drawing.Image img = File.Exists(imagePath)
                    ? System.Drawing.Image.FromFile(imagePath)
                    : System.Drawing.Image.FromFile(@"Images/DefaultImage.jpg");

                dgwCardsTable.Rows.Add(img, playerName, numberOfCards);
            }

        }

        private void FillAndSortByGoals()
        {
            if (_matches == null)
            {
                MessageBox.Show("There are no loaded matches.");
                return;
            }

            string selectedTeam = cbFavoriteNationalTeam.SelectedItem?.ToString();

            if (selectedTeam == null)
            {
                MessageBox.Show("Not selected country.");
                return;
            }

            selectedTeam = selectedTeam.Split('(')[0].Trim();

            dgwPlayersGoals.Rows.Clear();

            IDictionary<string, int> goalsScored = new Dictionary<string, int>();

            foreach (var match in _matches)
            {
                var allEvents = new List<TeamEvent>();

                if (match.HomeTeam.Country == selectedTeam && match.HomeTeamEvents != null)
                {
                    allEvents.AddRange(match.HomeTeamEvents
                        .Where(e => e.TypeOfEvent == TypeOfEvent.Goal));
                }

                if (match.AwayTeam.Country == selectedTeam && match.AwayTeamEvents != null)
                {
                    allEvents.AddRange(match.AwayTeamEvents
                        .Where(e => e.TypeOfEvent == TypeOfEvent.Goal));
                }

                foreach (var ev in allEvents)
                {
                    if (goalsScored.ContainsKey(ev.Player))
                    {
                        goalsScored[ev.Player]++;
                    }
                    else
                    {
                        goalsScored[ev.Player] = 1;
                    }
                }
            }

            dgwPlayersGoals.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgwPlayersGoals.RowTemplate.Height = 60;

            var sorted = goalsScored.OrderByDescending(x => x.Value);

            foreach (var e in sorted)
            {
                string playerName = e.Key;
                int numberOfGoals = e.Value;

                bool playerAlreadyAdded = dgwPlayersGoals.Rows.Cast<DataGridViewRow>()
                    .Any(r => r.Cells[1].Value != null &&
                              r.Cells[1].Value.ToString().Equals(playerName, StringComparison.OrdinalIgnoreCase));

                if (!playerAlreadyAdded)
                {
                    string imagePath = _fileRepository.RetrieveImagePath(playerName);
                    System.Drawing.Image img = File.Exists(imagePath)
                        ? System.Drawing.Image.FromFile(imagePath)
                        : System.Drawing.Image.FromFile(@"Images/DefaultImage.jpg");

                    dgwPlayersGoals.Rows.Add(img, playerName, numberOfGoals);
                }
            }
        }

        private void FillAttendance()
        {
            if (_matches == null)
            {
                MessageBox.Show("There is no loaded matches");
                return;
            }

            string selectedTeam = cbFavoriteNationalTeam.SelectedItem?.ToString();

            if (selectedTeam == null)
            {
                MessageBox.Show("Not selected country.");
                return;
            }

            selectedTeam = selectedTeam.Split('(')[0].Trim();

            dgwAttendance.Rows.Clear();

            var sortedMatches = _matches.OrderByDescending(x => x.Attendance).ToList();

            foreach (var matches in sortedMatches)
            {
                string location = matches.Location;
                long attendance = matches.Attendance;
                string homeTeam = matches.HomeTeam.Country;
                string awayTeam = matches.AwayTeam.Country;

                dgwAttendance.Rows.Add(location, attendance, homeTeam, awayTeam);

            }
        }

        private void btnShowPlayersCards_Click(object sender, EventArgs e)
        {
            FillAndSortByCards();
        }

        private void btnShowPlayersGoals_Click(object sender, EventArgs e)
        {
            FillAndSortByGoals();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FillAttendance();
        }



        private bool _shouldRestartMainForm = false;
        private bool _isSoftRestartFromSettings = false;

        public static bool IsRestarting = false;


        private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (_isSoftRestartFromSettings)
            {
                return;
            }

            ExitMessageBox exitMessage = new ExitMessageBox();
            var result = exitMessage.ShowDialog();

            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }


        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settingsForm = new Settings();

            bool shouldCloseThisForm = false;

            settingsForm.SettingsApplied += () =>
            {
                _isSoftRestartFromSettings = true;
                shouldCloseThisForm = true;
                this.Close();
            };

            this.Hide();
            settingsForm.ShowDialog();

            if (shouldCloseThisForm)
                return;

            this.Show();
        }

        private void DrawDataGridView(Graphics graphics, DataGridView grid, Rectangle marginBounds, ref int startRow)
        {
            int x = marginBounds.Left;
            int y = marginBounds.Top;
            int rowHeight = grid.RowTemplate.Height + 5;
            int columnWidth = 250;

            // Iscrtavanje zaglavlja
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                graphics.DrawString(
                    grid.Columns[i].HeaderText,
                    grid.Font,
                    Brushes.Black,
                    x + i * columnWidth,
                    y);
            }
            y += rowHeight;

            for (; startRow < grid.Rows.Count; startRow++)
            {
                var row = grid.Rows[startRow];
                if (row.IsNewRow) continue;

                for (int col = 0; col < grid.Columns.Count; col++)
                {
                    int cellX = x + col * columnWidth;
                    Rectangle cellBounds = new Rectangle(cellX, y, columnWidth, rowHeight);
                    var value = row.Cells[col].Value;

                    if (value is System.Drawing.Image img)
                    {
                        int imgSize = grid.RowTemplate.Height;
                        var imgRect = new Rectangle(cellX, y, imgSize, imgSize);
                        graphics.DrawImage(img, imgRect);
                    }
                    else
                    {
                        string text = value?.ToString() ?? "";
                        graphics.DrawString(
                            text,
                            grid.Font,
                            Brushes.Black,
                            cellX,
                            y);
                    }
                }

                y += rowHeight;
                if (y > marginBounds.Bottom)
                    break;
            }

            // Pomakni marginBounds.Y kako bi sljedeća stranica nastavila odavde
            marginBounds.Y = y;
        }

        private enum PrintTarget
        {
            Cards,
            Goals,
            Attendance
        }

        private PrintTarget currentTarget;
        private int startRow = 0;

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            switch (currentTarget)
            {
                case PrintTarget.Cards:
                    DrawDataGridView(e.Graphics, dgwCardsTable, e.MarginBounds, ref startRow);
                    e.HasMorePages = startRow < dgwCardsTable.Rows.Count;
                    break;

                case PrintTarget.Goals:
                    DrawDataGridView(e.Graphics, dgwPlayersGoals, e.MarginBounds, ref startRow);
                    e.HasMorePages = startRow < dgwPlayersGoals.Rows.Count;
                    break;

                case PrintTarget.Attendance:
                    DrawDataGridView(e.Graphics, dgwAttendance, e.MarginBounds, ref startRow);
                    e.HasMorePages = startRow < dgwAttendance.Rows.Count;
                    break;
            }

            if (!e.HasMorePages)
            {
                startRow = 0; 
            }
        }
        private void btnPdfAttendance_Click(object sender, EventArgs e)
        {
            currentTarget = PrintTarget.Attendance;
            startRow = 0;
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void btnPdfGoals_Click(object sender, EventArgs e)
        {
            currentTarget = PrintTarget.Goals;
            startRow = 0;
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void btnPdfCards_Click(object sender, EventArgs e)
        {
            currentTarget = PrintTarget.Cards;
            startRow = 0;
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
    }
}
