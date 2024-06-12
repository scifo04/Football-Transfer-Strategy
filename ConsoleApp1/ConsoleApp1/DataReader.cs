using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Football
{
    public class DataReader
    {
        public static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlite_conn;
            sqlite_conn = new SQLiteConnection("Data Source=football.db;Version=3;New=True;Compress=True");
            try
            {
                sqlite_conn.Open();
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return sqlite_conn;
        }
        public static List<(int id, string name, int rating, string position, int market_value, int agent_fee, int age, bool is_free)> getData()
        {
            List<(int id, string name, int rating, string position, int market_value, int agent_fee, int age, bool is_free)> sent  = new List<(int id, string name, int rating, string position, int market_value, int agent_fee, int age, bool is_free)>();
            SQLiteConnection sqlconn;
            sqlconn = CreateConnection();
            SQLiteDataReader sqldat;
            SQLiteCommand sqlcom;
            sqlcom = sqlconn.CreateCommand();
            sqlcom.CommandText = "SELECT * FROM player";
            sqldat = sqlcom.ExecuteReader();
            while (sqldat.Read()) 
            {
                int temp_id = sqldat.GetInt32(0);
                string temp_name = sqldat.GetString(1);
                int temp_rating = sqldat.GetInt32(2);
                string temp_position = sqldat.GetString(3);
                int temp_market_value = sqldat.GetInt32(4);
                int temp_agent_fee = sqldat.GetInt32(5);
                int temp_age = sqldat.GetInt32(6);
                bool is_free = false;
                if (sqldat.GetString(7).Equals("true")) {
                    is_free = true;
                } else {
                    is_free = false;
                }
                sent.Add((temp_id,temp_name,temp_rating,temp_position,temp_market_value,temp_agent_fee,temp_age,is_free));
            }
            sqlconn.Close();
            return sent;
        }
    }
}