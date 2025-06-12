using Dao.Models;
using Dao.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
    /// Interaction logic for PlayerInfoWindow.xaml
    /// </summary>
    public partial class PlayerInfoWindow : Window
    {
        private readonly Player _player;
        private readonly IFileRepository _repo;
        public PlayerInfoWindow(Player player, IFileRepository repo, List<TeamEvent> matchEvents)
        {
            InitializeComponent();

            var animation = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.3));
            this.BeginAnimation(Window.OpacityProperty, animation);

            _player = player;
            _repo = repo;

            try
            {
                if (player != null)
                {
                    lblPlyName.Content = player.Name;
                    lblNumber.Content = $"#{player.ShirtNumber}";
                    lblPosition.Content = player.Position;
                    lblCap.Content = player.Captain == true ? "Captain" : "Not Captain";


                    int goalCount = matchEvents.Count(e =>
                        e.Player != null &&
                        e.Player.Trim().Equals(player.Name.Trim(), StringComparison.OrdinalIgnoreCase) &&
                        e.TypeOfEvent == Dao.Enums.TypeOfEvent.Goal);

                    int yellowCount = matchEvents.Count(e =>
                        e.Player != null &&
                        e.Player.Trim().Equals(player.Name.Trim(), StringComparison.OrdinalIgnoreCase) &&
                        e.TypeOfEvent == Dao.Enums.TypeOfEvent.YellowCard);

                    lblGoals.Content += $" {goalCount}";
                    lblYellow.Content += $" {yellowCount}";
                }

                string imagePath = FindImagePathForPlayer(player.Name);

                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(imagePath, UriKind.Absolute);
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();

                    imgPlayer.Source = bitmap;
                }
                else
                {
                    string fallback = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dataWpf", "DefaultImage.jpg");
                    if (File.Exists(fallback))
                    {
                        imgPlayer.Source = new BitmapImage(new Uri(fallback, UriKind.Absolute));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string FindImagePathForPlayer(string playerName)
        {
            string projectRoot = System.IO.Path.Combine(
                   Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)!
                            .Parent!.Parent!.Parent!.Parent!.FullName,
                   "GavranovicJankovicJosipOOP"
               );


            if (projectRoot == null)
                return string.Empty;

            string sharedImagesFolder = System.IO.Path.Combine(projectRoot, "ImagesForApp", "Images");


            string imageMapPath = System.IO.Path.Combine(projectRoot, "ImagesForApp", "images.txt");
            if (!File.Exists(imageMapPath))
                return string.Empty;

            var lines = File.ReadAllLines(imageMapPath);
            foreach (var line in lines)
            {
                var parts = line.Split('#');
                if (parts.Length < 2) continue;

                string nameFromFile = parts[0].Trim();
                string relativePath = parts[1].Trim();

                if (string.Equals(nameFromFile, playerName.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    string fileName = relativePath.Replace("Images/", "").Replace("Images\\", "").Trim();
                    string imagePath = System.IO.Path.Combine(sharedImagesFolder, fileName);

                    return File.Exists(imagePath) ? imagePath : string.Empty;
                }
            }

            return string.Empty;
        }

    }
}
