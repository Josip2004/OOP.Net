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
    public enum TypeOfEvent
    {
        [EnumMember(Value = "goal")]
        Goal,

        [EnumMember(Value = "goal-own")]
        GoalOwn,

        [EnumMember(Value = "goal-penalty")]
        GoalPenalty,

        [EnumMember(Value = "red-card")]
        RedCard,

        [EnumMember(Value = "substitution-in")]
        SubstitutionIn,

        [EnumMember(Value = "substitution-out")]
        SubstitutionOut,

        [EnumMember(Value = "yellow-card")]
        YellowCard,

        [EnumMember(Value = "yellow-card-second")]
        YellowCardSecond
    };
}
