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
                MessageBox.Show("Došlo je do greške prilikom spremanja putanje: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Datoteka ne postoji.");
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška prilikom čitanja datoteke: {ex.Message}");
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

        public bool ImageExists(string playerControl) =>
        File.Exists(ImageMapPath) &&
        File.ReadAllLines(ImageMapPath)
            .Any(line => line.Split(Del).FirstOrDefault() == playerControl);

        public string RetrieveImagePath(string controlName)
        {
            if (!File.Exists(ImageMapPath))
                if (!File.Exists(ImageMapPath))
                {
                    MessageBox.Show($"File does not exist: {ImageMapPath}");
                    return string.Empty;
                }

            var lines = File.ReadAllLines(ImageMapPath);
            foreach (var lin in lines)
            {
                MessageBox.Show($"Line: {lin}");
            }

            var line = lines
                .FirstOrDefault(line => line.Split(Del).FirstOrDefault() == controlName);

            if (line == null)
            {
                MessageBox.Show($"Player {controlName} not found.");
                return string.Empty;
            }

            string imagePath = line.Split(Del).ElementAtOrDefault(1)?.Trim();
            MessageBox.Show($"Path: {imagePath}");

            if (string.IsNullOrEmpty(imagePath))
            {
                MessageBox.Show("Putanja slike je prazna.");
                return string.Empty;
            }

            if (!File.Exists(imagePath))
            {
                MessageBox.Show($"Slika NE POSTOJI na toj putanji: {imagePath}");
                return string.Empty;
            }

            if (!string.IsNullOrEmpty(imagePath))
            {
                return imagePath.Replace(@"\\", @"\");
            }

            return string.Empty;
        }

        public void SaveFavoritePlayers(IEnumerable<string> favoritePlayerNames)
        {
            if (!Directory.Exists(BaseFolder))
                Directory.CreateDirectory(BaseFolder);

            SaveSettings(FavoritePlayersPath, string.Join(Environment.NewLine, favoritePlayerNames));
        }

        public IEnumerable<string> GetFavoritePlayersList()
        {
            return File.Exists(FavoritePlayersPath) ? File.ReadAllLines(FavoritePlayersPath) : Enumerable.Empty<string>();
        }

          
        
    }
}
