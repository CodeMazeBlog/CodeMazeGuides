using Microsoft.AspNetCore.Mvc.Testing;
using OptionalParameterinWebApi;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    public class WeatherForecastControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;

        public WeatherForecastControllerTest(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }

        // This is the article's headline snippet: "GetById/{id?}" with a method default
        // of 1. Omitting the segment still matches the route, and the method default is
        // what decides the result.
        [Fact]
        public async Task GetById_WhenIdOmitted_ReturnsForecastOne()
        {
            var response = await _httpClient.GetAsync("/api/WeatherForecast/GetById");
            var forecast = await response.Content.ReadFromJsonAsync<WeatherForecast>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(forecast);
            Assert.Equal(1, forecast.Id);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        public async Task GetById_WithId_ReturnsMatchingForecast(int id)
        {
            var forecast = await _httpClient.GetFromJsonAsync<WeatherForecast>($"/api/WeatherForecast/GetById/{id}");

            Assert.NotNull(forecast);
            Assert.Equal(id, forecast.Id);
        }
    }
}
