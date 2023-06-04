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
            var employee = _fixture.Create<Employee>();
            var department = _fixture.Build<Department>()
                .With(x => x.Employees, _fixture.CreateMany<Employee>(5).ToList())
                .Create();

            // Act
            department.AddEmployee(employee);

            // Assert
            department.Employees.Count.Should().Be(6);
        }
    }
}
