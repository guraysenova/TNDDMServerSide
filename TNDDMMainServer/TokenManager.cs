using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace TNDDMMainServer
{
    static class TokenManager
    {
        public static void RemoveToken(string token)
        {
            MySqlConnection mySqlConnection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");

            mySqlConnection.Open();

            MySqlCommand command = new MySqlCommand($"DELETE FROM token.tokens WHERE token='{token}'", mySqlConnection);

            try
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    Console.WriteLine("Data Removed");
                }
                else
                {
                    Console.WriteLine("Data Not Removed");
                }

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            mySqlConnection.Close();
        }

        public static void AddToken(string username, string token)
        {
            RefreshDataBase();

            MySqlConnection mySqlConnection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");

            mySqlConnection.Open();

            MySqlCommand command = new MySqlCommand($"INSERT INTO token.tokens(username,token) VALUES('{username}','{token}')", mySqlConnection);

            try
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    Console.WriteLine("Data Inserted");
                }
                else
                {
                    Console.WriteLine("Data Not Inserted");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            mySqlConnection.Close();
        }


        public static bool IsTokenValid(string username, string token)
        {
            RefreshDataBase();

            bool isValid = false;

            MySqlConnection mySqlConnection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");

            mySqlConnection.Open();

            MySqlCommand command = new MySqlCommand($"SELECT * FROM token.tokens WHERE token='{token}'", mySqlConnection);

            MySqlDataReader mySqlDataReader;

            try
            {
                mySqlDataReader = command.ExecuteReader();
                if (mySqlDataReader.Read() &&
                    String.Equals(mySqlDataReader.GetString("token"), token) &&
                    String.Equals(mySqlDataReader.GetString("username"), username) &&
                    (DateTime.Now - mySqlDataReader.GetDateTime("time")).TotalSeconds < 30.0)
                {
                    isValid = true;
                    RemoveToken(token);
                }
                else
                {
                    isValid = false;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            mySqlConnection.Close();

            return isValid;
        }


        public static void RefreshDataBase()
        {
            List<string> tokensToRemove = new List<string>();

            MySqlConnection mySqlConnection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");

            mySqlConnection.Open();

            MySqlCommand command = new MySqlCommand($"SELECT time, username, token FROM token.tokens", mySqlConnection);

            using (MySqlDataReader mySqlDataReader = command.ExecuteReader())
            {
                while (mySqlDataReader.Read())
                {
                    if ((DateTime.Now - mySqlDataReader.GetDateTime("time")).TotalSeconds >= 30.0)
                    {
                        tokensToRemove.Add(mySqlDataReader.GetString("token"));
                    }
                }
            }

            for (int i = 0; i < tokensToRemove.Count; i++)
            {
                RemoveToken(tokensToRemove[i]);
            }
        }
    }
}
