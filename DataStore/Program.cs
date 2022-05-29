using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DataStore
{
    internal static class DataStore
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string server = "localhost";
            string database = "patientdata";
            string username = "root";
            string password = "";

            string connStr = "server=" + server + ";user=" + username + ";database=" + database +";password=" + password + ";";

            MySqlConnection mysql_conn = new MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to MySql ...");
                mysql_conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                mysql_conn.Close();
            }
        }
    }
}