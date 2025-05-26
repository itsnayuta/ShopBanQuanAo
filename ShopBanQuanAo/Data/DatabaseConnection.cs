using MySql.Data.MySqlClient;
using System.Configuration;

namespace ShopBanQuanAo.Data
{
    public class DatabaseConnection
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
        
        public static bool TestConnection()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}