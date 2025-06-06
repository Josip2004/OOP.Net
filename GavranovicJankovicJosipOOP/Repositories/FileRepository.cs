using Dao.Enums;
using Dao.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Dao.Repositories
{
    public class FileRepository : IFileRepository
    {

        private static readonly string BaseFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\WinFormsApp\data");


        private static readonly string ConfigPath = Path.Combine(BaseFolder, "settings.txt");
        private static readonly string ImageMapPath = Path.Combine(BaseFolder, "images.txt");
        private static readonly string FavoritePlayersPath = Path.Combine(BaseFolder, "favoritePlayers.txt");

        private const char Del = '#';

        public void SaveSettings(string content)
        {

            EnsureDirectory(BaseFolder);
            File.WriteAllText(ConfigPath, content);
        }

        public void AppendToFile(string relativeFileName, string content)
        {
            try
            {
                string fullPath = Path.Combine(BaseFolder, relativeFileName);
                EnsureDirectory(Path.GetDirectoryName(fullPath));
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
                return File.Exists(path) ? File.ReadAllText(path) : string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return string.Empty;
            }
        }

        public string GetStoredGender() {
            return GetSetting(0);
        }
        public string GetStoredLanguage()
        {
            return GetSetting(1);
        }
        public string GetCurrentTeam()
        {
            return GetSetting(2);
        }

        public string GetSource()
        {
            var value = GetSetting(4);
            return string.IsNullOrWhiteSpace(value) ? "api" : value;
        }

        private string GetSetting(int index)
        {
            var settings = ReadFromFile(ConfigPath).Split(Del);
            return settings.Length > index ? settings[index] : string.Empty;
        }

        public bool ImageExists(string playerName)
        {
            if (!File.Exists(ImageMapPath)) return false;

            return File.ReadLines(ImageMapPath)
                .Any(line => line.Split(Del)[0].Trim().Equals(playerName.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        public string RetrieveImagePath(string playerName)
        {

            if (!File.Exists(ImageMapPath))
            {
                return string.Empty;
            }

            var lines = File.ReadLines(ImageMapPath);
            foreach (var line in lines)
            {

                var parts = line.Split('#');
                if (parts.Length < 2)
                {
                    continue;
                }

                string nameFromFile = parts[0].Trim();
                string relativePath = parts[1].Trim();


                if (string.Equals(nameFromFile, playerName.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);

                    if (File.Exists(fullPath))
                    {
                        return fullPath;
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }

            return string.Empty;
        }

        public void SaveFavoritePlayers(IEnumerable<Player> players)
        {
            EnsureDirectory(BaseFolder);

            string gender = GetStoredGender();
            string teamCode = GetCurrentTeam();

            var allLines = File.Exists(FavoritePlayersPath)
                ? File.ReadAllLines(FavoritePlayersPath).ToList()
                : new List<string>();

            allLines.RemoveAll(line =>
            {
                var parts = line.Split('#');
                return parts.Length >= 6 &&
                       parts[^2].Equals(gender, StringComparison.OrdinalIgnoreCase) &&
                       parts[^1].Equals(teamCode, StringComparison.OrdinalIgnoreCase);
            });

            var newLines = players.Select(p =>
                $"{p.Name}#{p.Position}#{p.Captain}#{p.ShirtNumber}#{gender}#{teamCode}");

            allLines.AddRange(newLines);

            File.WriteAllLines(FavoritePlayersPath, allLines);
        }


        public IEnumerable<Player> GetFavoritePlayersList()
        {
            string gender = GetStoredGender();
            string teamCode = GetCurrentTeam();

            if (!File.Exists(FavoritePlayersPath)) return Enumerable.Empty<Player>();

            var result = new List<Player>();

            foreach (var line in File.ReadLines(FavoritePlayersPath))
            {
                var parts = line.Split('#');
                if (parts.Length < 6) continue;

                string g = parts[4].Trim().ToLower();
                string t = parts[5].Trim().ToUpper();

                if (g != gender.ToLower() || t != teamCode.ToUpper()) continue;

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


        private void EnsureDirectory(string? path)
        {
            if (!string.IsNullOrEmpty(path) && !Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        public string ReadSettingsRaw()
        {
            return ReadFromFile(ConfigPath);
        }
    }
}
