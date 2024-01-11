//Title: Single Inheritance
//Author: Monisha S
//Created on: 26/09/2022
//Updated on: 26/09/2022
//Reviewed by: 
//Reviewed on:
using System;
namespace StaticKeyword {

  class Student {

    // static variable
    public static string department = "Computer Science";
  }

  class Program {
    static void Main(string[] argos) {
    
      // access static variable
      Console.WriteLine("Department: " + Student.department);
     
      Console.ReadLine();
    }
  }
}