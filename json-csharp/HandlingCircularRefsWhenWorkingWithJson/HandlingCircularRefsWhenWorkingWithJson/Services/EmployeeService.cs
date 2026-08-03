using HandlingCircularRefsWhenWorkingWithJson.Models;
using HandlingCircularRefsWhenWorkingWithJson.Services.Interfaces;

namespace HandlingCircularRefsWhenWorkingWithJson.Services;

public class EmployeeService : IEmployeeService
{
    public IReadOnlyCollection<Employee> GetEmployees()
    {
        var manager = new Employee() { Name = "Kate", Surname = "Wilson", Title = "Development Manager" };
        var engineer = new Employee() { Name = "Adam", Surname = "Smith", Title = "Software Engineer", Manager = manager };
        manager.DirectReports.Add(engineer);

        return new[] { manager, engineer }.AsReadOnly();
    }
}