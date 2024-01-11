//Title: Static Constructor
//Author: Monisha S
//Created on: 03/01/2023
//Updated on: 03/01/2023
//Reviewed by: 
//Reviewed on:

using System;
public class Account
{
    public int id;
    public String name;
    public static float rateOfInterest;
    public Account(int id, String name)
    {
        this.id = id;
        this.name = name;
    }
    static Account()
    {
        rateOfInterest = 9.5f;
    }
    public void display()
    {
        Console.WriteLine(id + " " + name + " " + rateOfInterest);
    }
}
class TestEmployee
{
    public static void Main(string[] args)
    {
        Account a1 = new Account(1, "Abi");
        Account a2 = new Account(2, "Monisha");
        a1.display();
        a2.display();

    }
}