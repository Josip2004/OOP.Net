using Dao.Models;
using Dao.Repositories;
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
        private string _playerName;
        public PlayerControl(string playerName, IFileRepository repo)
        {
            InitializeComponent();

            _playerName = playerName;

            string imagePath = FindImagePathForPlayer(playerName); 

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
            string solutionRoot = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.FullName;
            string imageMapPath = System.IO.Path.Combine(solutionRoot, "WinFormsApp", "data", "images.txt");

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
                    string imagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);

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
            var playerInfo = new PlayerInfoWindow();
            playerInfo.ShowDialog();
        }
    }
}   
