﻿using Dao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao.Repositories
{
    public interface IFileRepository
    {
        void SaveSettings(string content);
        void AppendToFile(string path, string content);
        string ReadFromFile(string path);


        string GetStoredGender();
        string GetStoredLanguage();
        string GetCurrentTeam();
        string GetSource();
        string ReadSettingsRaw();

        bool ImageExists(string playerControl);
        string RetrieveImagePath(string controlName);

        void SaveFavoritePlayers(IEnumerable<Player> favoritePlayerNames);
        IEnumerable<Player> GetFavoritePlayersList();


    }
}
