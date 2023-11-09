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
        public async Task WhenGettingLogTest_ThenReturnSuccess()
        {
            // arrange
            var client = _factory.CreateClient();

            // act
            var response = await client.GetAsync("api/logtest");

            //assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
