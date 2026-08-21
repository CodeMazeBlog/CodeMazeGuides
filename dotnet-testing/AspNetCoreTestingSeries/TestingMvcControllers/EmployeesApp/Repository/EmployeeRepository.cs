using EmployeesApp.Contracts;
using EmployeesApp.Models;

namespace EmployeesApp.Repository
{
	public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAll() => _context.Employees.ToList();

        public Employee GetEmployee(Guid id) => _context.Employees
            .SingleOrDefault(e => e.Id.Equals(id));

        public void CreateEmployee(Employee employee)
        {
            _context.Add(employee);
            _context.SaveChanges();
        }
    }
}
