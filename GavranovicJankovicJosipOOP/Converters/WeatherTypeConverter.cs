using Dao.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao.Converters
{
    public class WeatherTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(WeatherType) || t == typeof(WeatherType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Clear Night":
                    return WeatherType.ClearNight;
                case "Cloudy":
                    return WeatherType.Cloudy;
                case "Partly Cloudy":
                    return WeatherType.PartlyCloudy;
                case "Partly Cloudy Night":
                    return WeatherType.PartlyCloudyNight;
                case "Sunny":
                    return WeatherType.Sunny;
            }
            throw new Exception("Cannot unmarshal type Description");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (WeatherType)untypedValue;
            switch (value)
            {
                case WeatherType.ClearNight:
                    serializer.Serialize(writer, "Clear Night");
                    return;
                case WeatherType.Cloudy:
                    serializer.Serialize(writer, "Cloudy");
                    return;
                case WeatherType.PartlyCloudy:
                    serializer.Serialize(writer, "Partly Cloudy");
                    return;
                case WeatherType.PartlyCloudyNight:
                    serializer.Serialize(writer, "Partly Cloudy Night");
                    return;
                case WeatherType.Sunny:
                    serializer.Serialize(writer, "Sunny");
                    return;
            }
            throw new Exception("Cannot marshal type Description");
        }

        public static readonly WeatherTypeConverter Singleton = new WeatherTypeConverter();
    }
}
