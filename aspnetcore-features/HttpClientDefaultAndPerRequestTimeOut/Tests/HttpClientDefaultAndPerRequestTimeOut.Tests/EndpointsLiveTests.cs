namespace HttpClientDefaultAndPerRequestTimeOut.Tests;

using Microsoft.AspNetCore.Mvc.Testing;

public class EndpointsLiveTests
{
    private readonly WebApplicationFactory<Program> _factory = new();

    [Fact]
    public async Task WhenGlobalTimeOutPassed_ThenReturnMessageWithCancellationDetails()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act      
        var responseMessage = await client.GetStringAsync("/api/test-global-timeout");

        // Assert
        Assert.Equal("TaskCanceledException: HttpClient global timeout passed", responseMessage);
    }

    [Fact]
    public async Task WhenClientRequestIsCancelled_ThenTaskCanceledExceptionIsThrown()
    {
        // Arrange
        var client = _factory.CreateClient();
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(2));

        // Act
        // Assert
        await Assert.ThrowsAsync<TaskCanceledException>(() => client.GetAsync("/api/test-per-request-timeout", cts.Token));
    }

    [Fact]
    public async Task GivenCustomTokenIsCombinedWithGlobalAndRequestToken_WhenTheCustomTokenHasSmallestDuration_ThenItShouldBeTheOneCancellingTheRequest()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act       
        var responseMessage = await client.GetStringAsync("/api/test-combined-timeout");

        // Assert
        Assert.Equal("TaskCanceledException: Specific token canceled", responseMessage);
    }

    [Fact]
    public async Task GivenCustomTokenIsCombinedWithGlobalAndRequestToken_WhenTheRequestTokenHasSmallestDuration_ThenItShouldBeTheOneCancellingTheRequestCausingTaskCancelledException()
    {
        // Arrange
        var client = _factory.CreateClient();
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(1));

        // Act       
        // Assert
        await Assert.ThrowsAsync<TaskCanceledException>(() => client.GetAsync("/api/test-combined-timeout", cts.Token));
    }
}