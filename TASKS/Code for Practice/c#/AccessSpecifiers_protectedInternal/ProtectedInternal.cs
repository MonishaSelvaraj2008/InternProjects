//Title: Access Specifiers protected internal keyword
//Author: Monisha S
//Created on: 28/09/2022
//Updated on: 28/09/2022
//Reviewed by: 
//Reviewed on:
using System;  
namespace ProtectedInternal  
{  
    class ProtectedInternalTest  
    {  
        protected internal string name = "Monisha";  
        protected internal void Msg(string msg)  
        {  
            Console.WriteLine("Hello, " + msg);  
        }  
    }  
    class Program  
    {  
        static void Main(string[] args)  
        {  
            ProtectedInternalTest protectedInternalTest = new ProtectedInternalTest();  
            // Accessing public variable  
            Console.WriteLine("Hello " + protectedInternalTest.name);  
            // Accessing public function  
            protectedInternalTest.Msg("this is a message");  
        }  
    }  
}  

//Variable or function declared protected internal can be accessed in the assembly in which it is declared. 
//It can also be accessed within a derived class in another assembly.