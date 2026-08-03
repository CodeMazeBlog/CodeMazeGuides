using AutoFacFakeItEasy.Models;

namespace AutoFacFakeItEasy.Services;

public class EmployeeService(IEmployeeService employeeService)
{
    public Employee GetEmployeeById(long id)
    {
        return employeeService.GetById(id);
    }

    public List<Employee> GetAllEmployees()
    {
        return employeeService.GetAll();
    }
}