using DIP.Statistics;

namespace DIP.Tests;

internal sealed class FakeEmployeeSearch(params Employee[] employees) : IEmployeeSearchable
{
    public IEnumerable<Employee> GetEmployeesByGenderAndPosition(Gender gender, Position position) =>
        employees.Where(e => e.Gender == gender && e.Position == position);
}
