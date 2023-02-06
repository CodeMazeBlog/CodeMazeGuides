using Microsoft.EntityFrameworkCore;
using Moq.EntityFrameworkCore;

namespace Tests
{
    public class EmployeesControllerTestWithMoq_EntityFrameworkCore
    {

        [Fact]
        public async Task GetEmployees_WhenCalled_ReturnsEmployeeListAsync()
        {
            // Arrange
            var employeeContextMock = new Mock<EmployeeDBContext>();
            employeeContextMock.Setup<DbSet<Employee>>(x => x.Employees)
                .ReturnsDbSet(TestDataHelper.GetFakeEmployeeList());

            //Act
            EmployeesController employeesController = new(employeeContextMock.Object);
            var employees = (await employeesController.GetEmployees()).Value;

            //Assert
            Assert.NotNull(employees);
            Assert.Equal(2, employees.Count());
        }

        [Fact]
        public async Task GetEmployeeById_WhenCalled_ReturnsEmployeeAsync()
        {
            // Arrange            
            var employeeContextMock = new Mock<EmployeeDBContext>();
            employeeContextMock.Setup(x => x.Employees.FindAsync(1).Result)
                .Returns(TestDataHelper.GetFakeEmployeeList().Find(e => e.Id == 1) ?? new Employee());

            //Act
            EmployeesController employeesController = new(employeeContextMock.Object);
            var employee = (await employeesController.GetEmployeeById(1)).Value;

            //Assert
            Assert.NotNull(employee);
            Assert.Equal(1, employee.Id);
        }
    }
}