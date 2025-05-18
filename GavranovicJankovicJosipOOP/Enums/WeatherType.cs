using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dao.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum WeatherType 
    {
        [EnumMember(Value = "Clear Night")]
        ClearNight,

        [EnumMember(Value = "Cloudy")]
        Cloudy,

        [EnumMember(Value = "Partly Cloudy")]
        PartlyCloudy,

        [EnumMember(Value = "Partly Cloudy Night")]
        PartlyCloudyNight,

        [EnumMember(Value = "Cloudy Night")]
        CloudyNight,

        [EnumMember(Value = "Sunny")]
        Sunny
    };
}
