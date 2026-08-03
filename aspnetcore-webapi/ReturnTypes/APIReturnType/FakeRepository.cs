namespace APIReturnType
{
    public class FakeRepository : IFakeRepository
    {
        public List<Employee>? Employees { get; set; }

        public IEnumerable<Employee> GetEmployees()
        {
            Employees = new()
            {
                new Employee()
                {
                    Id = 1,
                    Name = "John Doe",
                    IsActive = true
                },
                new Employee()
                {
                    Id = 2,
                    Name = "Bob Smith",
                    IsActive = false
                },
                new Employee()
                {
                    Id = 3,
                    Name = "Alice Tom",
                    IsActive = true
                }
            };

            return Employees;
        }

        public bool TryGetEmployee(int id, out Employee? employee)
        {
            employee = GetEmployees().FirstOrDefault(e => e.Id == id);
            return employee != null;
        }

        public IEnumerable<Employee> GetActiveEmployees()
        {
            foreach (var employee in GetEmployees())
            {
                Thread.Sleep(10);
                yield return employee;
            }
        }

        public async IAsyncEnumerable<Employee> GetActiveEmployeesAsync()
        {
            foreach (var employee in GetEmployees())
            {
                await Task.Delay(10);
                yield return employee;
            }
        }

        public async Task AddEmployeeAsync(Employee? employee)
        {
        }
    }
}