using EFCoreMocking.Controllers;
using EFCoreMocking.Data;
using MockQueryable.Moq;
using Moq;

namespace Tests
{
    public class EmployeesControllerTestWithMockQueryable
    {

        [Fact]
        public void GetEmployee_WhenCalled_ReturnsEmployeeList()
        {
            // Arrange
            var mock = TestDataHelper.GetFakeEmployeeList().BuildMock().BuildMockDbSet();
            var employeeContextMock = new Mock<EmployeeDBContext>();
            employeeContextMock.Setup(x => x.Employees).Returns(mock.Object);

            //Act
            EmployeesController employeesController = new(employeeContextMock.Object);
            var employees = employeesController.GetEmployee().Result.Value;

            //Assert
            Assert.NotNull(employees);
            Assert.Equal(2, employees.Count());
        }

        [Fact]
        public void GetEmployeeById_WhenCalled_ReturnsEmployee()
        {
            // Arrange
            var mock = TestDataHelper.GetFakeEmployeeList().BuildMock().BuildMockDbSet();
            mock.Setup(x => x.FindAsync(1)).ReturnsAsync(
                TestDataHelper.GetFakeEmployeeList().Find(e => e.Id == 1));

            var employeeContextMock = new Mock<EmployeeDBContext>();
            employeeContextMock.Setup(x => x.Employees)
                .Returns(mock.Object);

            //Act
            EmployeesController employeesController = new(employeeContextMock.Object);
            var employee = employeesController.GetEmployeeById(1).Result.Value;

            //Assert
            Assert.NotNull(employee);
            Assert.Equal(1, employee.Id);
        }

    }
}