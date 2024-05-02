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
    public async Task AuthorizationHandler_Should_Add_Authorization_Header_And_Log_Correctly()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<AuthorizationHandler>>();
        var mockInnerHandler = new Mock<HttpMessageHandler>();

        // Mock the SendAsync method
        mockInnerHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

        var authorizationHandler = new AuthorizationHandler(mockLogger.Object)
        {
            InnerHandler = mockInnerHandler.Object
        };

        var httpClient = new HttpClient(authorizationHandler);

        // Act
        var request = new HttpRequestMessage(HttpMethod.Get, "http://example.com/test");
        var response = await httpClient.SendAsync(request);

        // Assert
        Assert.NotNull(request.Headers.Authorization);
        Assert.Equal("Bearer", request.Headers.Authorization.Scheme);
        Assert.NotEmpty(request.Headers.Authorization.Parameter);

        mockLogger.Verify(
            x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Hello from AuthorizationHandler")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Once);

        mockLogger.Verify(
            x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Goodbye from AuthorizationHandler")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Once);
    }
}