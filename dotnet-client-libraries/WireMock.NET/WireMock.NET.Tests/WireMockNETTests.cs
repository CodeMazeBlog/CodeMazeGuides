using FluentAssertions;
using System.Net;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace WireMock.NET.Tests
{
    public class WireMockNETTests :IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly WireMockServer _server;

        public WireMockNETTests()
        {
            _server = WireMockServer.Start(new Settings.WireMockServerSettings
            {
                Urls = new[] { "https://localhost:8888" }
            });

            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:8888");
        }

        [Fact]
        public async Task GivenThatPlanetExists_WhenGetPlanetIsInvoked_ThenOKAndValidPlanetIsReturned()
        {
            // Arrange
            _server.Given(Request.Create().WithPath("/planets/3").UsingGet())
                .RespondWith(Response.Create().WithBodyAsJson(new object()).WithStatusCode(HttpStatusCode.OK));

            // Act
            var response = await _httpClient.GetAsync(_httpClient.BaseAddress + "planets/3");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GivenThatPlanetDoesntExists_WhenGetPlanetIsInvoked_ThenNotFoundIsReturned()
        {
            _server.Given(Request.Create().WithPath("/planets/9").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(HttpStatusCode.NotFound));

            // Act
            var response = await _httpClient.GetAsync(_httpClient.BaseAddress + "planets/9");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        public void Dispose()
        {
            _server.Dispose();
            _httpClient.Dispose();
        }
    }
}