using Dao.Models;
using GavranovicJankovicJosipOOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao.Repositories
{
    public interface IApiRepository
    {
        Task<List<Team>> GetTeamsAsync();
        Task<List<Match>> GetMatchesAsync(string fifaCode);
    }
}
