using SerializationDemo.Common.Models;

namespace SerializationDemo.EmployeeApi.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Dictionary<Guid, Employee> _employees = new();
        private Random _rnd = new Random();
        public EmployeeRepository()
        {
            InitializeEmployeeStore();
        }       

        public List<Employee> GetAll()
        {
            return _employees.Values.ToList();
        }

        public void Create(Employee employee)
        {
            if (employee == null)
            {
                return;
            }
            _employees[employee.Id] = employee;
        }

        private void InitializeEmployeeStore()
        {
            //Creating 5 random sample employees
            for (var i = 0; i < 5; i++)
            {
                var id = Guid.NewGuid();
                _employees.Add(id, new Employee
                {
                    Id = id,
                    Name = $"TestEmployee{i + 1}",
                    Address = new Address
                    {
                        AddressLine1 = $"Street #{i + 1}",
                        AddressLine2 = $"District #{i + 1}",
                        City = $"Sample City{_rnd.Next(1, 5)}",
                        Country = $"Sample Country{_rnd.Next(1, 5)}",
                    }
                });
            }
        }
    }
}