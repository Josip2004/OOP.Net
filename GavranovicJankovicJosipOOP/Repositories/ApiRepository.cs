using Dao.Models;
using GavranovicJankovicJosipOOP.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dao.Repositories
{
    public class ApiRepository : IDataProvider
    {
        private readonly RestClient _client;

        public ApiRepository(string gender)
        {
            try
            {
                if (gender != "men" && gender != "women")
                    throw new ArgumentException("Gender must be 'men' or 'women'");

                string baseUrl = $"https://worldcup-vua.nullbit.hr/{gender}/";
                _client = new RestClient(baseUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async Task<List<Match>> GetMatchesAsync(string code)
        {
            var request = new RestRequest($"matches/country", Method.Get);
            request.AddParameter("fifa_code", code);

            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Error fetching matches: {response.ErrorMessage}");

            return JsonConvert.DeserializeObject<List<Match>>(response.Content);
        }

        public async Task<List<Team>> GetTeamsAsync()
        {
            var request = new RestRequest("teams/results", Method.Get);

            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Error fetching teams: {response.ErrorMessage}");

            return JsonConvert.DeserializeObject<List<Team>>(response.Content);
        }

    }
}
