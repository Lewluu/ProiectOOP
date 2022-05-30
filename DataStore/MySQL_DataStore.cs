using System;
using MySql.Data.MySqlClient;

namespace DataStore
{
    public class MySQL_DataStore
    {
        public static void ConnectToDB()
        {
            string server = "localhost";
            string database = "patientdata";
            string username = "root";
            string password = "";

            string connStr = "server=" + server + ";user=" + username + ";database=" + database + ";password=" + password + ";";

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
