using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace Test
{
    public class EmployeeControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public EmployeeControllerTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task WhenGettingEmployeeById_ThenReturnSuccess()
        {
            // arrange
            var client = _factory.CreateClient();

            // act
            var response = await client.GetAsync("api/employee/1");

            //assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task WhenEmployeeNotFound_ThenReturnNotFound()
        {
            // arrange
            var client = _factory.CreateClient();

            // act
            var response = await client.GetAsync("api/employee/1001");

            //assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task WhenInvalidEmployeeId_ThenReturnBadRequest()
        {
            // arrange
            var client = _factory.CreateClient();

            // act
            var response = await client.GetAsync("api/employee/0");

            //assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

    }
}