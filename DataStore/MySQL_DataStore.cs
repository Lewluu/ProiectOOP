﻿using System;
using MySql.Data.MySqlClient;

namespace DataStore
{
    public class MySQL_DataStore
    {
        static MySqlConnection _mysql_conn;
        public static void ConnectToDB()
        {
            string server = "localhost";
            string database = "patientdata";
            string username = "root";
            string password = "";

            string connStr = "server=" + server + ";user=" + username + ";database=" + database + ";password=" + password + ";";

            _mysql_conn = new MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to MySql ...");
                _mysql_conn.Open();

                int rows;
                string sql_str = "SELECT COUNT(*) FROM patient_data";
                using (MySqlCommand cmd = new MySqlCommand(sql_str, _mysql_conn))
                {
                    rows = Convert.ToInt32(cmd.ExecuteScalar());
                }

                if(rows == 0)
                {
                    sql_str = "ALTER TABLE patient_data AUTO_INCREMENT = 1";
                    MySqlCommand sql_cmd = new MySqlCommand(sql_str, _mysql_conn);
                    sql_cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _mysql_conn.Close();
            }
        }
        public static void addToDB(SensorInput.SensorValue sv)
        {
            try
            {
                string sql_str = "INSERT INTO patient_data(patient_code, sensor_type, time_stamp, value) VALUES(" +
                    "'" + sv.PatientCode.ToString() + "'" + ", " + "'" + sv.Type.ToString()+ "'" + ", " + "'" + sv.TimeStampString + "'" + ", " + sv.Value +
                    ")";

                MySqlCommand sql_cmd = new MySqlCommand(sql_str, _mysql_conn);
                sql_cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public static void closeConn()
        {
            try
            {
                Console.WriteLine("Closing MySQL ...");
                _mysql_conn.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
