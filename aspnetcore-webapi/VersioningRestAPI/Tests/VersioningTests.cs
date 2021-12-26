using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class VersioningTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private HttpClient _httpClient;
        private WebApplicationFactory<Program> _factory;

        public VersioningTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            var catalogServiceUrl = "https://localhost:7114/";
            _httpClient = _factory.CreateClient();
            _httpClient.BaseAddress = new Uri(catalogServiceUrl);
        }

        [Fact]
        public async Task GivenDefaultCall_WhenCalledV1_ThenReturnStringStartingWithB()
        {
            var json = await _httpClient.GetStringAsync("/api/StringList");
            var strings = JArray.Parse(json);
            Assert.Equal(2, strings.Count);
            Assert.StartsWith("B", (string)strings[0]);
            Assert.StartsWith("B", (string)strings[1]);
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

        [Fact]
        public async Task GivenURLChange_WhenCalledV3_ThenReturnStringStartingWithC()
        {
            var json = await _httpClient.GetStringAsync("/api/v3/StringList");
            var strings = JArray.Parse(json);
            Assert.Equal(2, strings.Count);
            Assert.StartsWith("C", (string)strings[0]);
            Assert.StartsWith("C", (string)strings[1]);
        }
    }
}