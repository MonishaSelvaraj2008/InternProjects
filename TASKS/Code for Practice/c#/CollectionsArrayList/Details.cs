using System;
using System.Collections;
using System.Collections.Generic;
class EmployeeDetails
{
    ArrayList employeelist = new ArrayList();
    string employeeName = " ";
    void addEmployee()
    {
        int adddetails = 0;
        while (adddetails == 0)
        {
            Console.WriteLine("Enter the Employee Name: ");
            employeeName = Console.ReadLine();
            employeelist.Add(employeeName);
            Console.WriteLine("Add Another Name: \n1.Yes\n2.No");
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
    }
    void removeEmployee()
    {
        Console.WriteLine("1.Remove using Employee Name \n2.Remove song using S.No");
        int choice = Convert.ToInt32(Console.ReadLine());
        if (choice == 1)
        {
            Console.WriteLine("Enter the Employee Name: ");
            employeeName = Console.ReadLine();
            employeelist.Remove(employeeName);
        }
        else if (choice == 2)
        {
            Console.WriteLine("Enter the ID of the Employee: ");
            int employeeId = Convert.ToInt32(Console.ReadLine());
            employeelist.RemoveAt(employeeId - 1);
        }
    }
    void sortList()
    {
        employeelist.Sort();
    }
    void reverseList()
    {
        employeelist.Reverse();
    }
    void displayList()
    {
        foreach (string item in employeelist)
        {
            Console.WriteLine("Employee Name : " + item);
        }
        Console.WriteLine(employeelist.Capacity);
    }
    void convertToArray()
    {
        object[] obj = employeelist.ToArray();
        foreach (string item in employeelist)
        {
            Console.WriteLine("EMployee Name : " + item);
        }
        Console.WriteLine(employeelist.Capacity);
    }
    public void displayMenu()
    {
        Console.WriteLine("***********************************MENU***************************************");
        Console.WriteLine("1.Add Employee to List \n2.Sort List \n3.Reverse List \n4.Remove employee from the List \n5.Convert ArrayList to Array\n6.Exit");
        int choice = Convert.ToInt32(Console.ReadLine());
        if (choice == 1)
        {
            addEmployee();
            displayList();
            displayMenu();
        }
        else if (choice == 2)
        {
            sortList();
            displayList();
            displayMenu();
        }
        else if (choice == 3)
        {
            reverseList();
            displayList();
            displayMenu();
        }
        else if (choice == 4)
        {
            removeEmployee();
            displayList();
            displayMenu();
        }
        else if (choice == 5)
        {
            convertToArray();
            displayMenu();
        }
        else { }
    }
}
