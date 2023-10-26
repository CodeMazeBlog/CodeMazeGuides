using System;
using Xunit;
using GenericDelegates;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace TestGenericDelegates
{
    public class EmployeeTest
    {
        [Fact]
        public void GetEmployeeByCity_ValidCity_ReturnsCorrectEmployees()
        {
            // Arrange
            var employees = GetTestEmployeeList();
            string testCity = "NYC";

            // Act
            var result = Employee.GetEmployeeByCity(employees, testCity);

            // Assert
            Assert.Equal(2, result.Count());
            Assert.True(result.All(e => e.City == testCity));
        }

        [Fact]
        public void GetEmployeeByCity_InvalidCity_ReturnsEmptyList()
        {
            // Arrange
            var employees = GetTestEmployeeList();
            string testCity = "InvalidCity";

            // Act
            var result = Employee.GetEmployeeByCity(employees, testCity);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void PrintEmployeeDetailById_ValidId_PrintsCorrectDetails()
        {
            // Arrange
            var employees = GetTestEmployeeList();
            int testId = 1;
            var expectedOutput = $"Employee with EmployeeId {testId}{Environment.NewLine}Name: John Doe, Role: Software Engineer, City: BLR{Environment.NewLine}";

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                Employee.PrintEmployeeDetailById(employees, testId);

                // Assert
                var result = sw.ToString();
                Assert.Equal(expectedOutput, result);
            }
        }

        [Fact]
        public void PrintEmployeeDetailById_InvalidId_PrintsNothing()
        {
            // Arrange
            var employees = GetTestEmployeeList();
            int testId = 999;

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                Employee.PrintEmployeeDetailById(employees, testId);

                // Assert
                var result = sw.ToString();
                Assert.True(string.IsNullOrWhiteSpace(result));
            }
        }

        private List<Employee> GetTestEmployeeList()
        {
            return new List<Employee>
            {
                new Employee(1, "John Doe", 'M', "BLR", "Software Engineer"),
                new Employee(2, "Jane Smith", 'M', "Texas", "Project Manager"),
                new Employee(3, "Alice Brown",'M' ,"HYD","QA Engineer"),
                new Employee(4, "Bob White", 'M',"NYC", "DevOps Engineer"),
                new Employee(5, "Meloni", 'F',"NYC", "HR")
            };
        }
    }
}
