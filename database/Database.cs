using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace job_calendar.database
{
    internal class Database
    {
        private static MySqlConnection connection { get; set; }

        // open connection
        public static void OpenConnection()
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Database = "job_list",
                UserID = "sqlUser",
                Password = "Passw0rd!",
                Port = 3306
            };
            var connectionString = builder.ConnectionString;

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();

                Console.WriteLine("connection opened");
                return;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                MessageBox.Show("Could not connect to database");
                return;
            }
        }

        public static void CloseConnection()
        {
            connection.Close();
            Console.WriteLine("connection closed");
        }
    }
}
