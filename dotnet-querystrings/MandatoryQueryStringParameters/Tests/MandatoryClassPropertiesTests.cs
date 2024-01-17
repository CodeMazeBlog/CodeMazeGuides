using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class MandatoryClassPropertiesTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private HttpClient _httpClient;
        private WebApplicationFactory<Program> _factory;

        public MandatoryClassPropertiesTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            var serviceUrl = "https://localhost:7259/";
            _httpClient = _factory.CreateClient();
            _httpClient.BaseAddress = new Uri(serviceUrl);
        }

        [Fact]
        public async Task GivenAllParameters_WhenCallAPI_ThenReturnCorrectly()
        {
            var json = await _httpClient.GetStringAsync("/values?id=13&number=23");
            var intArray = JArray.Parse(json).ToObject<int[]>();
            Assert.Equal(2, intArray.Length);
            Assert.Equal(13, intArray[0]);
            Assert.Equal(23, intArray[1]);
        }

        [Fact]
        public async Task GivenNoParameters_WhenCallAPI_ThenReturnErrors()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("/values");
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
