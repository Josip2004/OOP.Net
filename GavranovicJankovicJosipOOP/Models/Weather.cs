using Dao.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao.Models
{
    class Weather
    {
        [JsonProperty("humidity")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Humidity { get; set; }

        [JsonProperty("temp_celsius")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long TempCelsius { get; set; }

        [JsonProperty("temp_farenheit")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long TempFarenheit { get; set; }

        [JsonProperty("wind_speed")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long WindSpeed { get; set; }

        [JsonProperty("weather__type")]
        public WeatherType WeatherType { get; set; }
    }
}
