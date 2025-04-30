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

        [JsonProperty("fifa_code")]
        public string Code { get; set; }

        [JsonProperty("goals")]
        public long Goals { get; set; }

        [JsonProperty("penalties")]
        public long Penalties { get; set; }

        public override string ToString()
        {
            return $"{Country} {Code}";
        }
    }
}
