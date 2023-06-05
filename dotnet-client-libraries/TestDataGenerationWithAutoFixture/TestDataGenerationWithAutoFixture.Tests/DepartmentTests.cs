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
        public void GivenEmployeeExists_WhenGetEmployeeIsInvoked_ThenEmployeeIsReturned(string name)
        {
            // Arrange
            var department = _fixture.Build<Department>()
                .With(x => x.Employees, _fixture.Build<Employee>()
                                                .OmitAutoProperties()
                                                .With(x => x.FirstName, name)
                                                .CreateMany(1)
                                                .ToList())
                .Create();

            // Act
            var employee = department.GetEmployee(name);

            // Assert
            employee.Should().NotBeNull();
            employee.FirstName.Should().Be(name);
            employee.LastName.Should().BeNull();
        }
    }
}
