using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao.Repositories
{
    public class RepositoryFactory
    {
        public static IDataProvider GetRepo()
        {
            string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\WinFormsApp\data\settings.txt");
            if (!File.Exists(configPath))
                throw new FileNotFoundException("Missing settings.txt");

            var parts = File.ReadAllText(configPath).Split('#');

            string gender = parts.Length >= 1 ? parts[0] : "men";
            string source = parts.Length >= 5 ? parts[4] : "api";

            return source switch
            {
                "file" => new FileDataRepository(gender),
                "api" => new ApiRepository(gender),
                _ => throw new InvalidOperationException("Unknown data source in settings.")
            };
        }
    }
}
