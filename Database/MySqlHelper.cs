using System.Configuration;

namespace Vormas.Database
{
    public class MySqlHelper
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
        }
    }
}