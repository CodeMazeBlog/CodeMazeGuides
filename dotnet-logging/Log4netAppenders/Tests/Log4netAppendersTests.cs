using log4net.Config;

namespace Tests
{
    public class Log4netAppendersTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public Log4netAppendersTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenLog4NetConfigured_WhenLogTestIsInvoked_ThenAllEventsAreLogged()
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
