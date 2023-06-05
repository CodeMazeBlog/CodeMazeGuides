using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;

namespace TestDataGenerationWithAutoFixture.Tests
{
    public class DepartmentTests
    {
        private readonly IFixture _fixture;

        public DepartmentTests()
        {
            _fixture = new Fixture();
        }

        [Theory, AutoData]
        public void WhenConstructorIsInvoked_ThenValidInstanceIsReturned(string name)
        {
            // Act
            var department = new Department(name);

            // Assert
            department.Name.Should().Be(name);
            department.Employees.Should().HaveCount(0);
        }

        [Fact]
        public void WhenAddEmployeeIsInvoked_ThenEmployeeIsAddedToTheList()
        {
            // Arrange
            var employee = _fixture.Build<Employee>()
                                   .OmitAutoProperties()
                                   .Create();

            var department = _fixture.Build<Department>()
                .With(x => x.Employees, _fixture.Build<Employee>()
                                               .OmitAutoProperties()
                                               .CreateMany(5)
                                               .ToList())
                .Create();

            // Act
            department.AddEmployee(employee);

            // Assert
            department.Employees.Count.Should().Be(6);
        }

        [Theory, AutoData]
        public void GivenEmployeeExists_WhenGetEmployeeIsInvoked_ThenEmployeeIsReturned(
            string firstName,
            string lastName)
        {
            // Arrange
            var department = _fixture.Build<Department>()
                .With(x => x.Employees, _fixture.Build<Employee>()
                                                .OmitAutoProperties()
                                                .With(x => x.FirstName, firstName)
                                                .With(x => x.LastName, lastName)
                                                .CreateMany(1)
                                                .ToList())
                .Create();

            // Act
            var employee = department.GetEmployee(firstName);

            // Assert
            employee.Should().NotBeNull();
            employee.LastName.Should().Be(lastName);
            employee.Age.Should().BeNull();
        }

        [Fact]
        public void WhenCalculateAverageSalaryIsInvoked_ThenAccurateResultIsReturned()
        {
            // Arrange
            var department = _fixture.Build<Department>()
                .With(x => x.Employees, _fixture.Build<Employee>()
                                                .WithAutoProperties()
                                                .CreateMany(5)
                                                .ToList())
                .Create();

            // Act
            var averageSalary = department.CalculateAverageSalary();

            // Assert
            averageSalary.Should().BeGreaterThan(0);
        }
    }
}
