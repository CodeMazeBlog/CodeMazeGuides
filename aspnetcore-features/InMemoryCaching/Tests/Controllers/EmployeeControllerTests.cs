using InMemoryCacheExample.Controllers;
using InMemoryCacheExample.Models;
using InMemoryCacheExample.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class EmployeeControllerTests
    {
        [Fact]
        public void WhenEmployeesInCache_ThenReturnsSuccess()
        {
            // Arrange            
            var employees = GetEmployees();
            var repository = new Mock<IDataRepository<Employee>>();
            repository.Setup(r => r.GetAll()).Returns(employees);

            var cachedEmployees = GetCachedEmployees();
            var cache = new MemoryCache(new MemoryCacheOptions());
            cache.Set("employeeList", cachedEmployees);

            var logger = new Mock<ILogger<EmployeeController>>();
            var controller = new EmployeeController(repository.Object, cache, logger.Object);

            // Act            
            var result = controller.Get();
            var resultCount = ((result as ObjectResult)?.Value as List<Employee>)?.Count;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, resultCount);
        }
                
        [Fact]
        public void WhenEmployeesNotInCache_ThenReturnsSuccess()
        {
            // Arrange            
            var employees = GetEmployees();
            var repository = new Mock<IDataRepository<Employee>>();
            repository.Setup(r => r.GetAll()).Returns(employees);

            var cache = new MemoryCache(new MemoryCacheOptions());
            var logger = new Mock<ILogger<EmployeeController>>();
            var controller = new EmployeeController(repository.Object, cache, logger.Object);
                        
            // Act            
            var result = controller.Get();
            var resultCount = ((result as ObjectResult)?.Value as List<Employee>)?.Count;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, resultCount);
        }

        private static List<Employee> GetEmployees()
        {
            return new List<Employee>()
            {
                new Employee()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    EmployeeId = 1
                },
                new Employee()
                {
                    FirstName = "Chris",
                    LastName = "Evans",
                    EmployeeId = 2
                }
            };
        }

        private static List<Employee> GetCachedEmployees()
        {
            return new List<Employee>()
            {
                new Employee()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    EmployeeId = 1
                }
            };
        }
    }
}