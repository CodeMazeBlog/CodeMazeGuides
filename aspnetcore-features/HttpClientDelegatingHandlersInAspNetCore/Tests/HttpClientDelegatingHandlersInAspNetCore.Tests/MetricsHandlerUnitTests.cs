namespace HttpClientDelegatingHandlersInAspNetCore.Tests;

using DelegatingHandlers;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using System;
using System.Net;
using System.Threading.Tasks;

public class MetricsHandlerUnitTests
{
    [Fact]
    public async Task GivenSendAsyncIsInvoked_WhenMetricsHandlerIsUsed_ThenLogsInformationBeforeAndAfterSending()
    {
        // Arrange
        var urlString = "http://example.com/test";
        var mockLogger = new Mock<ILogger<MetricsHandler>>();
        var mockInnerHandler = new Mock<HttpMessageHandler>();

        // Mock SendAsync to return a successful response
        mockInnerHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK))
            .Verifiable();

        // Create an instance of the handler, setting the inner handler
        var metricsHandler = new MetricsHandler(mockLogger.Object)
        {
            InnerHandler = mockInnerHandler.Object
        };

        // Use HttpMessageInvoker instead of HttpClient to prevent automatic disposal
        var invoker = new HttpMessageInvoker(metricsHandler);

        // Act
        var request = new HttpRequestMessage(HttpMethod.Get, urlString);
        var response = await invoker.SendAsync(request, CancellationToken.None);

        // Assert
        Assert.True(response.IsSuccessStatusCode);

        // Verify that the log messages are called
        mockLogger.Verify(
            x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Hello from MetricsHandler")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Once);

        mockLogger.Verify(
            x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString().Contains($"Request duration for {urlString}")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Once);

        mockLogger.Verify(
            x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Goodbye from MetricsHandler")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Once);
    }
}