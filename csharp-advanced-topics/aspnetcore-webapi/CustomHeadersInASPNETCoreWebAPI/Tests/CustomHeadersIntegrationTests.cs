using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{    
    public class CustomHeadersIntegrationTests
    {
        private readonly WebApplicationFactory<Program> _factory;

        public CustomHeadersIntegrationTests()
        {
            _factory = new WebApplicationFactory<Program>();
        }

        [Fact]
        public async Task Get_IndividualEndpoint_ReturnsCustomHeader()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/custom-headers/individual");

            var headers = response.Headers;
            var headerValues = headers.GetValues("x-my-custom-header");

            // Assert
            Assert.True(headers.Contains("x-my-custom-header"));
            Assert.Contains("individual response", headerValues);
        }

        [Fact]
        public async Task Get_AttributeEndpoint_ReturnsCustomHeader()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/custom-headers/attribute");

            var headers = response.Headers;
            var headerValues = headers.GetValues("x-my-custom-header");

            // Assert
            Assert.True(headers.Contains("x-my-custom-header"));
            Assert.Contains("attribute response", headerValues);
        }


        [Fact]
        public async Task Get_MiddlewareEndpoint_ReturnsCustomHeader()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/custom-headers/middleware");

            var headers = response.Headers;
            var headerValues = headers.GetValues("x-my-custom-header");

            // Assert
            Assert.True(headers.Contains("x-my-custom-header"));
            Assert.Contains("middleware response", headerValues);
        }
    }
}