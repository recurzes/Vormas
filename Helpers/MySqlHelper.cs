using System.Configuration;

namespace Vormas.Helpers
{
    public class MySqlHelper
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
        }
    }
}