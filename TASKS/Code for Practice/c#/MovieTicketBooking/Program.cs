//Title: Movie Ticket Booking System
//Author: Monisha S
//Created at: 17/11/2022
//Updated at: 22/01/2023
//Reviewed by: Sabapathi Shanmugam
//Reviewed atS: 21/12/2022

using System;
using MySqlConnector;

namespace MovieBooking
{
    public class Program
    {
        static void Main()
        {
            HomePage homePage = new HomePage();
            homePage.addHomePage();
        }
    }
}