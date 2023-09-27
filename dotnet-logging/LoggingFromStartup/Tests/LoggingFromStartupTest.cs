namespace Tests
{
    public class LoggingFromStartupTest : IClassFixture<WebApplicationFactory<LoggingFromStartup.Program>>
    {

        private readonly WebApplicationFactory<LoggingFromStartup.Program> _factory;

        public LoggingFromStartupTest(WebApplicationFactory<LoggingFromStartup.Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task WhenGettingWeatherForecast_ThenReturnSuccess()
        {
            // arrange
            var client = _factory.CreateClient();

            // act
            var response = await client.GetAsync("WeatherForecast");

            //assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}