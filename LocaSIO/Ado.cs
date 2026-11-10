using System;
using Microsoft.Data.SqlClient;

namespace LocaSIO
{

    internal class Ado
    {
        private static SqlConnection? connection;

        public static SqlConnection OpenSqlConnection()
        {
            string connectionString = GetConnectionString();
            connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        static private string GetConnectionString()
        {
            return "Data Source=sql.reseau-labo.fr;User ID=admin_locasio;Password=azerty123;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        }

        public static void CloseSqlConnection()
        {
            if (connection?.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public static void StatusSqlConnection()
        {
            if (connection?.State == System.Data.ConnectionState.Open)
            {
                Console.WriteLine("Connexion à la base de données réussie.");
            }
            else
            {
                Console.WriteLine("Échec de la connexion à la base de données.");
            }
        }
    }
}
