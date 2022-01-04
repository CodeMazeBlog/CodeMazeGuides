using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class StringListControllerV2Tests : IClassFixture<WebApplicationFactory<Program>>
    {
        private HttpClient _httpClient;
        private WebApplicationFactory<Program> _factory;

        public StringListControllerV2Tests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            var serviceUrl = "https://localhost:7114/";
            _httpClient = _factory.CreateClient();
            _httpClient.BaseAddress = new Uri(serviceUrl);
        }
        

        [Fact]
        public async Task GivenQueryString_WhenCalledV2_ThenReturnStringStartingWithS()
        {
            var json = await _httpClient.GetStringAsync("/api/StringList?api-version=2.0");
            var strings = JArray.Parse(json);
            Assert.Equal(2, strings.Count);
            Assert.StartsWith("S", (string)strings[0]);
            Assert.StartsWith("S", (string)strings[1]);
        }


        [Fact]
        public async Task GivenHeader_WhenCalledV2_ThenReturnStringStartingWithS()
        {
            _httpClient.DefaultRequestHeaders.Add("X-Version", "2.0");
            var json = await _httpClient.GetStringAsync("/api/StringList");
            var strings = JArray.Parse(json);
            Assert.Equal(2, strings.Count);
            Assert.StartsWith("S", (string)strings[0]);
            Assert.StartsWith("S", (string)strings[1]);
        }

        [Fact]
        public async Task GivenMediaType_WhenCalledV2_ThenReturnStringStartingWithS()
        {
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json; ver=2.0 ");
            var json = await _httpClient.GetStringAsync("/api/StringList");
            var strings = JArray.Parse(json);
            Assert.Equal(2, strings.Count);
            Assert.StartsWith("S", (string)strings[0]);
            Assert.StartsWith("S", (string)strings[1]);
        }
    }
}
