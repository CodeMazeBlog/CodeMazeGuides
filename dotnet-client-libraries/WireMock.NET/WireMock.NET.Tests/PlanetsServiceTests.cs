using FluentAssertions;
using System.Net;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMock.Settings;
using WireMockNet;

namespace WireMock.NET.Tests
{
    public class PlanetsServiceTests : IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly WireMockServer _mockServer;
        private readonly PlanetsService _planetService;

        public PlanetsServiceTests()
        {
            _mockServer = WireMockServer.Start(new WireMockServerSettings
            {
                StartAdminInterface = true
            });

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(_mockServer.Urls[0])
            };

            _planetService = new PlanetsService(_httpClient);
        }

        [Fact]
        public async Task GivenThatPlanetExists_WhenGetPlanetByIdIsInvoked_ThenValidPlanetIsReturned()
        {
            // Arrange
            var planet = new Planet(4, "Mars", 6779, 2, true);

            _mockServer
                .Given(
                    Request.Create()
                        .UsingGet()
                        .WithPath("/planets/4"))
                .RespondWith(
                    Response.Create()
                        .WithStatusCode(HttpStatusCode.OK)
                        .WithBodyAsJson(planet));

            // Act
            var result = await _planetService.GetPlanetByIdAsync(planet.Id);

            // Assert
            result.Should().NotBeNull();
            result.Should().Be(planet);
        }

        [Fact]
        public async Task GivenThatPlanetDoesntExists_WhenGetPlanetIsInvoked_ThenNullIsReturned()
        {
            // Arrange
            _mockServer
                .Given(
                    Request.Create()
                        .UsingGet()
                        .WithPath("/planets/9"))
                .RespondWith(
                    Response.Create()
                        .WithStatusCode(HttpStatusCode.NotFound));

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