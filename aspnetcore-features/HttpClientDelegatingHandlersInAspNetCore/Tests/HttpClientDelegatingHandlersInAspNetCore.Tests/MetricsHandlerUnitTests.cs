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

        mockInnerHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK))
            .Verifiable();

        var metricsHandler = new MetricsHandler(mockLogger.Object)
        {
            InnerHandler = mockInnerHandler.Object
        };

        var invoker = new HttpMessageInvoker(metricsHandler);

        // Act
        var request = new HttpRequestMessage(HttpMethod.Get, urlString);
        var response = await invoker.SendAsync(request, CancellationToken.None);

        // Assert
        Assert.True(response.IsSuccessStatusCode);

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