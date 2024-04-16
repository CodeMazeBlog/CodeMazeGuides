using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using ServerSentEventsForRealtimeUpdates.Server;

namespace ServerSentEventsForRealtimeUpdates.Test;

public class IntegrationTest() 
{
    [Theory]
    [InlineData("/sse")]
    public async Task WhenCallingSseEndpoint_ThenReturnSuccess(string url)
    {
        // Arrange
        var source = new CancellationTokenSource();
        var token = source.Token;
       
        // Act
        var response = await GetResponse(url, token);
        
        // Assert
        Assert.True(response.IsSuccessStatusCode);
    }
    
    [Theory]
    [InlineData("/sse")]
    public async Task WhenCallingSseEndpointAndCancellingTask_ThenThrowException(string url)
    {
        // Arrange
        var source = new CancellationTokenSource();
        var token = source.Token;

        // Act
        var responseTask = GetResponse(url, token);
        var cancelTask = CancelResponse(source);

        // Assert
        await Assert.ThrowsAsync<TaskCanceledException>(
            () => Task.WhenAll(responseTask, cancelTask));
    }

    private async Task<HttpResponseMessage> GetResponse(string url, CancellationToken token)
    {
        await using var factory = new MockWebApplicationFactory(services =>
        {
            services.Replace(ServiceDescriptor.Scoped(_ =>
            {
                var serviceMock = new Mock<ICounterService>();
                
                serviceMock
                    .Setup(e => e.StartValue)
                    .Returns(1);
                
                serviceMock
                    .Setup(e => e.CountdownDelay(It.Is<CancellationToken>(c => c == token)))
                    .Returns(Task.CompletedTask);
                
                return serviceMock.Object;
            }));
        });
        
        var client = factory.CreateClient();
        
        return await client.GetAsync(url, token);
    }

    private async Task CancelResponse(CancellationTokenSource source)
    {
        await source.CancelAsync();
    }
}