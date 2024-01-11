//Title: Single Inheritance
//Author: Monisha S
//Created on: 05/10/2022
//Updated on: 06/10/2022
//Reviewed by: 
//Reviewed on:

using System;
public class Employee
{
    public string name="Monisha";
    
            
}
internal class Id : Employee
{
    public int idNumber=01; 
}
public class Salary : Employee
{
    public float wages=300;
    public float bonus=50;

}

public class Output
{
    public static void Main(string[] args)
    {
        double basicSalary = 30000;
        double dearnessAllowance = 0.4 * basicSalary;
        double    houseRentAllowance = 0.2 * basicSalary;
        double  grossSalary = basicSalary - dearnessAllowance - houseRentAllowance;
        Salary salary= new Salary();
        Id id=new Id();
        
        Console.WriteLine("Name : "+salary.name);
        Console.WriteLine("Wages : "+ salary.wages);
        Console.WriteLine("Bonus : "+ salary.bonus);
        Console.WriteLine("ID : "+ id.idNumber);
        Console.WriteLine("Gross Salary : "+grossSalary);
    }
}