using DependencyInjectionLifetimeScopes;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DependencyInjectionLifetimeScopesTest
{
    public class ValuesControllerTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public ValuesControllerTest(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task WhenInvokingGet_ThenReturnsSuccess()
        {
            // Get Items
            var httpResponse = await _client.GetAsync("/api/values");
            httpResponse.EnsureSuccessStatusCode();
        }
    }
}
