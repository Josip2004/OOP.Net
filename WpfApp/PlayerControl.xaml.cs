using Dao.Models;
using Dao.Repositories;
using GavranovicJankovicJosipOOP.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for UserControl.xaml
    /// </summary>
    public partial class PlayerControl : UserControl
    {
        private Player _player;
        private readonly IFileRepository _repo;
        private readonly Match _match;
        public PlayerControl(Player player, IFileRepository repo, Match match)
        {
            InitializeComponent();

            _player = player;
            _repo = repo;
            _match = match;

            string imagePath = FindImagePathForPlayer(_player.Name); 

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

        private string FindImagePathForPlayer(string playerName)
        {
            string solutionRoot = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.Parent?.FullName;
            string winFormsImagesFolder = System.IO.Path.Combine(solutionRoot, "WinFormsApp", "bin", "Debug", "net8.0-windows", "Images");

            string imageMapPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "images.txt");

            if (!File.Exists(imageMapPath))
            {
                return string.Empty;
            }

            var lines = File.ReadAllLines(imageMapPath);
            foreach (var line in lines)
            {
                var parts = line.Split('#');
                if (parts.Length < 2) continue;

                string nameFromFile = parts[0].Trim();
                string relativePath = parts[1].Trim();


                if (string.Equals(nameFromFile, playerName.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    string imagePath;
                    if (relativePath.StartsWith("Images\\"))
                    {
                        imagePath = System.IO.Path.Combine(winFormsImagesFolder, relativePath.Substring("Images\\".Length));
                    }
                    else
                    {
                        imagePath = System.IO.Path.Combine(winFormsImagesFolder, relativePath);
                    }


                    if (File.Exists(imagePath))
                    {
                        return imagePath;
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }

            return string.Empty;
        }




        private void Grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var allEvents = _match.HomeTeamEvents.Concat(_match.AwayTeamEvents).ToList();
            var playerInfo = new PlayerInfoWindow(_player, _repo, allEvents);
            playerInfo.ShowDialog();
        }
    }
}   
