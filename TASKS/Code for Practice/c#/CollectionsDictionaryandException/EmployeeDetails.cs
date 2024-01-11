using System;
using System.Collections;
using System.Collections.Generic;
public class EmployeeDetails
{
    Dictionary<string, double> employeedetails = new Dictionary<string, double>();
    double phonenumber;
    string employeename = " ";
    public void addNumber()
    {
        employeedetails.Add("Abishek", 9500441971);
        employeedetails.Add("Monisha", 9360755021);

        try
        {
            int adddetails = 0;
            while (adddetails == 0)
            {
                Console.WriteLine("Add New Phone Numbers to Employee Details");
                Console.WriteLine("Enter the Employee Name: ");
                employeename = Console.ReadLine();
                Console.WriteLine("Enter the Phone Number: ");
                phonenumber = Convert.ToDouble(Console.ReadLine());
                employeedetails.Add(employeename, phonenumber);
                Console.WriteLine("Add Another Number: \n1.Yes\n2.No");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    adddetails = 0;
                }
                else if (choice == 2)
                {
                    adddetails++;
                }
            }
            foreach (var item in employeedetails)
            {
                Console.WriteLine("Name : " + item.Key + " & Phone Number : " + item.Value);
            }
            //Remove Element using Index
            Console.WriteLine("Enter the Index: ");
            int index = Convert.ToInt32(Console.ReadLine());
            int totalcount = 0;
            foreach (var item in employeedetails)
            {
                totalcount++;
            }
            if (totalcount > index)
            {
                employeedetails.Remove(employeedetails.ElementAt(index - 1).Key);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(index), "There is no element in this index.");
            }
        }
        catch (IndexOutOfRangeException exception)
        {
            Console.WriteLine("Error in User Input... Reason : " + exception.Message);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            Console.WriteLine(exception.GetType());
        }
        finally
        {
            foreach (var item in employeedetails)
            {
                Console.WriteLine("Name : " + item.Key + " & Phone Number : " + item.Value);
            }
        }
    }
}