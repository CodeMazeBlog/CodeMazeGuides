using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ExtractCustomHeaderTests
{
    public class ExtractCustomHeaderFromMiddlewareControllerTests
    {
        private readonly WebApplicationFactory<Program> _factory;

        public ExtractCustomHeaderFromMiddlewareControllerTests()
        {
            _factory = new WebApplicationFactory<Program>();
        }

        [Fact]
        public async Task WhenCallingExtractFromHeaderMiddlewareEndpoint_ThenReturnsCustomHeaderValue()
        {
            var client = _factory.CreateClient();
            client.DefaultRequestHeaders.Add("MiddlewareHeaderKey", "MiddlewareHeaderValue");

            var response = await client.GetAsync("/api2/headers/from-middleware");
            var result = await response.Content.ReadAsStringAsync();

            response.Should().Be200Ok();
            result.Should().Be("MiddlewareHeaderValue-received");
        }
    }
}
