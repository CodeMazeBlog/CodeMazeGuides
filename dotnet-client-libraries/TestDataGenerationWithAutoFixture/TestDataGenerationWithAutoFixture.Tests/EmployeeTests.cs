using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;

namespace TestDataGenerationWithAutoFixture.Tests
{
    public class EmployeeTests
    {
        private readonly IFixture _fixture;

        public EmployeeTests()
        {
            _fixture = new Fixture();
        }

        [Theory, AutoData]
        public void WhenConstructorIsInvoked_ThenValidInstanceIsReturned(
            string firstName, string lastName, int age, decimal salary)
        {
            // Act
            var employee = new Employee(firstName, lastName, age, salary);

            // Assert
            employee.FirstName.Should().Be(firstName);
            employee.LastName.Should().Be(lastName);
            employee.Age.Should().Be(age);
            employee.Salary.Should().Be(salary);
        }

        [Theory, AutoData]
        public void WhenGetFullNameIsInvoked_ThenValidFullNameIsReturned(Employee employee)
        {
            // Act
            var fullName = employee.GetFullName();

            // Assert
            fullName.Length.Should().BeGreaterThan(0);
            fullName.Length.Should()
                .Be(employee.FirstName.Length + employee.LastName.Length + 1);
        }
    }
}