using Dao.Models;
using GavranovicJankovicJosipOOP.Models;
using MyMatch = GavranovicJankovicJosipOOP.Models.Match;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for TeamInfoWindow.xaml
    /// </summary>
    public partial class TeamInfoWindow : Window
    {
        public TeamInfoWindow(Team team, List<MyMatch> matches)
        {
            InitializeComponent();

            var animation = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.5));
            this.BeginAnimation(Window.OpacityProperty, animation);

            var teamMatches = matches.Where(t => t.HomeTeam.Code == team.Code || t.AwayTeam.Code == team.Code);

            int goalsScored = 0, goalsConceded = 0;
            int wins = 0, losses = 0, draws = 0;

            foreach (var match in teamMatches)
            {
                bool isHome = match.HomeTeam.Code == team.Code;
                var favTeamGoals = isHome ? match.HomeTeam.Goals : match.AwayTeam.Goals;
                var oppTeamGoals = isHome ? match.AwayTeam.Goals : match.HomeTeam.Goals;

                goalsScored += (int) favTeamGoals;
                goalsConceded += (int) oppTeamGoals;

                if (favTeamGoals > oppTeamGoals)
                    wins++;
                else if (favTeamGoals < oppTeamGoals)
                    losses++;
                else
                    draws++;
            }

            txtTeamName.Text += team.Country;
            txtFifaCode.Text += team.Code;
            txtPlayed.Text += teamMatches.Count();
            txtDraws.Text += draws;
            txtWins.Text += wins;
            txtLosses.Text += losses;
            txtGoalsScored.Text += goalsScored.ToString();
            txtGoalsConceded.Text += goalsConceded.ToString();
            txtGoalDifference.Text += $"{goalsScored - goalsConceded}";

        }
    }
}
