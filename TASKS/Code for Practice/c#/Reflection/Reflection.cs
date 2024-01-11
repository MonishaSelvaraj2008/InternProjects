using System.Reflection;
namespace Reflection
{
    public class Program
    {
        public static void Main(String[] args)
        {
            try
            {
                EmployeeName employeename = new EmployeeName();
                Type type = typeof(EmployeeName);
                Console.WriteLine("Name :" + type.GetField("name", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(employeename));
                type.GetField("name", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(employeename, Console.ReadLine());
                type.GetMethod("addDetails", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(new EmployeeName(), null);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}