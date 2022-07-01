using System;

namespace CovarianceAndContravarianceInCSharp
{
    class Program
    {
        delegate void personDelegate(Employee employee);

        static void Main(string[] args)
        {
            Person personObject = new Person();
            Employee employeeObject = new Employee();
            Manager managerObject = new Manager();

            personObject = employeeObject;
            personObject = managerObject;

            personDelegate del = GreetPerson;

            Person[] people = new Employee[5];
            people[0] = managerObject;

            Func<string, Manager> getManager = GetEmployeeManager;
            Func<string, Employee> getEmployee = GetEmployeeManager;
            getEmployee = getManager;

            Action<Employee> evaluateEmployeePerformance = EvaluatePerformance;
            Action<Manager> evaluateManagerPerformance = EvaluatePerformance;
            evaluateManagerPerformance = evaluateEmployeePerformance;

            ICovariant<Person> icovPerson = new ImplementICovariant<Person>();
            ICovariant<Employee> icovEmployee = new ImplementICovariant<Employee>();
            icovPerson = icovEmployee;

            IContravariant<Person> icontraPerson = new ImplementIContravariant<Person>();
            IContravariant<Employee> icontraEmployee = new ImplementIContravariant<Employee>();
            icontraEmployee = icontraPerson;
        }

        static void GreetPerson(Person person)
        {
            // Logic to greet person.
        }

        static Manager GetEmployeeManager(string employeeFullName)
        {
            // Logic to find employee's manager.
            return new Manager();
        }

        static void EvaluatePerformance(Employee employee)
        {
            // Logic to evaluate performance.
        }

        public class Person { }
        public class Employee : Person { }
        public class Manager : Employee { }

        interface ICovariant<out T> { }
        interface IContravariant<in T> { }

        class ImplementICovariant<T> : ICovariant<T> { }
        class ImplementIContravariant<T> : IContravariant<T> { }
    }
}
