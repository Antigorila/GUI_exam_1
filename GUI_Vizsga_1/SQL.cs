using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace GUI_Vizsga_1
{
    internal class SQL
    {
        private static string ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=";
        private static MySqlConnection con = new MySqlConnection(ConnectionString);

        public static void SetConnectionString(string NewConnectionString)
        {
            ConnectionString = NewConnectionString;
            con.ConnectionString = NewConnectionString;
        }

        public static void Command(string command)
        {
            con.Open();

            MySqlCommand cmd = new MySqlCommand(command, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }

        public static List<string[]> Query(string command) 
        {
            List<string[]> results = new List<string[]>();
            con.Open();

            MySqlCommand cmd = new MySqlCommand(command, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) 
            {
                string[] row = new string[reader.FieldCount];

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row[i] = reader[i].ToString();
                }

                results.Add(row);
            }

            con.Close();
            return results;
        }

        public static List<string> Tables()
        {
            List<string> returnList = new List<string>();
            List<string[]> lis = Query($"SHOW TABLES FROM {con.Database}");
            for (int i = 0; i < lis.Count; i++)
            {
                returnList.Add(lis[i][0]);
            }
            return returnList;
        }
    }
}
