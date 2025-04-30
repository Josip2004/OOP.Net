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
    public enum Time
    {
        [EnumMember(Value = "full-time")]
        FullTime
    };
}
