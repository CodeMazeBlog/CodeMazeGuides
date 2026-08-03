using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;

namespace TestDataGenerationWithAutoFixture.Tests
{
    public class DepartmentTests
    {
        private readonly IFixture _fixture;

        public DepartmentTests()
        {
            _fixture = new Fixture()
                .Customize(new AutoMoqCustomization()
                {
                    ConfigureMembers = true
                });
        }

        [Theory, AutoData]
        public void WhenConstructorIsInvoked_ThenValidInstanceIsReturned(string name)
        {
            // Act
            var manager = new Mock<Manager>();
            var payrollService = new Mock<IPayrollService>();
            var department = new Department(name, manager.Object, payrollService.Object);

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

            var employees = _fixture.Build<Employee>()
                .OmitAutoProperties()
                .CreateMany(5)
                .ToList();

            var department = _fixture.Build<Department>()
                .With(x => x.Employees, employees)
                .Create();

            // Act
            department.AddEmployee(employee);

            // Assert
            department.Employees.Count.Should().Be(6);
        }

        [Theory, AutoData]
        public void GivenEmployeeExists_WhenGetEmployeeIsInvoked_ThenEmployeeIsReturned(
            string firstName, string lastName)
        {
            // Arrange
            var employees = _fixture.Build<Employee>()
                .OmitAutoProperties()
                .With(x => x.FirstName, firstName)
                .With(x => x.LastName, lastName)
                .CreateMany(1)
                .ToList();

            var department = _fixture.Build<Department>()
                .With(x => x.Employees, employees)
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
            var employees = _fixture.Build<Employee>()
                .WithAutoProperties()
                .CreateMany(5)
                .ToList();

            var department = _fixture.Build<Department>()
                .With(x => x.Employees, employees)
                .Create();

            // Act
            var averageSalary = department.CalculateAverageSalary();

            // Assert
            averageSalary.Should().BeGreaterThan(0);
            department.Manager.Should().NotBeNull();
            department.Manager.Name.Should().NotBeNull();
        }

        [Fact]
        public void GivenNoEmployees_WhenCalculateAverageSalaryIsInvoked_ThenZeroIsReturned()
        {
            // Arrange
            var employees = _fixture.Build<Employee>()
                .CreateMany(0)
                .ToList();

            var department = _fixture.Build<Department>()
                .With(x => x.Employees, employees)
                .Create();

            // Act
            var averageSalary = department.CalculateAverageSalary();

            // Assert
            averageSalary.Should().Be(0);
        }
    }
}
