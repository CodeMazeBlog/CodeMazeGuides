namespace DelegateApp
{
    public class DelegateImplementation
    {
        public Func<int, string, EmployeeType, Employee> GetEmployee
            = (id, name, employeeType) => new Employee() { Id = id, Name = name, EmployeeType = employeeType };

        public Action<Employee> Print = (emp) => Console.WriteLine($"{emp.Name} is a {emp.EmployeeType} employee.");

        public delegate bool CheckEmployeeType(Employee emp);
    }
}
