namespace HttpClientDelegatingHandlersInAspNetCore.Tests;

using DelegatingHandlers;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using System.Net;
using System.Reflection;

public class TransientIdentifiableHandlerUnitTests
{
    [Fact]
    public async Task GivenSendAsyncIsInvoked_WhenTransientIdentifiableHandlerIsUsed_ThenLogsInformationWithRequestId()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<TransientIdentifiableHandler>>();
        var mockInnerHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);

        mockInnerHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK))
            .Verifiable();

        var handler = new TransientIdentifiableHandler(mockLogger.Object)
        {
            InnerHandler = mockInnerHandler.Object,
        };

        var invoker = new HttpMessageInvoker(handler);

        // Act
        var response = await invoker.SendAsync(new HttpRequestMessage(HttpMethod.Get, "http://example.com"), CancellationToken.None);

        var id = GetPrivateIdFieldValue(handler);

        // Assert
        Assert.True(response.IsSuccessStatusCode);

        mockLogger.Verify(
            x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString().Contains($"Request made from handler with Id: {id}")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Once);
    }

    private static Guid GetPrivateIdFieldValue(TransientIdentifiableHandler handler)
    {
        var idField = typeof(TransientIdentifiableHandler).GetField("_id", BindingFlags.NonPublic | BindingFlags.Instance);

        return (Guid)idField.GetValue(handler);
    }
}