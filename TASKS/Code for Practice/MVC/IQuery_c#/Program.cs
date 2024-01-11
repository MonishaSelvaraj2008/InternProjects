using System;
using System.Linq;
using System.Collections.Generic;

internal class Program
{

    private static void Main(string[] args)
    {
        List <string> countries = new List<string>();
        countries.Add("India");
        countries.Add("China");
        countries.Add("Japan");
        countries.Add("Russia");

        //LINQ query to retrive all elements in the list
        IEnumerable <string> result = countries.Select(countryname => countryname);

        foreach(var values in result)
        {
            Console.WriteLine(values);
        }
        Console.ReadLine();
    }
}