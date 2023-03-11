using System.Net;
using AddEndpointsApiExplorerMethod.Controllers;
using AddEndpointsApiExplorerMethod;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests
{
    public class AddEndpointsApiExplorerUnitTest
    {
        private HttpClient _client;
        private WebApplicationFactory<Program> _application;

        public AddEndpointsApiExplorerUnitTest()
        {
            _application = new WebApplicationFactory<Program>();
            _client = _application.CreateClient();
        }

        [Fact]
        public async Task WhenMinimalApiEndpointIsCalled_ThenReturnResponse()
        {
            var httpResponseMessage = await _client.GetAsync("");
            var response = await httpResponseMessage.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, httpResponseMessage.StatusCode);
            Assert.Equal("A test endpoint", response);
        }


        [Fact]
        public async Task WhenWeatherForecastEndpointIsCalled_ThenReturnWeatherForcastData ()
        {
            WeatherForecastController controller = new WeatherForecastController();

            // Act
            var result = controller.Get();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(5, result.ToList().Count);
        }
    }
}