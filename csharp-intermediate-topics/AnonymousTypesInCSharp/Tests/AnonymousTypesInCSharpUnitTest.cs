using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class AnonymousTypesInCSharpUnitTest
    {
        [TestMethod]
        public void GivenAnonymousType_WhenWritingProperties_ThenReturnPropertyValues()
        {
            var employee = new
            {
                Id = 001,
                FirstName = "John",
                LastName = "Doe",                
                Department = "Marketing",
                FullTime = false,
                HourlyPay = 35.75
            };

            Assert.AreEqual("John Doe", $"{employee.FirstName} {employee.LastName}");
        }

        [TestMethod]
        public void GivenNestedAnonymousType_WhenWritingProperties_ThenReturnPropertyValues()
        {
            var employeeWithOfficeAddress = new
            {
                Id = 0002,
                FirstName = "Jane",
                LastName = "Doe",
                Department = "Accounting",
                OfficeAddress = new
                {
                    Street = "123 Green St.",
                    City = "Atlanta",
                    State = "Georgia",
                    Country = "USA"
                }
            };

            Assert.AreEqual("Jane Doe Atlanta", $"{employeeWithOfficeAddress.FirstName} {employeeWithOfficeAddress.LastName} {employeeWithOfficeAddress.OfficeAddress.City}");
        }

        [TestMethod]
        public void GivenArrayAnonymousType_WhenWritingProperties_ThenReturnPropertyValues()
        {
            var arrEmployees = new[]
            {
                new { Id = 001, FirstName = "John", LastName = "Doe", Department = "Marketing" },
                new { Id = 002, FirstName = "Jane", LastName = "Doe", Department = "Accounting" },
                new { Id = 003, FirstName = "Bob", LastName = "Smith", Department = "Human Resources" }
            };

            Assert.AreEqual("Bob Smith", $"{arrEmployees[2].FirstName} {arrEmployees[2].LastName}");
        }

        [TestMethod]
        public void GivenDynamicType_WhenWritingProperties_ThenReturnPropertyValues()
        {
            dynamic dynamicEmployee = new
            {
                Id = 001,
                FirstName = "John",
                LastName = "Doe"
            };

            Assert.AreEqual("John Doe", $"{dynamicEmployee.FirstName} {dynamicEmployee.LastName}");
        }

        [TestMethod]
        public void GivenLinqQueryResult_WhenWritingProperties_ThenReturnPropertyValues()
        {
            var result = "";

            List<Employee> EmployeeList = new List<Employee>()
            {
                new Employee() { Id = 001, FirstName = "John", LastName = "Doe", Department = "Marketing" },
                new Employee() { Id = 002, FirstName = "Jane", LastName = "Doe", Department = "Accounting" },
                new Employee() { Id = 003, FirstName = "Bob", LastName = "Smith", Department = "Human Resources" }
            };

            var employeesFromList = from emp in EmployeeList
                                    select new { Id = emp.Id, Name = $"{emp.FirstName} {emp.LastName}" };

            foreach (var emp in employeesFromList)
            {
                if (emp.Name == "Bob Smith")
                {
                    result = emp.Name;
                }
            }

            Assert.AreEqual("Bob Smith", result);
        }

        public class Employee
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Department { get; set; }
        }
    }
}