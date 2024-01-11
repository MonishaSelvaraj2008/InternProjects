using System;
using MySqlConnector;
using System.Data;
namespace MovieBooking
{
    public class Ticket
    {
        int bookingid;
        string customername;
        string moviename;
        double nooftickets;
        double amount;
        string timing;
        public void bookTicket(MySqlConnection mySqlConnection)
        {
            mySqlConnection.Open();
            try
            {
                Console.WriteLine("Enter Your Name: ");
                customername = Console.ReadLine();
                Console.WriteLine("Enter Your Movie Name: ");
                moviename = Console.ReadLine();
                Console.WriteLine("Select the timings from this...");
                Console.WriteLine("10:00 AM | 02:00 PM | 06:00 PM |10:00 PM");
                Console.WriteLine("Enter Your Timing : ");
                timing = Console.ReadLine();
                
                Console.WriteLine("Enter the number of tickets : ");
                nooftickets = Convert.ToDouble(Console.ReadLine());
                MySqlCommand fetchcommand = new MySqlCommand("SELECT moviePrice FROM booking where movieName='" + moviename + "'", mySqlConnection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(fetchcommand);
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                double price;
                price = Convert.ToDouble(dataTable.Rows[0][0]);
                string insertQuery = "INSERT INTO customer(customerName,movieName,noOfTickets,timing)VALUES('" + customername + "','" + moviename + "','" + nooftickets + "','" + timing + "')";
                MySqlCommand insertcommand = new MySqlCommand(insertQuery, mySqlConnection);
                insertcommand.ExecuteNonQuery();
                amount = price * nooftickets;
                Console.WriteLine("The bill amount is : ");
                Console.WriteLine(amount);
                //Booking Id
                MySqlCommand bookcommand = new MySqlCommand("SELECT bookingId FROM customer where customerName='" + customername + "'", mySqlConnection);
                MySqlDataAdapter mySqlDataAdapterBooking = new MySqlDataAdapter(bookcommand);
                DataTable dataTableBooking = new DataTable();
                mySqlDataAdapterBooking.Fill(dataTableBooking);
                int id;
                id = Convert.ToInt32(dataTableBooking.Rows[0][0]);
                Console.WriteLine("The Booking Id is : ");
                Console.WriteLine(id);
                Console.WriteLine("Your Tickets Are Booked");
                Console.WriteLine("------------------Choose a menu here!!!------------------");
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

        public void viewTicket(MySqlConnection mySqlConnection)
        {
            mySqlConnection.Open();
            try
            {
                Console.WriteLine("Enter the Booking Id :");
                bookingid = Convert.ToInt32(Console.ReadLine());
                MySqlCommand verifycommand = new MySqlCommand("SELECT bookingId FROM customer WHERE bookingId = '" + bookingid + "'", mySqlConnection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(verifycommand);
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    Console.WriteLine("Movie Details : ");
                    string displayQuery = "SELECT * FROM customer WHERE bookingId='" + bookingid + "'";
                    MySqlCommand displaycommand = new MySqlCommand(displayQuery, mySqlConnection);
                    MySqlDataReader datareader = displaycommand.ExecuteReader();
                    while (datareader.Read())
                    {
                        Console.WriteLine("Movie Name : " + datareader.GetValue(0).ToString() + " || No Of Tickets: " + datareader.GetValue(1).ToString() + " || Booking Id: " + datareader.GetValue(2).ToString());
                    }
                    Console.WriteLine("------------------Choose a menu here!!!------------------");
                    datareader.Close();
                }
                else
                {
                    Console.WriteLine("Check Your Booking Id");
                }
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
        public void cancelTicket(MySqlConnection mySqlConnection)
        {
            mySqlConnection.Open();
            try
            {
                Console.WriteLine("Enter the Booking Id :");
                bookingid = Convert.ToInt32(Console.ReadLine());
                MySqlCommand verifycommand = new MySqlCommand("SELECT bookingId FROM customer WHERE bookingId = '" + bookingid + "'", mySqlConnection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(verifycommand);
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    string deleteQuery = "DELETE FROM customer WHERE bookingId='" + bookingid + "'";
                    MySqlCommand deletecommand = new MySqlCommand(deleteQuery, mySqlConnection);
                    deletecommand.ExecuteNonQuery();
                    Console.WriteLine("Your booking has been cancelled!!!");
                    Console.WriteLine("------------------Choose a menu here!!!------------------");
                }
                else
                {
                    Console.WriteLine("Check Your Booking Id");
                }
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