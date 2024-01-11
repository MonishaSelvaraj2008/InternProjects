using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilterOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words={"Sandhiya","Boondhiya","Vishal","Moni"};
            IEnumerable <string> query = from word in words
                                         where word.Length==3
                                         select word;
            foreach(string str in query)
            {
                Console.WriteLine(str);
            }
            Console.ReadLine();
        }
    }
}