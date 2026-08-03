using EasyCaching.API;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Json;

namespace Tests
{
    public class EasyCachingTests(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
    {
        [Fact]
        public async Task GivenAnEndpoint_WhenUsingCaching_ThenResponseTimeIsShorter()
        {
            // Arrange
            var client = factory.CreateClient();

            //Act
            var stopwatchFirstCall = Stopwatch.StartNew();
            var response1 = await client.GetAsync("api/ValuesWithTwoProviders");
            stopwatchFirstCall.Stop();
            var jsonResponse1 = await response1.Content.ReadFromJsonAsync<ApiResponse>();
            var duration1 = jsonResponse1!.Duration;

            var stopwatchSecondCall = Stopwatch.StartNew();
            var response2 = await client.GetAsync("api/ValuesWithTwoProviders");
            stopwatchSecondCall.Stop();
            var jsonResponse2 = await response2.Content.ReadFromJsonAsync<ApiResponse>();
            var duration2 = jsonResponse2!.Duration;

            //Assert
            Assert.Equal(HttpStatusCode.OK, jsonResponse1.StatusCode);
            Assert.Equal(HttpStatusCode.OK, jsonResponse2.StatusCode);
            Assert.NotEqual(stopwatchFirstCall.ElapsedMilliseconds, stopwatchSecondCall.ElapsedMilliseconds);
            Assert.True(stopwatchFirstCall.ElapsedMilliseconds > stopwatchSecondCall.ElapsedMilliseconds);
            Assert.True(duration1 > duration2);
        }
    }
}