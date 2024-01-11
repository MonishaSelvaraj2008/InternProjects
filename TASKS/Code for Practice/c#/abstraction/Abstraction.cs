//Title: Abstraction
//Author: Monisha S
//Created at: 28/09/2022
//Updated at: 28/09/2022
//Reviewed by: 
//Reviewed at:
using System;
namespace AbstractionExampleProgram{
    abstract class Abstraction{
        public abstract void displayAbstractMethod();
    }
    interface Interface{
        void displayInterfaceMethod();
    }
    class Output : Abstraction, Interface
    {
        public override void displayAbstractMethod()
        {
            Console.WriteLine("This is the Abstract method");
        }
        public void displayInterfaceMethod()
        {
            Console.WriteLine("It is the Inheritance method");
        }
    }
    class Input{
        public static void Main(String[] args){
            Abstraction abstractionObject = new Output();
            Interface inheritanceObject = new Output();
            abstractionObject.displayAbstractMethod();
            inheritanceObject.displayInterfaceMethod();
}
}
}