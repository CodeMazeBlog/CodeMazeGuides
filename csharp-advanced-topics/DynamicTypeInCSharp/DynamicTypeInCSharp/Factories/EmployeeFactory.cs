using DynamicTypeInCSharp.Models;

namespace DynamicTypeInCSharp.Factories;

public class EmployeeFactory
{
    private readonly List<Employee> _employees = [];

    public void Add(Employee employee)
    {
        _employees.Add(employee);
    }

    public object GetFirstEmployee()
    {
        return _employees.First();
    }
}
