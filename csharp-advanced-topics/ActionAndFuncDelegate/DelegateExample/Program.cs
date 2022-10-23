using DelegateExample.Models;

namespace DelegateExample
{
    public class Program
    {
        public static string GetName(Employee employee)
        {
            return employee.Name;
        }
        public static void PrintName(Employee employee)
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

            Func<Employee, string> NameSelector = new(GetName);

            IEnumerable<string> names = employees.Select(NameSelector);

            foreach (var item in names)
            {
                Console.WriteLine($"Name from Func, {item}");
            }

            Console.WriteLine("-----------------------------------------");

            Action<Employee> NamePrinter = PrintName;

            employees.ForEach(NamePrinter);
        }
    }
}