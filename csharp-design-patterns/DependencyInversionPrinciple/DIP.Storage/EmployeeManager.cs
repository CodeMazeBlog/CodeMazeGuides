using DIP.Statistics;

namespace DIP.Storage;

public sealed class EmployeeManager : IEmployeeSearchable
{
    private readonly List<Employee> _employees = [];

    public void AddEmployee(Employee employee) => _employees.Add(employee);

    public IEnumerable<Employee> GetEmployeesByGenderAndPosition(Gender gender, Position position) =>
        _employees.Where(e => e.Gender == gender && e.Position == position);
}
