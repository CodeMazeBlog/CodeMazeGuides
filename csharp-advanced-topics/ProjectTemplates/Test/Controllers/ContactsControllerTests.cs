using codemazeapi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.Controllers
{
    public class ContactsControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ContactsControllerTests(CustomWebApplicationFactory<Program> factory)
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
