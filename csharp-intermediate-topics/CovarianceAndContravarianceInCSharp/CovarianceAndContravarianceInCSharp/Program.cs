using System;

namespace CovarianceAndContravarianceInCSharp
{
    public class Program
    {
        delegate void personDelegate(Employee employee);

        static void Main(string[] args)
        {
            var personObject = new Person();
            var employeeObject = new Employee();
            var managerObject = new Manager();

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

        public static void GreetPerson(Person person)
        {
            // Logic to greet person.
        }

        public static Manager GetEmployeeManager(string employeeFullName)
        {
            // Logic to find employee's manager.
            return new Manager();
        }

        public static void EvaluatePerformance(Employee employee)
        {
            // Logic to evaluate performance.
        }

        public class Person { }
        public class Employee : Person { }
        public class Manager : Employee { }

        public interface ICovariant<out T> { }
        public interface IContravariant<in T> { }

        public class ImplementICovariant<T> : ICovariant<T> { }
        public class ImplementIContravariant<T> : IContravariant<T> { }
    }
}
