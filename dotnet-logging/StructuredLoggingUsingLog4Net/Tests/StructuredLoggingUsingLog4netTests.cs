using log4net.Config;

namespace Tests
{
    public class StructuredLoggingUsingLog4netTests : IClassFixture<WebApplicationFactory<Program>>
    {

        private readonly WebApplicationFactory<Program> _factory;

        public StructuredLoggingUsingLog4netTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task WhenInvokingLogTest_ThenReturnSuccess()
        {
            // arrange
            var client = _factory.CreateClient();

            // act
            var response = await client.GetAsync("api/logtest");

            //assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task WhenInvokingLogTest_ThenLogAllEvents()
        {
            // arrange
            var client = _factory.CreateClient();

            var appender = new log4net.Appender.MemoryAppender();
            BasicConfigurator.Configure(appender);

            // act
            var response = await client.GetAsync("api/logtest");

            //assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var logEntries = appender.GetEvents();
            Assert.Equal(4, logEntries.Length);
        }
    }
}
