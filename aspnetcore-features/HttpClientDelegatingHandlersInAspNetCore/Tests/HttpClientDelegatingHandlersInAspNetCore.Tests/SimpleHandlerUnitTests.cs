namespace HttpClientDelegatingHandlersInAspNetCore.Tests;

using DelegatingHandlers;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using System.Net;

public class SimpleHandlerUnitTests
{
    [Fact]
    public async Task GivenSendAsyncIsInvoked_WhenSimpleHandlerIsUsed_ThenLogsInformationBeforeAndAfterSending()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<SimpleHandler>>();
        var mockInnerHandler = new Mock<HttpMessageHandler>();

        mockInnerHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK))
            .Verifiable();

        var handler = new SimpleHandler(mockLogger.Object)
        {
            InnerHandler = mockInnerHandler.Object
        };

        var invoker = new HttpMessageInvoker(handler);

        // Act
        var response = await invoker.SendAsync(new HttpRequestMessage(HttpMethod.Get, "http://example.com"), CancellationToken.None);

        // Assert
        Assert.True(response.IsSuccessStatusCode);

        mockLogger.Verify(
            x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Hello from SimpleHandler")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Once);

        mockLogger.Verify(
            x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Goodbye from SimpleHandler")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Once);
    }
}