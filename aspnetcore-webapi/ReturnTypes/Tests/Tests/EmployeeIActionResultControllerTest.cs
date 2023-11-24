using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class EmployeeIActionResultControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public EmployeeIActionResultControllerTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task WhenGettingEmployeeById_ThenReturnSuccess()
        {
            // arrange
            var client = _factory.CreateClient();

            // act
            var response = await client.GetAsync("api/employeeiactionresult/1");

            //assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task WhenEmployeeNotFound_ThenReturnNotFound()
        {
            // arrange
            var client = _factory.CreateClient();

            // act
            var response = await client.GetAsync("api/employeeiactionresult/1001");

            //assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
