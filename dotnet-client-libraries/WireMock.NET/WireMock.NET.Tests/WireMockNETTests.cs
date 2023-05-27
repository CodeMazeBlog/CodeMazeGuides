using FluentAssertions;
using System.Net;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMockNet;

namespace WireMock.NET.Tests
{
    public class WireMockNETTests : IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly WireMockServer _mockServer;
        private readonly PlanetsService _planetService;

        public WireMockNETTests()
        {
            _mockServer = WireMockServer.Start(new Settings.WireMockServerSettings
            {
                Urls = new[] { "https://localhost:8888" }
            });

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:8888")
            };

            _planetService = new PlanetsService(_httpClient);
        }

        [Fact]
        public async Task GivenThatPlanetExists_WhenGetPlanetByIdIsInvoked_ThenOKAndValidPlanetIsReturned()
        {
            // Arrange
            var planet = new Planet(4, "Mars", 6779, 2, true);

            _mockServer
                .Given(Request.Create()
                    .WithPath("/planets/4").UsingGet())
                .RespondWith(Response.Create()
                    .WithBodyAsJson(planet)
                    .WithStatusCode(HttpStatusCode.OK));

            // Act
            var result = await _planetService.GetPlanetByIdAsync(planet.Id);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be(planet.Name);
            result.Diameter.Should().Be(planet.Diameter);
            result.NumberOfMoons.Should().Be(planet.NumberOfMoons);
            result.HasAtmosphere.Should().Be(planet.HasAtmosphere);
        }

        [Fact]
        public async Task GivenThatPlanetDoesntExists_WhenGetPlanetIsInvoked_ThenNotFoundIsReturned()
        {
            _mockServer.Given(Request.Create().WithPath("/planets/9").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(HttpStatusCode.NotFound));

            // Act
            var result = await _planetService.GetPlanetByIdAsync(9);

            // Assert
            result.Should().BeNull();
        }

        public void Dispose()
        {
            _mockServer.Stop();
            _httpClient.Dispose();
        }
    }
}