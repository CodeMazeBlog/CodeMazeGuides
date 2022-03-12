using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using OptionalParametersInASP.NETCoreWebAPIRouting;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    public class WeatherForecastControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private HttpClient _httpClient;
        private readonly WebApplicationFactory<Program> _factory;

        public WeatherForecastControllerTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _httpClient = _factory.CreateClient();
        }

        [Fact]
        public async Task Get_WhenExecuted_ReturnsListOfWeatherForecasts()
        {
            var response = await _httpClient.GetAsync("api/WeatherForecast");
            var content = await response.Content.ReadAsStringAsync();
            var forecasts = JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(content);

            Assert.IsAssignableFrom<IEnumerable<WeatherForecast>>(forecasts);
        }

        [Fact]
        public async Task GetById_WithoutOptionalParameter_ReturnsFirstWeatherForecast()
        {
            var response = await _httpClient.GetAsync($"/api/WeatherForecast/GetById");
            var allForecastResponse = await _httpClient.GetAsync("api/WeatherForecast");

            var allForecastContent = await allForecastResponse.Content.ReadAsStringAsync();
            var content = await response.Content.ReadAsStringAsync();

            var forecasts = JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(allForecastContent).ToList();
            var forecast = JsonConvert.DeserializeObject<WeatherForecast>(content);

            var correspondingForecast = forecasts.FirstOrDefault();

            Assert.Equal(correspondingForecast?.Summary, forecast.Summary);
            Assert.IsType<WeatherForecast>(forecast);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(3)]
        public async Task GetById_WithInt_ReturnsweatherForecast(int id)
        {
            var allweatherForecastsResponse = await _httpClient.GetAsync("api/weatherForecast");
            var response = await _httpClient.GetAsync($"/api/weatherForecast/GetById/{id}");

            var allweatherForecastsContent = await allweatherForecastsResponse.Content.ReadAsStringAsync();
            var content = await response.Content.ReadAsStringAsync();

            var weatherForecasts = JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(allweatherForecastsContent).ToList();
            var weatherForecast = JsonConvert.DeserializeObject<WeatherForecast>(content);

            var correspondingweatherForecast = weatherForecasts.FirstOrDefault(x => x.Id == id);

            Assert.IsType<WeatherForecast>(weatherForecast);
            Assert.Equal(correspondingweatherForecast?.Summary, weatherForecast.Summary);
        }
    }
}
