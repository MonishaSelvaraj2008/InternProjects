//Title: Access Specifiers private keyword
//Author: Monisha S
//Created on: 28/09/2022
//Updated on: 28/09/2022
//Reviewed by: 
//Reviewed on:
using System;  
namespace Private 
{  
    class Program  
    {  
        private string name = "Monisha";  
        private void Msg(string msg)  
        {  
            Console.WriteLine("Hello " + msg);  
        }  
        static void Main(string[] args)  
        {  
            Program program = new Program();  
            // Accessing private variable  
            Console.WriteLine("Hello " + program.name);  
            // Accessing private function  
            program.Msg(", this is private");  
        }  
    }  
}  
