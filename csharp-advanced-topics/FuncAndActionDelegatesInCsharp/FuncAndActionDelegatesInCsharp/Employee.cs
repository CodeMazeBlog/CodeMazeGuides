using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FuncAndActionDelegatesInCsharp
{
    public class Employee
    {
        public Employee(string name, int age)
        {
            eName = name;
            eAge = age;
        }
        public string eName { get; set; }
        public int eAge { get; set; }

        public static List<Employee> getEmployeeList()
        {
            List<Employee> employeeList = new List<Employee>();
            employeeList.Add(new Employee("Jacob", 25));
            employeeList.Add(new Employee("Washington", 35));
            employeeList.Add(new Employee("Alex", 34));
            employeeList.Add(new Employee("Nani", 27));
            employeeList.Add(new Employee("Jack", 40));
            employeeList.Add(new Employee("Kia", 42));
            employeeList.Add(new Employee("Trump", 50));

            return employeeList;
        }
        public static List<Employee> searchByNameOrAge(List<Employee> employees, string name = "", int age = 0)
        {
            Expression<Func<Employee, bool>> findByName = x => true;
            Expression<Func<Employee, bool>> findByAge = x => true;
            if (name != "")
            {
                findByName = (n) => n.eName.Contains(name);
            }
            if (age > 0)
            {
                findByAge = (a) => a.eAge >= age;
            }

            // identify parameter need to be passed in other 2 expressions
            var parameter = Expression.Parameter(typeof(Employee), "param");
            //invoke both expression by given parameter and combine by AND Operator
            var mappedExpression = Expression.And(Expression.Invoke(findByName, parameter), Expression.Invoke(findByAge, parameter));
            //producing expresion which can be used in linq query
            var finalExpression = Expression.Lambda<Func<Employee, bool>>(mappedExpression, parameter).Compile();
            var searchResult = employees.Where(x => finalExpression(x)).ToList();
            return searchResult;
        }
    }
}
