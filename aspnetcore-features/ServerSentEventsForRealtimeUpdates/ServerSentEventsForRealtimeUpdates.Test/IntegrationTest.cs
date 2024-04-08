using Microsoft.AspNetCore.Mvc.Testing;


namespace ServerSentEventsForRealtimeUpdates.Test;

public class IntegrationTest(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    [Theory]
    [InlineData("/sse")]
    public async Task WhenCallingSseEndpoint_ShouldHaveTheNumberZeroOnResult(string url)
    {
        // Arrange
        var source = new CancellationTokenSource();
        var token = source.Token;
       
        // Act
        var response = await GetResponse(url, token);
        
        // Assert
        Assert.NotNull(response);
        Assert.Contains("0", response);
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
}