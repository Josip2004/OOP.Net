using Dao.Enums;
using Dao.Models;
using Dao.Repositories;
using GavranovicJankovicJosipOOP.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IFileRepository _repo;
        private readonly IDataProvider _dataProvider;
        private List<Match> _matches;
        private List<Team> _teams;
        private string _savedTeamCode;
        private bool _isRestartingFromSettings = false;
        public MainWindow(IDataProvider dataProvider, IFileRepository fileRepository)
        {
            _dataProvider = dataProvider;
            _repo = fileRepository;

            string languageCode = _repo.GetStoredLanguage();

            if (!string.IsNullOrWhiteSpace(languageCode))
            {
                var culture = new CultureInfo(languageCode); 
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;
                CultureInfo.DefaultThreadCurrentCulture = culture;
                CultureInfo.DefaultThreadCurrentUICulture = culture;
            }
            InitializeComponent();
          

            try
            {
                string settingsLine = _repo.ReadFromFile("../../../../WinFormsApp/data/settings.txt");
                if (!string.IsNullOrWhiteSpace(settingsLine))
                {
                    var parts = settingsLine.Split('#');
                    if (parts.Length >= 4)
                    {
                        ApplyWindowSize(parts[3]);
                    }
                    if (parts.Length >= 1)
                    {
                        string gender = parts[0].ToLower();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            _savedTeamCode = _repo.GetCurrentTeam();
        }

        private void ApplyWindowSize(string resolution)
        {
            if (resolution.ToLower() == "fullscreen")
            {
                WindowStyle = WindowStyle.None;
                WindowState = WindowState.Maximized;
            }
            else
            {
                var parts = resolution.Split('x');

                if (parts.Length == 2 &&
                    int.TryParse(parts[0], out int width) &&
                    int.TryParse(parts[1], out int height))
                {
                    Width = width;
                    Height = height;
                }
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                string settingsLine = _repo.ReadFromFile("../../../../WinFormsApp/data/settings.txt");
                string gender = "men"; 

                if (!string.IsNullOrWhiteSpace(settingsLine))
                {
                    var parts = settingsLine.Split('#');
                    if (parts.Length >= 1)
                    {
                        gender = parts[0]; 
                    }
                }

                _teams = await _dataProvider.GetTeamsAsync(); 

                cbFavoriteTeam.DisplayMemberPath = "DisplayName";
                cbFavoriteTeam.SelectedValuePath = "Code";
                cbFavoriteTeam.ItemsSource = _teams;

                if (!string.IsNullOrWhiteSpace(_savedTeamCode))
                {
                    cbFavoriteTeam.SelectedValue = _savedTeamCode;
                }
                else
                {
                    cbFavoriteTeam.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private async void cbFavoriteTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbFavoriteTeam.SelectedItem is Team selectedTeam)
                {

                    string gender = _repo.GetStoredGender();
                    string language = _repo.GetStoredLanguage();
                    string resolution = "1200x900";

                    string settingsLine = _repo.ReadFromFile("../../../../WinFormsApp/data/settings.txt");


                    if (!string.IsNullOrWhiteSpace(settingsLine))
                    {
                        var parts = settingsLine.Split('#');
                        if (parts.Length >= 4)
                        {
                            resolution = parts[3];
                        }
                    }



                    string code = selectedTeam.Code;
                    string source = _repo.GetSource(); 

                    string content = $"{gender}#{language}#{code}#{resolution}#{source}";
                    _repo.SaveSettings(content);

                    if (code != null)
                    {
                        _matches = await _dataProvider.GetMatchesAsync(code);

                        var firstMatch = _matches.FirstOrDefault();

                        var teamSelected = firstMatch.HomeTeam.Country == selectedTeam.Country ?
                             firstMatch.HomeTeamStatistics : firstMatch.AwayTeamStatistics;

                        txtResult.Text = $"";

                        LoadOppComboBox(code);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadOppComboBox(string code)
        {
            var opps = new HashSet<Team>();

            foreach (var match in _matches)
            {
                if (match.HomeTeam.Code == code)
                {
                    opps.Add(new Team
                    {
                        Country = match.AwayTeam.Country,
                        RawCode = match.AwayTeam.Code,
                    });
                }
                else if (match.AwayTeam.Code == code)
                {
                    opps.Add(new Team
                    {
                        Country = match.HomeTeam.Country,
                        RawCode = match.HomeTeam.Code,
                    });
                }
            }

            cbOpponentTeam.DisplayMemberPath = "DisplayName";
            cbOpponentTeam.SelectedValuePath = "Code";
            cbOpponentTeam.ItemsSource = opps.ToList();
            cbOpponentTeam.SelectedIndex = -1;

        }

        private void btnFavoriteInfo_Click(object sender, RoutedEventArgs e)
        {
            if(cbFavoriteTeam.SelectedItem is Team selectedTeam)
            {
                var infoWindow = new TeamInfoWindow(selectedTeam, _matches);
                infoWindow.ShowDialog();
            }
        }

        private async void btnOppInfo_Click(object sender, RoutedEventArgs e)
        {
            if (cbOpponentTeam.SelectedItem is Team selectedTeam)
            {
                try
                {
                    var opponentMatches = await _dataProvider.GetMatchesAsync(selectedTeam.Code);

                    var infoWindow = new TeamInfoWindow(selectedTeam, opponentMatches);
                    infoWindow.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void cbOpponentTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbOpponentTeam.SelectedItem is Team selectedTeam &&
                    cbFavoriteTeam.SelectedItem is Team selectedFavorite)
                {
                    var match = _matches.FirstOrDefault(m =>
                    (m.HomeTeam.Code == selectedFavorite.Code && m.AwayTeam.Code == selectedTeam.Code) ||
                    (m.HomeTeam.Code == selectedTeam.Code && m.AwayTeam.Code == selectedFavorite.Code));

                    if (match != null)
                    {
                        long homeGoals = match.HomeTeam.Goals;
                        long awayGoals = match.AwayTeam.Goals;

                        txtResult.Text = $"{homeGoals} : {awayGoals}";

                        var favStats = match.HomeTeam.Code == selectedFavorite.Code
                            ? match.HomeTeamStatistics 
                            : match.AwayTeamStatistics;

                        var oppStats = match.HomeTeam.Code != selectedFavorite.Code
                           ? match.HomeTeamStatistics
                           : match.AwayTeamStatistics;

                        ArrangePlayers(favStats, oppStats, match);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ArrangePlayers(TeamStatistics favStats, TeamStatistics oppStats, Match match)
        {
            if (_repo == null)
            {
                MessageBox.Show("_repo is null!");
                return;
            }
            spGkFav.Children.Clear();
            spDefFav.Children.Clear();
            spMidFav.Children.Clear();
            spFwdFav.Children.Clear();

            spGkOpp.Children.Clear();
            spDefOpp.Children.Clear();
            spMidOpp.Children.Clear();
            spFwdOpp.Children.Clear();

            foreach (var player in favStats.StartingEleven)
            {
                var control = new PlayerControl(player, _repo, match);
                switch (player.Position)
                {
                    case Position.Goalie:
                        spGkFav.Children.Add(control);
                        break;
                    case Position.Defender:
                        spDefFav.Children.Add(control);
                        break;
                    case Position.Midfield:
                        spMidFav.Children.Add(control);
                        break;
                    case Position.Forward:
                        spFwdFav.Children.Add(control);
                        break;
                }
            }

            foreach (var player in oppStats.StartingEleven)
            {
                var control = new PlayerControl(player, _repo, match);
                switch (player.Position)
                {
                    case Position.Goalie:
                        spGkOpp.Children.Add(control);
                        break;
                    case Position.Defender:
                        spDefOpp.Children.Add(control);
                        break;
                    case Position.Midfield:
                        spMidOpp.Children.Add(control);
                        break;
                    case Position.Forward:
                        spFwdOpp.Children.Add(control);
                        break;
                }
            }

        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            var settingsWindow = new ChooseWindow(_repo);

            settingsWindow.SettingsApplied += () =>
            {
                _isRestartingFromSettings = true;
                var dataProvider = RepositoryFactory.GetRepo();
                var newMainWindow = new MainWindow(dataProvider, _repo);
                newMainWindow.Show();

                this.Close(); 
            };

            this.Hide();
            settingsWindow.ShowDialog();

            if (!settingsWindow.WasApplied)
            {
                this.Show();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_isRestartingFromSettings) return;

            var confirmWindow = new ExitWindow();
            confirmWindow.ShowDialog();

            if (!confirmWindow.IsConfirmed)
            {
                e.Cancel = true; 
            }
        }

        public void RefreshLanguage()
        {
            var currentDict = Application.Current.Resources.MergedDictionaries.FirstOrDefault();
            if (currentDict == null) return;

            this.Resources.MergedDictionaries.Clear();
            this.Resources.MergedDictionaries.Add(currentDict);

            this.InvalidateVisual();
            this.UpdateLayout();
        }
    }
}
