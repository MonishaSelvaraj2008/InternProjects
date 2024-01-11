
//Title: Access Specifiers protected keyword
//Author: Monisha S
//Created on: 28/09/2022
//Updated on: 28/09/2022
//Reviewed by: 
//Reviewed on:
using System;  
namespace Protected 
{  
    class ProtectedTest  
    {  
        protected string name = "Monisha";  
        protected void Msg(string msg)  
        {  
            Console.WriteLine("Hello, " + msg);  
        }  
    }  
 


//To acess the protected class *INHERITANCE* is used

class Program  : ProtectedTest
    {  
        static void Main(string[] args)  
       {  
            Program program = new Program();  
             
            Console.WriteLine("Hello " + program.name);  
            
            program.Msg("this is a message");  
        }  
    }  
}