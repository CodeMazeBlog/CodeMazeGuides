using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class StringListControllerV1Tests : IClassFixture<WebApplicationFactory<Program>>
    {
        private HttpClient _httpClient;
        private WebApplicationFactory<Program> _factory;

        public StringListControllerV1Tests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            var catalogServiceUrl = "https://localhost:7114/";
            _httpClient = _factory.CreateClient();
            _httpClient.BaseAddress = new Uri(catalogServiceUrl);
        }

        [Fact]
        public async Task GivenDefaultCall_WhenNoVersion_ThenReturnStringStartingWithB()
        {
            var json = await _httpClient.GetStringAsync("/api/StringList");
            var strings = JArray.Parse(json);
            Assert.Equal(2, strings.Count);
            Assert.StartsWith("B", (string)strings[0]);
            Assert.StartsWith("B", (string)strings[1]);
        }
    }
}