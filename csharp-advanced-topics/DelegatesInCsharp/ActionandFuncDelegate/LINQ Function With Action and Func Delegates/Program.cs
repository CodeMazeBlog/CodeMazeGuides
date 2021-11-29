using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Function_With_Action_and_Func_Delegates
{
    class Program
    {
        // Class of Employee
        public class Employee
        {
            public string Name { get; set; }
            public double Salary { get; set; }
            public float Experience { get; set; }
        }

        static void Main(string[] args)
        {
            // List of Employees
            List<Employee> employees  = new List<Employee>();
            // Let's Add some Data in List
            employees.Add(new Employee { Name = "Mark", Salary = 1000, Experience = 3 });
            employees.Add(new Employee { Name = "John", Salary = 2000, Experience = 4 });
            employees.Add(new Employee { Name = "Daniel", Salary = 3000, Experience = 5 });

            // Let's use some LINQ function that Use Func Delegate
            // There are several LINQ function that uses Fuction delegate , we can either pass Fucntion reference or use Lambda expressions to get data .
            
            var averageSalary = employees.Average(x => x.Salary);
            Console.WriteLine($"Employee Average Salary is {averageSalary}");

            // Let's Try some fucntion with Action Delegate

            employees.ForEach(x => { if (x.Experience > 3) Console.WriteLine($"Employees Whose Experience is greater than 1 : {x.Name}"); });

        }
    }
}

