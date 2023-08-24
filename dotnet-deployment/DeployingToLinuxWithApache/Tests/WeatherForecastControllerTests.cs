using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests
{
    public class WeatherForecastControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public WeatherForecastControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void WhenGetWeatherForecastEndpointIsCalled_Then200StatusCodeIsReturned()
        {
            //Given
            var client = _factory.CreateClient();

            //When
            var response = await client.GetAsync("/WeatherForecast");

            // Then
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }
    }
}