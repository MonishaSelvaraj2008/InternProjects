using System.Collections.Generic;
namespace FirstApp.Models
{
    public static class Repository
    {
        private static List <Employee> allEmployees = new List<Employee> ();
        public static IEnumerable<Employee> AllEmployees
        {
            get{
                return allEmployees;
            }
          
        }
        public static void Create(Employee employee)
        {
            allEmployees.Add(employee);
        }
    }
}