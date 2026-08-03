using SerializationDemo.Common.Models;

namespace SerializationDemo.Client.Clients
{
    internal interface IClient
    {       
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> CreateEmployee(Employee employee);
    }
}