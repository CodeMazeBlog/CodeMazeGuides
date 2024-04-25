namespace HttpClientDelegatingHandlersInAspNetCore.Tests;

using DelegatingHandlers;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using Services.Abstract;
using System.Net;

public class AuthorizationHandlerUnitTests
{
    private static Func<HttpRequestMessage, string, bool> TokenValidationCondition = (req, expectedToken) => req.Headers.Authorization != null
        && req.Headers.Authorization.Scheme == "Bearer"
        && req.Headers.Authorization.Parameter == expectedToken;

    [Fact]
    public async Task GivenSendAsyncIsInvoked_WhenAuthorizationHandlerIsUsed_ThenAddsAuthorizationHeaderWithToken()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<AuthorizationHandler>>();
        var mockTokenGenerator = new Mock<ITokenGenerator>();
        var expectedToken = "dummy-token";

        mockTokenGenerator.Setup(t => t.GenerateToken()).Returns(expectedToken);

        var mockInnerHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);

        mockInnerHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(request => TokenValidationCondition(request, expectedToken)),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK))
            .Verifiable("Authorization header was not set correctly.");

        var handler = new AuthorizationHandler(mockTokenGenerator.Object, mockLogger.Object)
        {
            InnerHandler = mockInnerHandler.Object
        };

        var invoker = new HttpMessageInvoker(handler);
        var request = new HttpRequestMessage(HttpMethod.Get, "http://example.com");

        // Act
        var response = await invoker.SendAsync(request, CancellationToken.None);

        // Assert
        Assert.True(response.IsSuccessStatusCode);

        mockInnerHandler.Protected().Verify(
            "SendAsync",
            Times.Once(),
            ItExpr.Is<HttpRequestMessage>(request => TokenValidationCondition(request, expectedToken)),
            ItExpr.IsAny<CancellationToken>());

        mockTokenGenerator.Verify(t => t.GenerateToken(), Times.Once);
    }
}
