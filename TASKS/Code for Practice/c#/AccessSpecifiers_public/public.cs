//Title: Access Specifiers public keyword
//Author: Monisha S
//Created on: 28/09/2022
//Updated on: 28/09/2022
//Reviewed by: 
//Reviewed on:
using System;  
namespace Public  
{  
    class PublicTest  
    {  
        public string name = "Monisha";  
        public void Msg(string msg)  
        {  
            Console.WriteLine("Hello, " + msg);  
        }  
    }  
    class Program  
    {  
        static void Main(string[] args)  
        {  
            PublicTest publicTest = new PublicTest();  
            // Accessing public variable  
            Console.WriteLine("Hello " + publicTest.name);  
            // Accessing public function  
            publicTest.Msg("this is a message");  
        }  
    }  
}  