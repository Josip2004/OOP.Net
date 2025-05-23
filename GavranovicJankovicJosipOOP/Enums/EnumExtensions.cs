using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dao.Enums
{
    public static class EnumExtensions
    {
        public static string GetEnumValue<T>(this T enumValue) where T : Enum
        {
            return enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<EnumMemberAttribute>()?
                .Value ?? enumValue.ToString();
        }

        public static (int defenders, int midfielders, int forwards) ParseTactics(Tactics tactics)
        {
            var tacticStr = tactics.GetEnumValue(); 
            var parts = tacticStr.Split('-').Select(int.Parse).ToList();

            int defenders = parts[0];
            int forwards = parts[^1];
            int midfielders = parts.Skip(1).Take(parts.Count - 2).Sum();

            return (defenders, midfielders, forwards);
        }

        public static int GetMidfieldCount(this Tactics tactics)
        {
            var parts = tactics.GetEnumValue()
                               .Split('-')
                               .Select(int.Parse)
                               .ToList();

            if (parts.Count <= 2)
                return 0; 

            return parts.Skip(1).Take(parts.Count - 2).Sum();
        }
    }
}
