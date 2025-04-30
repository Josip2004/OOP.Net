using Dao.Models;
using Dao.Repositories;
using GavranovicJankovicJosipOOP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        private readonly IApiRepository _apiRepository;
        private readonly IFileRepository _fileRepository;
        private List<Team> _teams;
        private List<Panel> _selectedPlayers = new();

        public MainForm(IApiRepository apiRepository, IFileRepository fileRepository)
        {
            InitializeComponent();
            _apiRepository = apiRepository;
            _fileRepository = fileRepository;

            Load += async (s, e) => await LoadTeams();

            flpnlPlayers.DragEnter += flpnlPlayers_DragEnter;
            flpnlFavoritePlayers.DragEnter += flpnlPlayers_DragEnter;

            flpnlPlayers.DragDrop += flpnlPlayers_DragDrop;
            flpnlFavoritePlayers.DragDrop += flpnlPlayers_DragDrop;


        }

        private async Task LoadTeams()
        {
            try
            {
                _teams = await _apiRepository.GetTeamsAsync();
                cbFavoriteNationalTeam.DataSource = _teams;

                cbFavoriteNationalTeam.SelectedIndexChanged += cbFavoriteNationalTeam_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading teams: " + ex.Message);
                Console.WriteLine("Error loading teams: " + ex.Message);
            }
        }

        private async void cbFavoriteNationalTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFavoriteNationalTeam.SelectedItem is Team selectedTeam)
            {
                flpnlPlayers.Controls.Clear();
                flpnlFavoritePlayers.Controls.Clear();

                if (string.IsNullOrWhiteSpace(selectedTeam.Code))
                {
                    MessageBox.Show("Team code is empty or null.");
                    return;
                }


                List<Match> matches = await _apiRepository.GetMatchesAsync(selectedTeam.Code);

                if (matches == null)
                {
                    MessageBox.Show($"There are no matches for the selected team...");
                    return;
                }

                var firstMatch = matches.FirstOrDefault();

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
                if (ctrl.Parent != panel)
                {
                    ctrl.Parent.Controls.Remove(ctrl);
                    panel.Controls.Add(ctrl);
                }
            }
        }


        private void btnMoveToFav_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedPlayers.Count > 0)
                {
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
                    foreach(var player in _selectedPlayers)
                    {
                        if(player != flpnlPlayers)
                        {
                            player.Parent.Controls.Remove(player);
                            flpnlPlayers.Controls.Add(player);
                        }
                        player.BackColor = Color.Gainsboro;
                    }
                    _selectedPlayers.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred " + ex.Message);
                return;
            }
        }
    }
}
