using Dao.Models;
using GavranovicJankovicJosipOOP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao.Repositories
{
    public class FileDataRepository : IDataProvider
    {
        private readonly string _gender;

        public FileDataRepository(string gender)
        {
            _gender = gender;
        }

        public async Task<List<Team>> GetTeamsAsync()
        {
            try
            {
                string path = Path.Combine("jsonFiles", _gender, "teams.json");
                if (!File.Exists(path))
                    throw new FileNotFoundException($"Missing file: {path}");

                string json = await File.ReadAllTextAsync(path);
                return JsonConvert.DeserializeObject<List<Team>>(json);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred: ", ex);
            }
        }

        public async Task<List<Match>> GetMatchesAsync(string fifaCode)
        {
            try
            {
                string path = Path.Combine("jsonFiles", _gender, "matches.json");
                if (!File.Exists(path))
                    throw new FileNotFoundException($"Missing file: {path}");

                string json = await File.ReadAllTextAsync(path);
                var allMatches = JsonConvert.DeserializeObject<List<Match>>(json);
                return allMatches
                    .Where(m => m.HomeTeam.Code == fifaCode || m.AwayTeam.Code == fifaCode)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred: ", ex);
            }
        }
    }
}
