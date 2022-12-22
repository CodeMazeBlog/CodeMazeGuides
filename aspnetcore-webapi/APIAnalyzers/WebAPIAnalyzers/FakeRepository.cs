namespace WebAPIAnalyzers
{
    public class FakeRepository : IFakeRepository
    {
        public bool TryGetEmployee(int id, out Employee? employee)
        {
            employee = GetEmployees().FirstOrDefault(e => e.Id == id);
            return employee != null;
        }

        public List<Employee>? Employees { get; set; }

        public IEnumerable<Employee> GetEmployees()
        {
            Employees = new()
            {
                new Employee()
                {
                    Id = 1,
                    Name = "John Doe"
                },
                new Employee()
                {
                    Id = 2,
                    Name = "Bob Smith"
                },
                new Employee()
                {
                    Id = 3,
                    Name = "Alice Tom"
                }
            };

            return Employees;
        }
    }
}
