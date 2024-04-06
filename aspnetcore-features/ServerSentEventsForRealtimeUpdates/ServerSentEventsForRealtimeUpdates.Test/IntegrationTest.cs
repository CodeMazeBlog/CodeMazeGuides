
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using ServerSentEventsForRealtimeUpdates.MVC.Models.Flight;

namespace ServerSentEventsForRealtimeUpdates.Test;

public class IntegrationTest(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    [Theory]
    [InlineData("/test")]
    public async Task WhenCallingSseEndpointTest_ShouldReturnFlight(string url)
    {
        // Arrange
        var source = new CancellationTokenSource();
        var token = source.Token;
       
        // Act
        var response = await GetResponse(url, token);
        var flight = JsonSerializer.Deserialize<Flight>(GetData(response));
        
        // Assert
        Assert.NotNull(flight);
        
        var flightType = flight.GetType();
        Assert.Equal(typeof(Flight), flightType);
    }
    
    [Theory]
    [InlineData("/sse")]
    public async Task WhenCallingSseEndpointAndCancellingTask_ShouldThrowException(string url)
    {
        // Arrange
        var source = new CancellationTokenSource();
        var token = source.Token;

        // Act
        var responseTask = GetResponse(url, token);
        var cancelTask = CancellationTask(token, source);

        // Assert
        await Assert.ThrowsAsync<TaskCanceledException>(
            () => Task.WhenAll(responseTask, cancelTask));
    }

    private async Task<string> GetResponse(string url, CancellationToken token)
    {
        var client = factory.CreateClient();
        return await client.GetStringAsync(url, token);
    }

    private async Task CancellationTask(CancellationToken token, CancellationTokenSource source)
    {
        await Task.Delay(TimeSpan.FromSeconds(4), token);
        await source.CancelAsync();
    }

    private static string GetData(string data)
    {
        var start = data.IndexOf('{');
        var end = data.LastIndexOf('}');

        return data.Substring(start, end - start + 1);
    }
}