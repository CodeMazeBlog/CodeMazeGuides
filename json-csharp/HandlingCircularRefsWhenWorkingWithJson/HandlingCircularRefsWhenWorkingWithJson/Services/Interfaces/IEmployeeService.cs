using HandlingCircularRefsWhenWorkingWithJson.Models;

namespace HandlingCircularRefsWhenWorkingWithJson.Services.Interfaces;

public interface IEmployeeService
{
    IReadOnlyCollection<Employee> GetEmployees();
}