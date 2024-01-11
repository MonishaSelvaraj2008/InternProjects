using System.Security;
using MySqlConnector;
using System.Data;
namespace MovieBooking
{
    public class Customer
    {
        string customername;
        string customeremail;
        double customernumber;
        string password;
        int nooftickets;
        string moviename;
        public int check;
        string classpreferred;
        public int checkpassword;
        public string temporarynumber;
        Validation validation = new Validation();

        public void register(MySqlConnection mySqlConnection)
        {
            mySqlConnection.Open();
            try
            {
                do
                {
                    Console.WriteLine("Enter Your Name: ");
                    customername = Console.ReadLine();
                    if (validation.validateName(customername) == false)
                    {
                        Console.WriteLine("Check your name...");
                    }
                }
                while (validation.validateName(customername) == false);

                do
                {
                    Console.WriteLine("Enter Your E-Mail: ");
                    customeremail = Console.ReadLine();
                    if (validation.validateEmail(customeremail) == false)
                    {
                        Console.WriteLine("Enter a valid mail id!");
                    }
                }
                while (validation.validateEmail(customeremail) == false);

                Console.WriteLine("Set Your Password: ");
                SecureString temporarypassword = Validation.maskInputString();
                password = new System.Net.NetworkCredential(string.Empty, temporarypassword).Password;

                do
                {
                    Console.WriteLine("Enter Your Mobile Number: ");
                    customernumber = Convert.ToDouble(Console.ReadLine());
                    temporarynumber = Convert.ToString(customernumber);
                    Console.WriteLine("\nThank you for registering :)");
                    Console.WriteLine("----------------------------------------------------------------");
                    if (validation.validateNumber(temporarynumber) == false)
                    {
                        Console.WriteLine("Enter the valid mobile number!");
                    }
                }
                while (validation.validateNumber(temporarynumber) == false);

                string insertQuery = "INSERT INTO register(customerName,customerEmail,password,customerNumber)VALUES('" + customername + "','" + customeremail + "','" + password + "','" + customernumber + "')";
                MySqlCommand insertcommand = new MySqlCommand(insertQuery, mySqlConnection);
                insertcommand.ExecuteNonQuery();
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

        public void login(MySqlConnection mySqlConnection)
        {
            mySqlConnection.Open();
            try
            {
                check = 0;
                do
                {
                    Console.WriteLine("Enter Your E-Mail: ");
                    customeremail = Console.ReadLine();
                    if (validation.validateEmail(customeremail) == false)
                    {
                        Console.WriteLine("Enter a valid mail id!");
                    }
                }
                while (validation.validateEmail(customeremail) == false);

                Console.WriteLine("Enter Your Password: ");
                SecureString temporarypassword = Validation.maskInputString();
                password = new System.Net.NetworkCredential(string.Empty, temporarypassword).Password;
                MySqlCommand verifyPassword = new MySqlCommand("SELECT password FROM register where CustomerEmail='" + customeremail + "'", mySqlConnection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(verifyPassword);
                //Represents a set of data commands and a database connection that are used to fill a dataset and update a MySQL database.
                //This class cannot be inherited.
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                string correctPassword = Convert.ToString(dataTable.Rows[0][0]);
                if (password == correctPassword)
                {
                    check++;
                    Console.WriteLine("\nLogged in :)");
                    Console.WriteLine("------------------Choose a menu here!!!------------------");
                }
                else
                {
                    Console.WriteLine("Check Login Details");
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