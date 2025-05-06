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

            Load += async (s, e) =>
            {
                await LoadTeams();
            };
        }

        private async Task LoadTeams()
        {
            try
            {
                _teams = await _apiRepository.GetTeamsAsync();

                _teams.Insert(0, new Team { Country = "", Code = "" });

                if (cbFavoriteNationalTeam.SelectedIndex == 0)
                {
                    cbFavoriteNationalTeam.DisplayMember = "";
                }

                cbFavoriteNationalTeam.DisplayMember = "Name";
                cbFavoriteNationalTeam.ValueMember = "Code";
                cbFavoriteNationalTeam.DataSource = _teams;

                cbFavoriteNationalTeam.SelectedIndex = -1;

               


                await LoadFavoriteTeam();

                string savedTeamCode = _fileRepository.GetCurrentTeam().Trim();
                if (!string.IsNullOrWhiteSpace(_savedTeamCode))
                {
                    var savedTeam = _teams.FirstOrDefault(t =>
                        t.Code.Trim().Equals(_savedTeamCode, StringComparison.OrdinalIgnoreCase));

                    if (savedTeam != null)
                    {
                        cbFavoriteNationalTeam.SelectedItem = savedTeam;
                    }
                   
                }
                cbFavoriteNationalTeam.SelectedIndexChanged += cbFavoriteNationalTeam_SelectedIndexChanged;


                await LoadFavoritePlayers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju timova: " + ex.Message);
            }
        }

        private async Task LoadFavoriteTeam()
        {
            try
            {
                string savedTeamCode = _fileRepository.GetCurrentTeam().Trim();

                if (!string.IsNullOrWhiteSpace(savedTeamCode))
                {
                    var savedTeam = _teams.FirstOrDefault(t =>
                        t.Code.Trim().Equals(savedTeamCode.Trim(), StringComparison.OrdinalIgnoreCase));

                    if (savedTeam != null)
                    {
                        cbFavoriteNationalTeam.SelectedItem = savedTeam;
                    }
                   
                }
                else
                {
                    cbFavoriteNationalTeam.SelectedIndex = 0; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju omiljenog tima: " + ex.Message);
            }
        }




        private async Task LoadFavoritePlayers()
        {
            try
            {
                var favoritePlayers = _fileRepository.GetFavoritePlayersList();
                flpnlFavoritePlayers.Controls.Clear();

                foreach (var playerName in favoritePlayers)
                {
                    var player = new Label { Text = playerName, AutoSize = true };
                    var panel = new Panel
                    {
                        Width = flpnlFavoritePlayers.Width - 15,
                        Height = 30,
                        BackColor = Color.Gainsboro,
                        Margin = new Padding(5),
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    panel.Controls.Add(player);

                    panel.Tag = new PlayerWithImage
                    {
                        Player = new Player { Name = playerName },
                        ImagePath = $"Images/{playerName}.jpg"
                    };

                    panel.MouseClick += PlayerPanel_Click;
                    panel.MouseMove += PlayerPanel_MouseMove;

                    flpnlFavoritePlayers.Controls.Add(panel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju omiljenih igrača: " + ex.Message);
            }
        }


        private async void cbFavoriteNationalTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
     

            if (cbFavoriteNationalTeam.SelectedItem is Team selectedTeam)
            {
                string gender = _fileRepository.GetStoredGender();
                string language = _fileRepository.GetStoredLanguage();
                string teamCode = selectedTeam.Code;

                _fileRepository.SaveSettings(@"../../../data/settings.txt", $"{gender}#{language}#{teamCode}");

                flpnlPlayers.Controls.Clear();
                flpnlFavoritePlayers.Controls.Clear();

                if (string.IsNullOrWhiteSpace(selectedTeam.Code))
                {
                    return;
                }

                _matches = await _apiRepository.GetMatchesAsync(selectedTeam.Code);

                if (_matches == null)
                {
                    MessageBox.Show($"There are no matches for the selected team...");
                    return;
                }

                var firstMatch = _matches.FirstOrDefault();

                if (firstMatch == null)
                {
                    MessageBox.Show($"There is no match for this team...");
                    return;
                }

                var teamSelected = firstMatch.HomeTeam.Country == selectedTeam.Country ?
                    firstMatch.HomeTeamStatistics : firstMatch.AwayTeamStatistics;

                var players = teamSelected.StartingEleven.Concat(teamSelected.Substitutes).ToList();

                flpnlPlayers.VerticalScroll.Visible = true;
                flpnlPlayers.VerticalScroll.Enabled = true;

                foreach (var p in players)
                {
                    Label lbl = new Label();
                    lbl.Text = p.ToString();
                    lbl.AutoSize = true;
                    lbl.Margin = new Padding(5);

                    Panel playerPanel = new Panel();
                    playerPanel.Width = flpnlPlayers.Width - 15;
                    playerPanel.Height = 30;
                    playerPanel.BackColor = Color.Gainsboro;
                    playerPanel.Margin = new Padding(5);
                    playerPanel.BorderStyle = BorderStyle.FixedSingle;

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
                        playerControl.LoadPlayer(player);

                        if (_fileRepository.ImageExists(player.Player.Name)) 
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
                    MessageBox.Show("Možete imati maksimalno 3 omiljena igrača.");
                    return;
                }

                ctrl.Parent.Controls.Remove(ctrl);

                panel.Controls.Add(ctrl);

                Player player = ctrl.Tag as Player;

                if (panel == flpnlFavoritePlayers)
                {
                    if (player != null && !favoritePlayers.Contains(player))
                    {
                        favoritePlayers.Add(player);  
                    }
                }
                else if (ctrl.Parent == flpnlFavoritePlayers)
                {
                    if (player != null)
                    {
                        favoritePlayers.Remove(player);  
                    }
                }

                _fileRepository.SaveFavoritePlayers(favoritePlayers.Select(player => player.Name).ToList());
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
                var favoritePlayers = new List<string>();

                foreach (var control in flpnlFavoritePlayers.Controls)
                {
                    if (control is Panel panel && panel.Tag is PlayerWithImage playerWithImage)
                    {
                        favoritePlayers.Add(playerWithImage.Player.Name);  
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
                string playerName = "modric"; 

                string correctedPath = selectedImagePath.Replace(@"\", @"\\");


                string line = $"{playerName}|{correctedPath}";
                _fileRepository.AppendToFile("../../../data/images.txt", line);

                MessageBox.Show(openFileDialog.FileName);

                var lines = File.ReadAllLines("../../../data/images.txt");
                foreach (var lin in lines)
                {
                    MessageBox.Show(lin);
                }

                MessageBox.Show("Slika koju treba stavit:" +  selectedImagePath);
                playerControl.SetImage(selectedImagePath);

                MessageBox.Show("Putanja slike je spremljena u 'images.txt'.", "Potvrda", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                dgwCardsTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgwCardsTable.RowTemplate.Height = 60;

            }

            var sorted = yellowCards.OrderByDescending(x => x.Value);

            foreach (var e in sorted)
            {
                string playerName = e.Key;
                int numberOfCards = e.Value;

                string imagePath = $"Images/{playerName}.jpg";
                System.Drawing.Image img = File.Exists(imagePath) ?
                    System.Drawing.Image.FromFile(imagePath) : System.Drawing.Image.FromFile(@"Images/DefaultImage.jpg");

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
            .Any(r => r.Cells[1].Value != null && r.Cells[1].Value.ToString().Equals(playerName, StringComparison.OrdinalIgnoreCase));

                if (!playerAlreadyAdded)
                {
                    string imagePath = $"Images/{playerName}.jpg";
                    System.Drawing.Image img = File.Exists(imagePath) ?
                        System.Drawing.Image.FromFile(imagePath) : System.Drawing.Image.FromFile(@"Images/DefaultImage.jpg");

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

        private void btnPdfAttendance_Click(object sender, EventArgs e)
        {
           // ExportDataGridViewToPdf(dgwAttendance);
        }

        private void btnPdfGoals_Click(object sender, EventArgs e)
        {
            //ExportDataGridViewToPdf(dgwPlayersGoals);
        }

        private void btnPdfCards_Click(object sender, EventArgs e)
        {
           // ExportDataGridViewToPdf(dgwCardsTable);
        }

        private async void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            try
            {
                string gender = _fileRepository.GetStoredGender();
                string language = _fileRepository.GetStoredLanguage();
                string teamCode = cbFavoriteNationalTeam.SelectedValue?.ToString() ?? "";

                string settingsContent = $"{gender}#{language}#{teamCode}";
                _fileRepository.SaveSettings("../../../data/settings.txt", settingsContent);

                var favoritePlayerNames = flpnlFavoritePlayers.Controls.Cast<Control>()
                .Where(p => p is Panel && p.Controls.OfType<Label>().Any()) 
                .Select(p => p.Controls.OfType<Label>().FirstOrDefault()?.Text) 
                .Where(name => !string.IsNullOrWhiteSpace(name)) 
                .ToList();

                if (favoritePlayerNames.Count > 0)
                {
                    _fileRepository.SaveFavoritePlayers(favoritePlayerNames);
                }
                else
                {
                    MessageBox.Show("No favorite players to save.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while saving on close: " + ex.Message);
            }
        }



    }
}
