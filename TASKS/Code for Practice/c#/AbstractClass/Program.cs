//Title: Abstract Class
//Author: Monisha S
//Created at: 30/09/2022
//Updated at: 02/10/2022
//Reviewed by: 
//Reviewed at:
using System;
abstract class Salary  
    {  
        public const int firstMonthSalary = 30000;  
        public readonly int secondMonthSalary;  
  
        public  Salary()  
        {  
            secondMonthSalary = 40000;  
        }  
  
        abstract public void Call();  
    }  
  
    class Output : Salary
    {  
        public  override void Call()     //Use of sealed Keyword  
        {  
            Console.WriteLine("  firstMonth ={0}  secondMonth= {1}", firstMonthSalary, secondMonthSalary);  
        }  
    }  
  
    class Employee : Output
    {  
        public override    void Call()  
        {  
            Console.WriteLine("Monisha");  
        }  
    }  
    class Final
    {  
          
        static void Main(string[] args)  
        {  
            Employee  employee = new Employee();  
            employee.Call();  
        }  
  
    }
