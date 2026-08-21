using EmployeesApp.Models;

namespace EmployeesApp.Contracts
{
	public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetEmployee(Guid id);
        void CreateEmployee(Employee employee);
    }
}
