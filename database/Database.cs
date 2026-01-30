using job_calendar.model;
using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace job_calendar.database
{
    public static class Database
    {
        private static SqliteConnection _db;

        // open connection
        public static void OpenConnection()
        {
            if (_db != null)
            {
                return;
            }

            // create the database
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string path = Path.Combine(appData, "myApplications.db");
            _db = new SqliteConnection($"Filename={path}");
            _db.Open();

            string cmd =
                "CREATE TABLE IF NOT EXISTS applications " +
                "(id INTEGER PRIMARY KEY, " +
                "date TEXT NOT NULL, " +
                "position TEXT NOT NULL, " +
                "company TEXT NOT NULL," +
                "pay INTEGER NOT NULL, " +
                "website TEXT)";
            SqliteCommand makeTable = new SqliteCommand(cmd, _db);
            makeTable.ExecuteReader();
        }

        public static void CloseConnection()
        {
            _db.Close();
            Debug.WriteLine("connection closed");
        }

        public static Dictionary<string, int> LoadMonthHeatmap(DateTime start, DateTime end)
        {
            Dictionary<string, int> monthApplications = new Dictionary<string, int>();

            string query =
                "SELECT date, COUNT(*) AS application_count " +
                "FROM applications " +
                "WHERE date BETWEEN @startDate AND @endDate " +
                "GROUP BY date;";

            SqliteCommand cmd = new SqliteCommand(query, _db);
            cmd.Parameters.AddWithValue("@startDate", start.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@endDate", end.ToString("yyyy-MM-dd"));

            SqliteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // convert datetime into a yyyy-MM-dd string
                string date = reader.GetString(0);
                int count = reader.GetInt32("application_count");
                monthApplications.Add(date, count);
            }
            reader.Close();
            return monthApplications;
        }

        public static BindingList<Applicationz> GetApplications(DateTime? date = null)
        {
            BindingList<Applicationz> allApplications = new BindingList<Applicationz>();

            // if the date is passed in then get assessments for specific days, otherwise get all
            string query = "SELECT * FROM applications ORDER BY date;";
            SqliteCommand cmd = new SqliteCommand(query, _db);
            if (date != null)
            {
                string dateQuery =
                    "SELECT * " +
                    "FROM applications " +
                    "WHERE date=@today;";
                cmd.CommandText = dateQuery;
                cmd.Parameters.AddWithValue("@today", date.Value.ToString("yyyy-MM-dd"));
            }

            SqliteDataReader reader = cmd.ExecuteReader();
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
            return allApplications;
        }

        public static void AddEntry(DateTime date, string position, string company, int pay, string? website)
        {
            string query =
                "INSERT INTO applications " +
                "(date, position, company, pay, website) " +
                "VALUES (@date, @position, @company, @pay, @website);";

            SqliteCommand cmd = new SqliteCommand(query, _db);
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

        public static void DeleteEntry(int id)
        {
            string query =
                "DELETE FROM applications " +
                "WHERE id = @id;";

            SqliteCommand cmd = new SqliteCommand(query, _db);
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

        public static void EditEntry(int id, string position, string company, int pay, string website)
        {
            string query =
                "UPDATE applications " +
                "SET position = @position, company = @company, pay = @pay, website = @website " +
                "WHERE id = @id;";

            SqliteCommand cmd = new SqliteCommand(query, _db);
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

        public static int GetDayEntries(DateTime date)
        {
            string query =
                "SELECT COUNT(*) " +
                "FROM applications " +
                "WHERE date = @date;";

            SqliteCommand cmd = new SqliteCommand(query, _db);
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

        public static BindingList<Applicationz> GetCompanyApplications(string companyName)
        {
            BindingList<Applicationz> applications = new BindingList<Applicationz>();

            string query =
                "SELECT * " +
                "FROM applications " +
                "WHERE LOWER(company) LIKE @company;";

            SqliteCommand cmd = new SqliteCommand(query, _db);
            cmd.Parameters.AddWithValue("@company", "%" + companyName.ToLower() + "%");

            SqliteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Applicationz app = new Applicationz()
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Date = Convert.ToString(reader["date"]),
                    Position = Convert.ToString(reader["position"]),
                    Company = Convert.ToString(reader["company"]),
                    Pay = Convert.ToInt32(reader["pay"]),
                    Website = Convert.ToString(reader["website"])
                };

                applications.Add(app);
            }
            reader.Close();

            return applications;
        }
    }
}
