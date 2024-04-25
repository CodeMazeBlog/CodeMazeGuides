namespace HttpClientDelegatingHandlersInAspNetCore.Tests;

using DelegatingHandlers;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using Services.Abstract;
using System;
using System.Threading.Tasks;

public class MetricsHandlerUnitTests
{
    [Fact]
    public async Task GivenSendAsyncIsInvoked_WhenMetricsHandlerIsUsed_ThenMeasuresTime()
    {
        // Arrange
        var testUri = "http://example.com/";
        var mockLogger = new Mock<ILogger<MetricsHandler>>();
        var mockMetricsProvider = new Mock<IMetricsProvider>();
        var mockDisposable = new Mock<IDisposable>();

        mockMetricsProvider.Setup(p => p.MeasureTime(It.Is<string>(uri => uri == testUri)))
            .Returns(mockDisposable.Object);

        var mockInnerHandler = new Mock<HttpMessageHandler>();

        mockInnerHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => req.RequestUri.ToString() == testUri),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(System.Net.HttpStatusCode.OK))
            .Verifiable();

        var handler = new MetricsHandler(mockMetricsProvider.Object, mockLogger.Object)
        {
            InnerHandler = mockInnerHandler.Object
        };

        var invoker = new HttpMessageInvoker(handler);

        var request = new HttpRequestMessage(HttpMethod.Get, testUri);

        // Act
        var response = await invoker.SendAsync(request, CancellationToken.None);

        // Assert
        Assert.True(response.IsSuccessStatusCode);

        mockMetricsProvider.Verify(m => m.MeasureTime(It.IsAny<string>()), Times.Once);

        mockDisposable.Verify(d => d.Dispose(), Times.Once);

        mockInnerHandler.Protected().Verify(
            "SendAsync",
            Times.Once(),
            ItExpr.Is<HttpRequestMessage>(req => req.RequestUri.ToString() == testUri),
            ItExpr.IsAny<CancellationToken>());
    }
}