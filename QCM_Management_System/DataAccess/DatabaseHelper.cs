using System;
using System.Configuration;
using System.Data.SqlClient;

namespace QCM_ManagementSystem.DataAccess
{
    public class DatabaseHelper
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["QCM_DB"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection Error: " + ex.Message);
                return false;
            }
        }
    }
}