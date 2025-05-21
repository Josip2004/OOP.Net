using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao.Models
{
    public class Team
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        private string _code;

        [JsonProperty("code")]
        public string RawCode
        {
            set { _code = value; }
        }

        [JsonProperty("fifa_code")]
        public string RawFifaCode
        {
            set { _code = value; }
        }

        public string Code => _code;

        [JsonProperty("goals")]
        public long Goals { get; set; }

        [JsonProperty("penalties")]
        public long Penalties { get; set; }

        public string DisplayName => $"{Country} ({Code})";
        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(Country) && string.IsNullOrWhiteSpace(Code))
            {
                return ""; 
            }

            return $"{Country} ({Code})";
        }
    }
}
