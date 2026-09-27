using DIP.Statistics;
using Xunit;

namespace DIP.Tests;

public class EmployeeStatisticsTests
{
    [Fact]
    public void CountFemaleManagers_CountsOnlyFemaleManagers()
    {
        var employees = new FakeEmployeeSearch(
            new Employee("Leen", Gender.Female, Position.Manager),
            new Employee("Ana", Gender.Female, Position.Manager),
            new Employee("Eve", Gender.Female, Position.Executive),
            new Employee("Mike", Gender.Male, Position.Manager));

        var statistics = new EmployeeStatistics(employees);

        Assert.Equal(2, statistics.CountFemaleManagers());
    }
}
