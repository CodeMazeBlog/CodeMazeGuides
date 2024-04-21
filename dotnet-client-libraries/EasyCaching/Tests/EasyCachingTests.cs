using EasyCaching.API;
using EasyCaching.Controllers;
using EasyCaching.Core;
using System.Diagnostics;
using System.Net.Http.Json;

namespace Tests
{
    public class EasyCachingTests
    {
        private readonly HttpClient _httpClient;

        public EasyCachingTests()
        {
            _httpClient = new()
            {
                BaseAddress = new Uri("https://localhost:7145/api/ValuesWithTwoProviders")
            };   
        }

        [Fact]
        public async Task GivenAnEndpoint_WhenUsingCaching_ThenResponseTimeIsShorter()
        {
            //Start debugging Unit Test
            //While on the first line of your test code or before calling your local web api project
            //Right click on your web api project and Debug > Start without debugging

            //Arrange & Act
            var sw1 = Stopwatch.StartNew();
            var response1 = await _httpClient.GetAsync("");
            sw1.Stop();
            var jsonResponse1 = await response1.Content.ReadFromJsonAsync<ApiResponse>();
            var duration1 = jsonResponse1!.Duration;

            var sw2 = Stopwatch.StartNew();
            var response2 = await _httpClient.GetAsync("");
            sw2.Stop();
            var jsonResponse2 = await response2.Content.ReadFromJsonAsync<ApiResponse>();
            var duration2 = jsonResponse2!.Duration;

            //Assert
            Assert.NotEqual(sw1.ElapsedMilliseconds, sw2.ElapsedMilliseconds);
            Assert.True(sw1.ElapsedMilliseconds > 3000);
            Assert.True(sw1.ElapsedMilliseconds > sw2.ElapsedMilliseconds);
            Assert.True(duration1 > 3000);
            Assert.True(duration1 > duration2);
        }
    }
}