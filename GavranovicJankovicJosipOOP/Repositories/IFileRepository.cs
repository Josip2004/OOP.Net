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
        Task SaveFavoriteTeamAsync(string fifaCode);
        Task<string> LoadFavoriteTeamAsync();

        Task SaveFavoritePlayersAsync(List<Player> players);
        Task<List<Player>> LoadFavoritePlayersAsync();

        //Task SaveSettingsAsync(Settings settings);
        //Task<Settings> LoadSettingsAsync();
    }
}
