using DelegateExample.Models;

namespace DelegateExample
{
    public class Program
    {
        static string GetName(Employee employee)
        {
            return employee.Name;
        }
        static void PrintName(Employee employee)
        {
            Console.WriteLine($"Name from Action, {employee.Name}");
        }
        public static void Main()
        {
            List<Employee> employees = new()
            {
                new Employee() { Name = "John", Age = 20 },
                new Employee() { Name = "Lora", Age = 25 }
            };

            //Create a Func delegte and assigning a GetName method to it
            Func<Employee, string> NameSelector = new(GetName);

            //Select all names 
            IEnumerable<string> names = employees.Select(NameSelector);

            //Loop in the names and type them
            foreach (var item in names)
            {
                Console.WriteLine($"Name from Func, {item}");
            }

            Console.WriteLine("-----------------------------------------");

            //Create an action delegte and assigning a PrintName method to it
            Action<Employee> NamePrinter = PrintName;
            //Loop in the employees and type the names by using action delegate.
            employees.ForEach(NamePrinter);
        }
    }
}