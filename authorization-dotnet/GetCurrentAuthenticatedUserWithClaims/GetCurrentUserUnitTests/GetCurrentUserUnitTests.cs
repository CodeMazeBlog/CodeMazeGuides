using GetCurrentAuthenticatedUserWithClaims.Controllers;
using GetCurrentAuthenticatedUserWithClaims.Models;
using GetCurrentUserWithClaims.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Text.Json;

namespace GetCurrentUserUnitTests
{
    public class GetCurrentUserUnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task WhenGetAllEmployeesIsCalled_ThenAListOfEmployeesIsReturned()
        {
            var user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "john@doe.com",
                FirstName = "John",
                LastName = "Doe"
            };

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim("firstname", user.FirstName),
                new Claim("lastname", user.LastName)
            };
            var identity = new ClaimsIdentity(claims, "Test");
            var claimsPrincipal = new ClaimsPrincipal(identity);
            
            var mockHttpContext = new Mock<HttpContext>();
            mockHttpContext.Setup(x => x.User).Returns(claimsPrincipal);

            var httpContextAccessor = new Mock<IHttpContextAccessor>();
            httpContextAccessor.Setup(x => x.HttpContext).Returns(mockHttpContext.Object);

            var logger = new Mock<ILogger<HomeController>>();
            var service = new Mock<IEmployeeService>();
            var employeeList = new List<Employee>()
            {
                new Employee()
                {
                    Id = Guid.NewGuid(),
                    Name = "Jane Doe",
                    Age = 30,
                    Position = "Sales"
                }
            };
            service.Setup(m => m.GetAllEmployees()).Returns(Task.FromResult(employeeList));

            var controller = new HomeController(logger.Object, service.Object, httpContextAccessor.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = claimsPrincipal }
            };

            var result = await controller.Employees() as ViewResult;

            var resultJson = JsonSerializer.Serialize(result?.Model);
            var initialJson = JsonSerializer.Serialize(employeeList);
            Assert.AreEqual(resultJson, initialJson);
        }
    }
}