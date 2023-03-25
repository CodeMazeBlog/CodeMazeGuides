using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace Tests
{
    public class CompanyLiveTest
    {
        private readonly WebApplicationFactory<Program> _factory;

        public CompanyLiveTest()
        {
            _factory = new WebApplicationFactory<Program>();
        }

        [Fact]
        public async Task WhenGetCompaniesWithTimeoutInConnectionString_ThenReturnsGatewayTimeout()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/company/timeoutInConnectionString");

            // Assert
            Assert.Equal(HttpStatusCode.GatewayTimeout, response.StatusCode);
        }

        [Fact]
        public async Task WhenGetCompaniesWithTimeoutInQueryMultiple_ThenReturnsGatewayTimeout()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/company/timeoutInQueryMultiple");

            // Assert
            Assert.Equal(HttpStatusCode.GatewayTimeout, response.StatusCode);
        }

        [Fact]
        public async Task WhenGetCompaniesWithTimeoutInQuery_ThenReturnsGatewayTimeout()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/company/timeoutInQuery");

            // Assert
            Assert.Equal(HttpStatusCode.GatewayTimeout, response.StatusCode);
        }

        [Fact]
        public async Task WhenGetCompanies_ThenReturnsListCompanies()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/company/timeoutCorrect");

            //// Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}