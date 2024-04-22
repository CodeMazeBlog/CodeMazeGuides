using EasyCaching;
using EasyCaching.API;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Json;

namespace Tests
{
    public class EasyCachingTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public EasyCachingTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;   
        }

        [Fact]
        public async Task GivenAnEndpoint_WhenUsingCaching_ThenResponseTimeIsShorter()
        {
            // Arrange
            var client = _factory.CreateClient();

            //Act
            var sw1 = Stopwatch.StartNew();
            var response1 = await client.GetAsync("api/ValuesWithTwoProviders");
            sw1.Stop();
            var jsonResponse1 = await response1.Content.ReadFromJsonAsync<ApiResponse>();
            var duration1 = jsonResponse1!.Duration;

            var sw2 = Stopwatch.StartNew();
            var response2 = await client.GetAsync("api/ValuesWithTwoProviders");
            sw2.Stop();
            var jsonResponse2 = await response2.Content.ReadFromJsonAsync<ApiResponse>();
            var duration2 = jsonResponse2!.Duration;

            //Assert
            Assert.Equal(HttpStatusCode.OK, jsonResponse1.StatusCode);
            Assert.Equal(HttpStatusCode.OK, jsonResponse2.StatusCode);
            Assert.NotEqual(sw1.ElapsedMilliseconds, sw2.ElapsedMilliseconds);
            Assert.True(sw1.ElapsedMilliseconds > sw2.ElapsedMilliseconds);
            Assert.True(duration1 > duration2);
        }
    }
}