namespace UnitTests;

using DelegatesInLINQ;
using Xunit;

public class EmployeeServiceUnitTests
{
    [Fact]
    public void WhenGetActiveEmployeesCountIsInvokedAndThereAreActiveEmployees_ThenItShouldRerturnCorrectCount()
    {
        // Arrange
        var activeEmployees = new List<Employee>() {
            new() { IsActive = true },
            new() { IsActive = true },
            new() { IsActive = true },
        };

        var inactiveEmployees = new List<Employee>() {
            new() { IsActive = false },
            new() { IsActive = false },
        };

        var allEmployees = activeEmployees.Union(inactiveEmployees);

        // Act
        var activeEmployeesCount = EmployeeService.GetActiveEmployeesCount(allEmployees);

        // Assert
        Assert.Equal(activeEmployees.Count, activeEmployeesCount);
    }
}