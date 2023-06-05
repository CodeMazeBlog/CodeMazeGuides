namespace TestDataGenerationWithAutoFixture
{
    public class Department
    {
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }

        public Department(string name)
        {
            Name = name;
            Employees = new List<Employee>();
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

        public decimal? CalculateAverageSalary()
        {
            if (!Employees.Any())
            {
                return 0;
            }

            decimal? sumOfSalaries = Employees.Sum(e => e.Salary);

            return sumOfSalaries / Employees.Count;
        }
    }
}
