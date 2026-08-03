using SerializationDemo.Common.Models;

namespace SerializationDemo.EmployeeApi.Repositories
{
    public interface IEmployeeRepository
    {
        void Create(Employee employee);
        List<Employee> GetAll();
    }
}
