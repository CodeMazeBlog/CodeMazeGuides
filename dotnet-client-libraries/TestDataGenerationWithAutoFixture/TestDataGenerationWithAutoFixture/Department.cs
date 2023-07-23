namespace TestDataGenerationWithAutoFixture
{
    public class Department
    {
        private readonly IPayrollService _payrollService;

        public string Name { get; set; }
        public Manager Manager { get; set; }
        public List<Employee> Employees { get; set; }

        public Department(string name, Manager manager, IPayrollService payrollService)
        {
            Name = name;
            Manager = manager;
            Employees = new List<Employee>();
            _payrollService = payrollService;
        }

        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }

        public Employee? GetEmployee(string firstName)
        {
            return Employees
                .FirstOrDefault(e => e.FirstName == firstName);
        }

        public decimal CalculateAverageSalary()
        {
            if (!Employees.Any())
            {
                return 0;
            }

            return Employees.Average(e => e.Salary);
        }
    }
}