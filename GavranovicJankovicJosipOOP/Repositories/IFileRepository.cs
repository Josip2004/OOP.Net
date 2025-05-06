using Dao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao.Repositories
{
    public interface IFileRepository
    {
        // Generičke metode za spremanje podataka u datoteke
        void SaveSettings(string path, string content);
        void AppendToFile(string path, string content);
        string ReadFromFile(string path);

        // Metode za specifične postavke
        string GetStoredGender();
        string GetStoredLanguage();
        string GetCurrentTeam();

        // Metode vezane uz slike i igrače
        bool ImageExists(string playerControl);
        string RetrieveImagePath(string controlName);

        // Upravljanje omiljenim igračima
        void SaveFavoritePlayers(IEnumerable<string> favoritePlayerNames);
        IEnumerable<string> GetFavoritePlayersList();


    }
}
