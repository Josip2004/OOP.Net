using Dao.Models;
using GavranovicJankovicJosipOOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao.Repositories
{
    public class DataRepository
    {
        private readonly IDataProvider _repo;

        public DataRepository()
        {
            _repo = RepositoryFactory.GetRepo();
        }

        public Task<List<Team>> GetTeamsAsync() => _repo.GetTeamsAsync();
        public Task<List<Match>> GetMatchesAsync(string fifaCode) => _repo.GetMatchesAsync(fifaCode);
    }
}
