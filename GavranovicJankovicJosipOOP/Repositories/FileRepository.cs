using Dao.Constants;
using Dao.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao.Repositories
{
    public class FileRepository : IFileRepository
    {
        

        public async Task<List<Player>> LoadFavoritePlayersAsync()
        {
            if (!File.Exists(Paths.FavoritePlayersPath)) return new List<Player>();
            
            var json = await File.ReadAllTextAsync(Paths.FavoritePlayersPath);

            return JsonConvert.DeserializeObject<List<Player>>(json);
        }

        public async Task<string> LoadFavoriteTeamAsync()
        {
            if(File.Exists(Paths.FavoriteTeamPath))
            {
                return await File.ReadAllTextAsync(Paths.FavoriteTeamPath);
            }
            else
            {
                return null;
            }
        }
        public async Task SaveFavoritePlayersAsync(List<Player> players)
        {
            var json = JsonConvert.SerializeObject(players);
            await File.WriteAllTextAsync(Paths.FavoritePlayersPath, json);
        }

        public async Task SaveFavoriteTeamAsync(string fifaCode)
        {
            await File.WriteAllTextAsync(Paths.FavoriteTeamPath, fifaCode);
        }

        //public async Task<Settings> LoadSettingsAsync()
        //{
        //    if (!File.Exists(SettingsPath)) return null;
        //    var json = await File.ReadAllTextAsync(SettingsPath);

        //    return JsonConvert.DeserializeObject<Settings>(json); 
        //}

        //public Task SaveSettingsAsync(Settings settings)
        //{
        //    var json = JsonConvert.SerializeObject(settings);
        //    File.WriteAllText(SettingsPath, json);
        //}
    }
}
