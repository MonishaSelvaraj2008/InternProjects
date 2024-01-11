
//Title: Access Specifiers internal keyword
//Author: Monisha S
//Created on: 28/09/2022
//Updated on: 28/09/2022
//Reviewed by: 
//Reviewed on:
using System;  
namespace Internal  
{  
    class InternalTest  
    {  
        internal string name = "Monisha";  
        internal void Msg(string msg)  
        {  
            Console.WriteLine("Hello, " + msg);  
        }  
    }  
    class Program  
    {  
        static void Main(string[] args)  
        {  
            InternalTest internalTest = new InternalTest();  
            // Accessing public variable  
            Console.WriteLine("Hello " + internalTest.name);  
            // Accessing public function  
            internalTest.Msg("this is a message");  
        }  
    }  
}  

//The internal keyword is used to specify the internal access specifier for the variables and functions.
//This specifier is accessible only within files in the same assembly.