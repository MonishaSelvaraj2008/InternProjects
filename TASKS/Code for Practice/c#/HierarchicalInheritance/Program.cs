//Title: Hierarchical Inheritance
//Author: Monisha S
//Created on: 06/10/2022
//Updated on: 06/10/2022
//Reviewed by: 
//Reviewed on:

using System;
namespace HierarchicalInheritance
{
    public class Employee
    {
        public void displayEmployee()
        {
            Console.WriteLine("also an employee");
        }
    }
    
    public class Manager: Employee
    {
        public void displayManager()
        {
            Console.WriteLine("I am a manager");
        }
    }
    
    public class Accountant: Employee
    {
        public void displayAccountant()
        {
            Console.WriteLine("I am an accountant");
        }   
    }
    
    public class Output
    {
        public static void Main(string[] args)
        {
            Manager manager = new Manager();
            Accountant accountant = new Accountant();
            
            manager.displayManager();
            manager.displayEmployee();  // accessing parent class
            
            accountant.displayAccountant();
            accountant.displayEmployee();   // accessing parent class
            
            double basicSalary = 30000;
            double dearnessAllowance = 0.4 * basicSalary;
            double    houseRentAllowance = 0.2 * basicSalary;
            double  grossSalary = basicSalary - dearnessAllowance - houseRentAllowance;
        
            Console.WriteLine("Gross Salary : "+grossSalary);
        }
    }
}