namespace HttpClientDefaultAndPerRequestTimeOut.Tests;

using Microsoft.AspNetCore.Mvc.Testing;

public class TimeOutTestsControllerTests
{
    private readonly WebApplicationFactory<Program> _factory;

    public TimeOutTestsControllerTests()
    {
        _factory = new WebApplicationFactory<Program>();
    }

    [Fact]
    public async Task WhenGlobalTimeOutPassed_ThenReturnMessageWithCancellationDetails()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act      
        var responseMessage = await client.GetAsync("/api/test-global-timeout");
        var responseContent = await responseMessage.Content.ReadAsStringAsync();

        // Assert
        Assert.Equal("TaskCanceledException: HttpClient global timeout passed", responseContent);
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
        var responseMessage = await client.GetAsync("/api/test-combined-timeout");
        var responseContent = await responseMessage.Content.ReadAsStringAsync();

        // Assert
        Assert.Equal("TaskCanceledException: Specific token canceled", responseContent);
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