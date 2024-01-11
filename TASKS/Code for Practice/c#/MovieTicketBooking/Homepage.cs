using System;
using MySqlConnector;
using System.Data;
namespace MovieBooking
{
    public class HomePage
    {
        int checkpassword;

        MySqlConnection mySqlConnection;
        string connectionstring = "server=localhost;user id=root;password=Monisha@2001;database=movieticketbooking";
        Customer customer = new Customer();
        Ticket ticket = new Ticket();
        MoviesList moviesList = new MoviesList();
        
        public void addHomePage()
        {
                mySqlConnection = new MySqlConnection(connectionstring);
                Console.WriteLine("MOVIE TICKET BOOKING");
                Console.WriteLine("This online ticket reservation system provides a website for a cinema hall ticket booking where any user of internet can access it.");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                Console.WriteLine("Enter your choice : ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        Console.WriteLine("------------------Register Here!!!------------------");
                        customer.register(mySqlConnection);
                        addHomePage();
                        break;
                    case 2:
                        Console.WriteLine("------------------Login Here!!!------------------");
                        customer.login(mySqlConnection);
                        checkpassword = customer.check;
                        if (checkpassword == 1)
                        {
                            displayMenu();
                        }
                        else
                        {
                            addHomePage();
                        }
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Inavlid Input");
                        addHomePage();
                        break;
                }
        }
        public void displayMenu(){
                    mySqlConnection = new MySqlConnection(connectionstring);
                    Console.WriteLine("Menu");
                    Console.WriteLine("1. Book Ticket");
                    Console.WriteLine("2. View Ticket");
                    Console.WriteLine("3. Cancel Ticket");
                    Console.WriteLine("4. Home Page");
                    Console.WriteLine("5. Exit");
                    Console.WriteLine("Enter your choice : ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch(choice)
                    {
                        case 1:
                             moviesList.listMovies(connectionstring);
                             Console.WriteLine("------------------Book Your Ticket Here!!!------------------");
                             ticket.bookTicket(mySqlConnection);
                             displayMenu();
                             break;
                        case 2: 
                             Console.WriteLine("------------------View Your Ticket Here!!!------------------");
                             ticket.viewTicket(mySqlConnection);
                             displayMenu();   
                             break;
                        case 3:
                             Console.WriteLine("------------------Cancel Your Ticket Here!!!------------------");
                             ticket.cancelTicket(mySqlConnection);
                             displayMenu();
                             break;
                        case 4:
                             addHomePage();
                             break;
                        case 5:
                             break;
                        default:
                             Console.WriteLine("Invalid Input");
                             displayMenu();
                             break;        
                   } 
        } 
    }
}