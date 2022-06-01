using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

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

                _mysql_conn.Close();
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
                _mysql_conn.Open();
                string sql_str = "INSERT INTO patient_data(patient_code, sensor_type, time_stamp, time_stamp2, value) VALUES(" +
                    "'" + (int)sv.PatientCode + "'" +
                    ", " + "'" + (int)sv.Type + "'" +
                    ", " + "'" + sv.TimeStampDateString + "'" +
                    ", " + "'" + sv.TimeStampTimeString + "'" +
                    ", " + sv.Value +
                    ")";

                MySqlCommand sql_cmd = new MySqlCommand(sql_str, _mysql_conn);
                sql_cmd.ExecuteNonQuery();
                _mysql_conn.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public static List<SensorInput.SensorValue> getSensorValues(string date)
        {
            List<SensorInput.SensorValue> sv_list = new List<SensorInput.SensorValue>();

            try
            {
                _mysql_conn.Open();
                string sql_str = "SELECT * FROM patient_data WHERE time_stamp =" + "'" + date + "'";
                using (MySqlCommand sql_cmd = new MySqlCommand(sql_str, _mysql_conn))
                {
                    MySqlDataReader data_reader = sql_cmd.ExecuteReader();
                    if (data_reader.HasRows)
                    {
                        int count = data_reader.FieldCount;
                        while (data_reader.Read())
                        {
                            // Console.WriteLine(data_reader["id"] +" "+ data_reader["patient_code"] + " " + data_reader["sensor_type"] + " " +data_reader["time_stamp"] +" "+ data_reader["value"]);

                            SensorInput.SensorValue sv = new SensorInput.SensorValue();

                            string date_calendar = (string)data_reader["time_stamp"].ToString();
                            string date_time = (string)data_reader["time_stamp2"].ToString();
                            date_calendar = date_calendar.Replace(" 00:00:00", "");

                            string dt_string = date_calendar + " " + date_time;
                            DateTime dt_exact = DateTime.Parse(dt_string);

                            sv.Timestamp = dt_exact;
                            sv.PatientCode = (PatientCode)data_reader["patient_code"];
                            sv.Type = (SensorType)data_reader["sensor_type"];
                            sv.Value = Convert.ToDouble(data_reader["value"]);

                            sv_list.Add(sv);
                        }
                        data_reader.Close();
                    }
                }
                _mysql_conn.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return sv_list;
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
