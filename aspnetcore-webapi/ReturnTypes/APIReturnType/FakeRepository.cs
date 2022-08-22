namespace APIReturnType.Controllers
{
    public class FakeRepository
    {
        public List<Employee> Employees { get; set; }

        internal IEnumerable<Employee> GetEmployees()
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

        internal bool TryGetEmployee(int id, out Employee? employee)
        {
            employee = GetEmployees().FirstOrDefault(e => e.Id == id);
            return employee != null;
        }

        internal IEnumerable<Employee> GetActiveEmployees()
        {
            foreach (var employee in GetEmployees())
            {
                Thread.Sleep(3000);
                yield return employee;
            }
        }

        internal async IAsyncEnumerable<Employee> GetActiveEmployeesAsync()
        {
            foreach (var employee in GetEmployees())
            {
                await Task.Delay(3000);
                yield return employee;
            }
        }

        internal async Task AddEmployeeAsync(Employee employee)
        {
        }
    }
}