using System;
using MySqlConnector;
using System.Data;
namespace MovieBooking
{
    public class MoviesList
    {
        public void listMovies(string connectionString)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
            mySqlConnection.Open();
           
            try
            {

                
                Console.WriteLine("List Movies");
                string displayQuery = "SELECT movieName FROM booking ";
                MySqlCommand displaycommand = new MySqlCommand(displayQuery, mySqlConnection);
                MySqlDataReader datareader = displaycommand.ExecuteReader();
                while (datareader.Read())
                {
                    Console.WriteLine("Movie Name : " + datareader.GetValue(0).ToString());
                }
                datareader.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
        }
    }
}