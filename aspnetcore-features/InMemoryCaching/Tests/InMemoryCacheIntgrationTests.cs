using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class InMemoryCacheIntgrationTests
    {
        private readonly WebApplicationFactory<Program> _factory;

        public InMemoryCacheIntgrationTests()
        {
            _factory = new WebApplicationFactory<Program>();
        }

        [Fact]
        public async Task Get_Employees_ReturnsSuccess()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/employee");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}