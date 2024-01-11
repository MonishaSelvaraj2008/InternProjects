//Title: Nullable Keyword
//Author: Monisha S
//Created on: 11/10/2022
//Updated on: 11/10/2022
//Reviewed by: 
//Reviewed on:

using System;
class Program {
 
    // Main Method
    static void Main(string[] args)
    {
         
        Nullable<int> employeeOneBonus = null;
        Console.WriteLine(employeeOneBonus.GetValueOrDefault());
        Console.WriteLine(employeeOneBonus);

        int? employeeTwoBonus = 200;
        Console.WriteLine(employeeTwoBonus);

         
        int? employeeThreeBonus = 300;
        Console.WriteLine(employeeThreeBonus.GetValueOrDefault());
         
        Nullable<int> employeeFourBonus = 400;
        Console.WriteLine(employeeFourBonus.GetValueOrDefault());

        int? hikeForEmployeeOne=null;
        int? hikeForAll= hikeForEmployeeOne ?? 500;
        Console.WriteLine(hikeForAll);
         
    }
     
}