using MySql.Data.MySqlClient;
using System;

namespace TNDDMMainServer
{
    class TokenManager
    {
        public void RemoveToken(string username)
        {
            MySqlConnection mySqlConnection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");

            mySqlConnection.Open();

            MySqlCommand command = new MySqlCommand($"DELETE FROM token.tokens WHERE username='{username}'", mySqlConnection);

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

        public void AddToken(string username , string token)
        {
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


        public bool IsTokenValid(string username , string token)
        {
            bool isValid = false;

            MySqlConnection mySqlConnection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");

            mySqlConnection.Open();

            MySqlCommand command = new MySqlCommand($"SELECT * FROM token.tokens WHERE username='{username}'", mySqlConnection);

            MySqlDataReader mySqlDataReader;

            try
            {
                mySqlDataReader = command.ExecuteReader();
                if (mySqlDataReader.Read() && String.Equals(mySqlDataReader.GetString("token"), token))
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception);
            }

            mySqlConnection.Close();

            return isValid;
        }
    }
}
