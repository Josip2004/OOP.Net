using Dao.Enums;
using Dao.Models;
using Dao.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Dao.Repositories
{
    public class FileRepository : IFileRepository
    {
        private const string BaseFolder = @"../../../data";

        private static readonly string ConfigPath = @"../../../data/settings.txt";
        private static readonly string ImageMapPath = @"../../../data/images.txt";
        private static readonly string WpfAppSizePath = @"../../../data/wpf_app_size.txt";
        private static readonly string FavoritePlayersPath = @"../../../data/favoritePlayers.txt";
        private const char Del = '#';

 

        public void SaveSettings(string path, string content)
        {
            if (!Directory.Exists(BaseFolder))
                Directory.CreateDirectory(BaseFolder);

            File.WriteAllText(path, content);
        }

        public void AppendToFile(string path, string content)
        {
            try
            {
                string fullPath = Path.Combine(BaseFolder, path);
                string directory = Path.GetDirectoryName(fullPath);

                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                File.AppendAllText(fullPath, content + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string ReadFromFile(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    return File.ReadAllText(path);
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return string.Empty;
            }
        }

        public string GetStoredGender() => GetSetting(0);
        public string GetStoredLanguage() => GetSetting(1);
        public string GetCurrentTeam() => GetSetting(2);

        private string GetSetting(int index)
        {
            var settings = ReadFromFile(ConfigPath).Split(Del);
            if (settings.Length <= index)
            {
                return string.Empty;
            }
            return settings.ElementAtOrDefault(index) ?? string.Empty;
        }

        public bool ImageExists(string playerName)
        {
            if (!File.Exists(ImageMapPath))
            {
                return false;
            }

            var lines = File.ReadAllLines(ImageMapPath);
            foreach (var line in lines)
            {

                var parts = line.Split(Del);
                if (parts.Length > 0)
                {
                    string nameFromFile = parts[0].Trim();

                    if (string.Equals(nameFromFile, playerName.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public string RetrieveImagePath(string controlName)
        {
            if (!File.Exists(ImageMapPath))
            {
                MessageBox.Show($"File does not exist: {ImageMapPath}");
                return string.Empty;
            }

            var lines = File.ReadAllLines(ImageMapPath);
            var line = lines.FirstOrDefault(l =>
            {
                var parts = l.Split(Del);
                return parts.Length > 0 &&
                       parts[0].Trim().Equals(controlName.Trim(), StringComparison.OrdinalIgnoreCase);
            });

            if (line == null)
            {
                return string.Empty;
            }

            string imagePath = line.Split(Del).ElementAtOrDefault(1)?.Trim();

            if (string.IsNullOrEmpty(imagePath))
            {
                MessageBox.Show("Putanja slike je prazna.");
                return string.Empty;
            }

            if (!Path.IsPathRooted(imagePath))
            {
                imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imagePath);
            }

            if (!File.Exists(imagePath))
            {
                MessageBox.Show($"Slika NE POSTOJI na toj putanji: {imagePath}");
                return string.Empty;
            }

            return imagePath;
        }

        public void SaveFavoritePlayers(IEnumerable<Player> players)
        {
            if (!Directory.Exists(BaseFolder))
                Directory.CreateDirectory(BaseFolder);

            var lines = players.Select(p =>
                $"{p.Name}#{p.Position}#{p.Captain}#{p.ShirtNumber}"
            );

            File.WriteAllLines(FavoritePlayersPath, lines);
        }

        public IEnumerable<Player> GetFavoritePlayersList()
        {
            var result = new List<Player>();

            if (!File.Exists(FavoritePlayersPath)) return result;

            var lines = File.ReadAllLines(FavoritePlayersPath);
            foreach (var line in lines)
            {
                var parts = line.Split('#');
                if (parts.Length < 4) continue;

                var player = new Player
                {
                    Name = parts[0],
                    Position = Enum.TryParse(parts[1], out Position pos) ? pos : Position.Midfield,
                    Captain = bool.TryParse(parts[2], out bool cap) && cap,
                    ShirtNumber = long.TryParse(parts[3], out long number) ? number : 0
                };

                result.Add(player);
            }
            return result;
        }
    }
}
