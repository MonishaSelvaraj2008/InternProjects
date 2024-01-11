using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SelectMany
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[][] arrays = 
            {
            new[] {1, 2, 3},
            new[] {4},
            new[] {5, 6, 7, 8},
            new[] {12, 14}
            };
            // Will return { 1, 2, 3, 4, 5, 6, 7, 8, 12, 14 }
            IEnumerable<int> result = arrays.SelectMany(array => array);
            Console.WriteLine(result);
        }
    }
}