using EFCoreMocking.Controllers;
using EFCoreMocking.Data;
using EFCoreMocking.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;

namespace Tests
{
    public class EmployeesControllerTestWithMoq_EntityFrameworkCore
    {

        [Fact]
        public void GetEmployee_WhenCalled_ReturnsEmployeeList()
        {
            // Arrange
            var employeeContextMock = new Mock<EmployeeDBContext>();
            employeeContextMock.Setup<DbSet<Employee>>(x => x.Employees)
                .ReturnsDbSet(TestDataHelper.GetFakeEmployeeList());

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
            var employeeContextMock = new Mock<EmployeeDBContext>();
            employeeContextMock.Setup(x => x.Employees.FindAsync(1).Result)
                .Returns(TestDataHelper.GetFakeEmployeeList().Find(e => e.Id == 1) ?? new Employee());

            //Act
            EmployeesController employeesController = new(employeeContextMock.Object);
            var employee = employeesController.GetEmployeeById(1).Result.Value;

            //Assert
            Assert.NotNull(employee);
            Assert.Equal(1, employee.Id);
        }
    }
}