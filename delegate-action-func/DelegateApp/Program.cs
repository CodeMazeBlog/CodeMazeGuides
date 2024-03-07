namespace DelegateApp
{
    public enum EmployeeType { FullTime, PartTime, Contractual }
    public class Employee { public int Id { get; set; } public string Name { get; set; } public EmployeeType EmployeeType { get; set; } }
    internal class Program
    {
        public static Func<int, string, EmployeeType, Employee> GetEmployee
            = (id, name, employeeType) => new Employee() { Id = id, Name = name, EmployeeType = employeeType };

        public static Action<Employee> Print = (emp) => Console.WriteLine($"{emp.Name} is a {emp.EmployeeType} employee.");

        public delegate bool CheckEmployeeType(Employee emp);

        static void Main(string[] args)
        {
            var employees = new Employee[4] {
                GetEmployee(1, "BigB", EmployeeType.FullTime),
                GetEmployee(2, "RDJ", EmployeeType.FullTime),
                GetEmployee(3, "SRK", EmployeeType.PartTime),
                GetEmployee(4, "John Doe", EmployeeType.Contractual)
            };

            DisplayEmployees(employees, IsFullTime);
            DisplayEmployees(employees, IsPartTime);
            DisplayEmployees(employees, IsContractual);
        }

        public static void DisplayEmployees(Employee[] employees, CheckEmployeeType employeeType)
        {
            foreach (Employee emp in employees)
            {
                if (employeeType(emp))
                {
                    Print(emp);
                }
            }
        }

        public static bool IsFullTime(Employee emp) => emp.EmployeeType == EmployeeType.FullTime; 
        public static bool IsPartTime(Employee emp) => emp.EmployeeType == EmployeeType.PartTime; 
        public static bool IsContractual(Employee emp) => emp.EmployeeType == EmployeeType.Contractual;
    }
}
