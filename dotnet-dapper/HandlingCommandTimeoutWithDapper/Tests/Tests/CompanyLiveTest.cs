using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using HandlingCommandTimeoutWithDapper.Model;
using System.Net.Http.Json;

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
        public async Task WhenGetCompanyWithTimeoutInConnectionString_ThenReturnRequestFulfilled()
        {
            // Arrange
            const string ExistingCompanyId = "67FBAC34-1EE1-4697-B916-1748861DD275";
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync($"/company/{ExistingCompanyId}");
            var company = await response.Content.ReadFromJsonAsync<Company>();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(new Guid(ExistingCompanyId), company.Id);
        }

        [Fact]
        public async Task WhenGetCompaniesWithTimeoutInQueryMultiple_ThenReturnsRequestFulfilled()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/company/timeoutInQueryMultiple");
            var companies = await response.Content.ReadFromJsonAsync<IEnumerable<Company>>();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEmpty(companies);
        }
    }
}