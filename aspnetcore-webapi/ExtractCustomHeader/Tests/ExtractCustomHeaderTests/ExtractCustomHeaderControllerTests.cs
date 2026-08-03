using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ExtractCustomHeaderTests
{
    public class ExtractCustomHeaderControllerTests
    {
        private readonly WebApplicationFactory<Program> _factory;

        public ExtractCustomHeaderControllerTests()
        {
            _factory = new WebApplicationFactory<Program>();
        }

        [Fact]
        public async Task WhenCallingExtractFromBasicEndpoint_ThenReturnsCustomHeaderValue()
        {
            var client = _factory.CreateClient();
            client.DefaultRequestHeaders.Add("HeaderKey", "HeaderValue");

            var response = await client.GetAsync("/api/headers/from-basic");

            response.Should().Be200Ok().And.BeAs(new[] { "HeaderValue" });
        }

        [Fact]
        public async Task WhenCallingExtractFromHeaderAttributeEndpoint_ThenReturnsCustomHeaderValue()
        {
            var client = _factory.CreateClient();
            client.DefaultRequestHeaders.Add("FirstName", "NameSample");
            client.DefaultRequestHeaders.Add("LastName", "LastNameSample");

            var response = await client.GetAsync("/api/headers/from-header-attribute");

            response.Should().Be200Ok().And.BeAs(new
            {
                firstName = "NameSample",
                lastName = "LastNameSample"
            });
        }

        [Fact]
        public async Task WhenCallingExtractFromFilterEndpoint_ThenReturnsCustomHeaderValue()
        {
            var client = _factory.CreateClient();
            client.DefaultRequestHeaders.Add("FilterHeaderKey", "FilterHeaderValue");

            var response = await client.GetAsync("/api/headers/from-filter");
            var result = await response.Content.ReadAsStringAsync();

            response.Should().Be200Ok();
            result.Should().Be("FilterHeaderValue-received");
        }
    }
}