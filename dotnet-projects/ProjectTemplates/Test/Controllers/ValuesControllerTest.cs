using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace codemazeapi.Controllers
{
    public class ValuesControllerTest : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ValuesControllerTest(CustomWebApplicationFactory<Program> factory)
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
