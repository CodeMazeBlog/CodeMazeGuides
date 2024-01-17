using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class MandatoryParameterTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private HttpClient _httpClient;
        private WebApplicationFactory<Program> _factory;

        public MandatoryParameterTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            var serviceUrl = "https://localhost:7259/";
            _httpClient = _factory.CreateClient();
            _httpClient.BaseAddress = new Uri(serviceUrl);
        }

        [Fact]
        public async Task GivenMandatoryParameters_WhenCallAPI_ThenReturnCorrectly()
        {
            var json = await _httpClient.GetStringAsync("/withparams?number=12&id=4");
            var intArray = JArray.Parse(json).ToObject<int[]>();
            Assert.Equal(3, intArray.Length);
            Assert.Equal(4, intArray[0]);
            Assert.Equal(12, intArray[1]);
        }
        [Fact]
        public async Task GivenNoBindRequiredParameters_WhenCallAPI_ThenReturnErrors()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("/withparams?number=12");
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task GivenNoRequiredParameters_WhenCallAPI_ThenReturnErrors()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("/withparams?Id=4");
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
