using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using job_calendar.model;
using System.ComponentModel;

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

        public static Dictionary<string, int> LoadMonthHeatmap(DateTime start, DateTime end)
        {
            Dictionary<string, int> monthApplications = new Dictionary<string, int>();

            string query =
                "USE job_list; " +
                "SELECT date, COUNT(*) AS application_count " +
                "FROM applications " +
                "WHERE date BETWEEN @startDate AND @endDate " +
                "GROUP BY date;";

            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@startDate", start.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@endDate", end.ToString("yyyy-MM-dd"));

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // convert datetime into a yyyy-MM-dd string
                    string date = reader.GetDateTime("date").ToString("yyyy-MM-dd");
                    int count = reader.GetInt32("application_count");
                    monthApplications.Add(date, count);
                }
                reader.Close();
            }

            return monthApplications;
        }

        public static BindingList<Applicationz> GetApplications(DateTime date)
        {
            BindingList<Applicationz> allApplications = new BindingList<Applicationz>();

            string query =
                "SELECT * " +
                "FROM applications " +
                "WHERE date=@today;";

            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@today", date.ToString("yyyy-MM-dd"));

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Applicationz application = new Applicationz()
                    {
                        Date = Convert.ToString(reader["date"]),
                        Position = Convert.ToString(reader["position"]),
                        Company = Convert.ToString(reader["company"]),
                        Pay = Convert.ToInt32(reader["pay"]),
                        Website = Convert.ToString(reader["website"])
                    };

                    allApplications.Add(application);
                }
                reader.Close();
            }
            return allApplications;
        }
    }
}
