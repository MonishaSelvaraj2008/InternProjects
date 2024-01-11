//Title: EmployeeDetailsManagementSystem
//Author: Monisha S
//Created on: 18/10/2022
//Updated on: 18/10/2022
//Reviewed by: 
//Reviewed on:

using System;
namespace EmployeeDetailsManagementSystem
{
    public abstract class Employee
    {
        public readonly double bonus = 4500;
        public Employee(){
            bonus = 5500;
        }
        public const string companyName="Aspire Systems";
        private double developerSalary;
        public double DeveloperBasicPay{
            get{return developerSalary;}
            set{developerSalary=value;}
        }
        public double dearnessAllowance;
        public double houseRentAllowance;
        public abstract void calculateDeveloperGrossSalary();
        
    }
    public class Developer: Employee
    {
        double developerGrossSalary;
        public override void calculateDeveloperGrossSalary()
        {
            Console.WriteLine("Company Name : "+companyName);
            DeveloperBasicPay = 40000;
            dearnessAllowance = 0.4 * DeveloperBasicPay;
            houseRentAllowance = 0.2 * DeveloperBasicPay;
            developerGrossSalary = DeveloperBasicPay + dearnessAllowance + houseRentAllowance;
            Console.WriteLine("Developer Salary : "+developerGrossSalary);     
        }
    }
    
    public class Analyst: Developer
    {
        double analystGrossSalary;
        public void calculateAnalystGrossSalary()
        {
            
            DeveloperBasicPay = 45000;
            dearnessAllowance = 0.45 * DeveloperBasicPay;
            houseRentAllowance = 0.2 * DeveloperBasicPay;
            analystGrossSalary = DeveloperBasicPay + dearnessAllowance + houseRentAllowance;
            Console.WriteLine("Analyst Salary : "+analystGrossSalary); 
             
        }
    }
    
    public class Salary
    {
        public static void Main(string[] args)
        {
            Analyst analyst = new Analyst();
            analyst.calculateDeveloperGrossSalary();
            analyst.calculateAnalystGrossSalary();
            Console.WriteLine("Bonus : "+analyst.bonus);
           
            //Nullable<int> hikeForDeveloper = null;
            int? hikeForDeveloper=null;
            int? hikeForAll= hikeForDeveloper ?? 1000;
            Console.WriteLine("Hike: "+hikeForAll);           
        }
    }
}
