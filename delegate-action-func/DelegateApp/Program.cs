using static DelegateApp.DelegateImplementation;

namespace DelegateApp
{

    internal class Program
    {
        static void Main(string[] args)
        {
            var implementations = new DelegateImplementation();

            var employees = new Employee[4] {
                implementations.GetEmployee(1, "BigB", EmployeeType.FullTime),
                implementations.GetEmployee(2, "RDJ", EmployeeType.FullTime),
                implementations.GetEmployee(3, "SRK", EmployeeType.PartTime),
                implementations.GetEmployee(4, "John Doe", EmployeeType.Contractual)
            };

            DisplayEmployees(implementations, employees, IsFullTime);
            DisplayEmployees(implementations, employees, IsPartTime);
            DisplayEmployees(implementations, employees, IsContractual);
        }

        public static void DisplayEmployees(
            DelegateImplementation implementation,
            Employee[] employees,
            CheckEmployeeType employeeType)
        {
            foreach (Employee emp in employees)
            {
                if (employeeType(emp))
                {
                    implementation.Print(emp);
                }
            }
        }

        public static bool IsFullTime(Employee emp) => emp.EmployeeType == EmployeeType.FullTime;
        public static bool IsPartTime(Employee emp) => emp.EmployeeType == EmployeeType.PartTime;
        public static bool IsContractual(Employee emp) => emp.EmployeeType == EmployeeType.Contractual;
    }
}
