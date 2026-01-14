using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using job_calendar.model;
using System.ComponentModel;
using System.Diagnostics;

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
                        Id = Convert.ToInt32(reader["id"]),
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

        public static void AddEntry(DateTime date, string position, string company, int pay, string? website)
        {
            string query =
                "INSERT INTO applications " +
                "(date, position, company, pay, website) " +
                "VALUES (@date, @position, @company, @pay, @website);";

            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@position", position);
                cmd.Parameters.AddWithValue("@company", company);
                cmd.Parameters.AddWithValue("@pay", pay);
                cmd.Parameters.AddWithValue("@website", website);

                try
                {
                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("error entering data in mysql");
                        return;
                    }
                }
                catch (MySqlException ex)
                {
                    Debug.WriteLine("sql error: " + ex.Message);
                    return;
                }
            }
        }

        public static void DeleteEntry(int id)
        {
            string query =
                "DELETE FROM applications " +
                "WHERE id = @id;";

            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        Debug.WriteLine("success");
                        return;
                    }
                    else
                    {
                        Debug.WriteLine("error deleting from database");
                        return;
                    }
                }
                catch (MySqlException ex)
                {
                    Debug.WriteLine("sql error: " + ex.Message);
                    return;
                }
            }
        }

        public static void EditEntry(int id, string position, string company, int pay, string website)
        {
            string query =
                "UPDATE applications " +
                "SET position = @position, company = @company, pay = @pay, website = @website " +
                "WHERE id = @id;";

            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@position", position);
                cmd.Parameters.AddWithValue("@company", company);
                cmd.Parameters.AddWithValue("@pay", pay);
                cmd.Parameters.AddWithValue("@website", website);

                try
                {
                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        Debug.WriteLine("update success");
                        return;
                    }
                    else
                    {
                        Debug.WriteLine("error updating");
                        return;
                    }
                }
                catch (MySqlException ex)
                {
                    Debug.WriteLine("sql error: " + ex.Message);
                    return;
                }
            }
        }

        public static int GetDayEntries(DateTime date)
        {
            string query =
                "SELECT COUNT(*) " +
                "FROM applications " +
                "WHERE date = @date;";

            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));

                try
                {
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    return result;
                }
                catch (MySqlException ex)
                {
                    Debug.WriteLine("sql error:" + ex.Message);
                    return 0;
                }

            }
        }
    }
}
