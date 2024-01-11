using System;
using System.Linq;
using System.Collections.Generic;

public class Employee
{
    public int employeeId
    {
        get;
        set;
    }
    public string? employeeName
    {
        get;
        set;
    }
    public int employeeSalary
    {
        get;
        set;
    }

    public static void Main()
    {
        List<Employee> employee = new List<Employee>()
        {
            new Employee() {employeeId = 01, employeeName = "Monisha", employeeSalary = 33000},
            new Employee() {employeeId = 02, employeeName = "Nikitha", employeeSalary = 13000},
            new Employee() {employeeId = 03, employeeName = "Anitha", employeeSalary = 33000},
            new Employee() {employeeId = 04, employeeName = "Sandhiya", employeeSalary = 33000}
        };
        var result = from emp in employee
                     group emp by emp.employeeSalary;

        foreach(var value in result)
        {
            Console.WriteLine(value);
        }
        Console.ReadLine();
    }
}