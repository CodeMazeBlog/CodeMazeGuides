using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests
{
    public class NetVersionTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        public NetVersionTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public void WhenCheckingNetVersion_ThenShouldNotBeNull()
        {
            var netVersion = System.Environment.Version;

            Assert.NotNull(netVersion);
        }

        [Fact]
        public async void WhenGetIndexPageIsCalled_Then200StatusCodeIsReturned()
        {
            //Given
            var client = _factory.CreateClient();

            //When
            var response = await client.GetAsync("/index");

            // Then
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }
    }
}