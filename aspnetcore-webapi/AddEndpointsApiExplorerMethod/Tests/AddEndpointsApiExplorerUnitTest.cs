using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests
{
    public class AddEndpointsApiExplorerUnitTest
    {
        private HttpClient _client;
        private WebApplicationFactory<Program> _application;

        public AddEndpointsApiExplorerUnitTest()
        {
            _application = new WebApplicationFactory<Program>();
            _client = _application.CreateClient();
        }

        [Fact]
        public async Task WhenCarModelsEndpointIsCalled_ThenReturnArrayOfStrings()
        {
            var httpResponseMessage = await _client.GetAsync("/car-models");
            var response = await httpResponseMessage.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, httpResponseMessage.StatusCode);
            Assert.Equal("[\"Chevrolet\",\"Tesla\",\"Nissan\"]", response);
        }
    }
}