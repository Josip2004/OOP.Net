using Dao.Models;
using Dao.Repositories;
using GavranovicJankovicJosipOOP.Models;
using System;
using System.Collections.Generic;
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
        private readonly IApiRepository _apiRepository;
        private List<Match> _matches;
        private List<Team> _teams;
        private string _savedTeamCode;
        public MainWindow(IApiRepository apiRepository, IFileRepository fileRepository)
        {
            InitializeComponent();
            _apiRepository = apiRepository;
            _repo = fileRepository;

            _savedTeamCode = _repo.GetCurrentTeam();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {

                _teams = await _apiRepository.GetTeamsAsync();

                cbFavoriteTeam.DisplayMemberPath = "DisplayName";
                cbFavoriteTeam.SelectedValuePath = "Code";
                cbFavoriteTeam.ItemsSource = _teams;

                cbFavoriteTeam.SelectedIndex = -1;

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
                    string code = selectedTeam.Code;

                    if (code != null)
                    {
                        _matches = await _apiRepository.GetMatchesAsync(code);

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
                    var opponentMatches = await _apiRepository.GetMatchesAsync(selectedTeam.Code);

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
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

      
    }
}
