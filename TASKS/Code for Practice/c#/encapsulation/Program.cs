//Title: Encapsulation
//Author: Monisha S
//Created on: 28/09/2022
//Updated on: 28/09/2022
//Reviewed by: 
//Reviewed on:

using System;
namespace EncapsulationExampleProgram{
    public class Encapsulation{
        private String employeeName;
        private int employeeAge;

    
    public String Name{
        get{
            return employeeName;
        }
        set{
            employeeName=value;
        }
    }
    public int Age{
        get{
            return employeeAge;
        }
        set{
            employeeAge=value;
        }
    }
    }
    class Output{
        //main method
       public static void Main()
        {
            Encapsulation encapsulation = new Encapsulation();
            encapsulation.Name="Monisha";
            encapsulation.Age=21;
            Console.WriteLine("Employee Name: "+encapsulation.Name);
            Console.WriteLine("Employee Age: "+encapsulation.Age);
        } 
    }
}
