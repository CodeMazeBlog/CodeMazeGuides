using Microsoft.AspNetCore.Mvc.Testing;
using OptionalParameterinWebApi;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    // These tests observe the difference the article turns on: "?" makes a segment
    // skippable and leaves the route value unset, while "=1" is a route default the
    // router substitutes before the action runs.
    public class RouteTemplateControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;

        public RouteTemplateControllerTest(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task Optional_WhenSegmentOmitted_LeavesRouteValueUnsetAndUsesMethodDefault()
        {
            var response = await _httpClient.GetAsync("/api/RouteTemplate/Optional");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("id=1;routeValueSet=False", await response.Content.ReadAsStringAsync());
        }

        // The article's central claim. The method default is not a requirement: omit it
        // and the URL still matches, the parameter just binds to 0 with no error.
        [Fact]
        public async Task OptionalWithNoMethodDefault_WhenSegmentOmitted_BindsZero()
        {
            var response = await _httpClient.GetAsync("/api/RouteTemplate/OptionalNoDefault");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("id=0;routeValueSet=False", await response.Content.ReadAsStringAsync());
        }

        [Fact]
        public async Task Default_WhenSegmentOmitted_RouterSuppliesTheRouteValue()
        {
            var response = await _httpClient.GetAsync("/api/RouteTemplate/Default");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("id=1;routeValueSet=True", await response.Content.ReadAsStringAsync());
        }

        // "{id=1}" and an explicit "/1" arrive identically as far as the action's
        // parameters and route values are concerned.
        [Fact]
        public async Task Default_WithSegmentSupplied_IsIndistinguishableFromTheOmittedCase()
        {
            var omitted = await _httpClient.GetStringAsync("/api/RouteTemplate/Default");
            var supplied = await _httpClient.GetStringAsync("/api/RouteTemplate/Default/1");

            Assert.Equal(omitted, supplied);
        }

        [Theory]
        [InlineData("/api/RouteTemplate/ConstrainedOptional", "id=1;routeValueSet=False")]
        [InlineData("/api/RouteTemplate/ConstrainedOptional/9", "id=9;routeValueSet=True")]
        public async Task ConstrainedOptional_MatchesWithAndWithoutTheSegment(string url, string expected)
        {
            var response = await _httpClient.GetAsync(url);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(expected, await response.Content.ReadAsStringAsync());
        }

        // A constraint and a route default combine in one segment, constraint first.
        [Theory]
        [InlineData("/api/RouteTemplate/ConstrainedDefault", "id=1;routeValueSet=True")]
        [InlineData("/api/RouteTemplate/ConstrainedDefault/9", "id=9;routeValueSet=True")]
        public async Task ConstrainedDefault_SuppliesTheRouteValueAndStillAcceptsOne(string url, string expected)
        {
            var response = await _httpClient.GetAsync(url);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(expected, await response.Content.ReadAsStringAsync());
        }

        // A constraint matches, it does not validate: a URL that fails one never reaches
        // the action, so the caller sees 404 rather than 400.
        [Theory]
        [InlineData("/api/RouteTemplate/ConstrainedOptional/boots")]
        [InlineData("/api/RouteTemplate/ConstrainedDefault/boots")]
        public async Task NonIntegerSegment_Returns404(string url)
        {
            var response = await _httpClient.GetAsync(url);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
