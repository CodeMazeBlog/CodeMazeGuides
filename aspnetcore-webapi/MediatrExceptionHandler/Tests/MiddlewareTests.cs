using MediatR.Pipeline;
using MediatrExceptionHandler.Common;
using MediatrExceptionHandler;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;

public class MiddlewareTests
{
    Mock<ILogger<GlobalRequestExceptionHandler<BaseRequest<WeatherResponse>, WeatherResponse, Exception>>> loggerMock;
    BaseRequest<WeatherResponse> request;
    Exception exception;
    Mock<RequestExceptionHandlerState<WeatherResponse>> stateMock;
    GlobalRequestExceptionHandler<BaseRequest<WeatherResponse>, WeatherResponse, Exception> middleware;

    public MiddlewareTests()
    {
        // Arrange
        loggerMock = new();
        request = new();
        exception = new ("Test exception");
        stateMock = new();
        middleware = new(loggerMock.Object);
    }

    [Fact]
    public async Task WhenThrowingHandlerException_ThenMiddlewareHandlesResponse()
    {
        // Act
        await middleware.Handle(request, exception, stateMock.Object, CancellationToken.None);

        // Assert
        Assert.True(stateMock.Object.Handled);

     }

    [Fact]
    public async Task WhenThrowingHandlerException_ThenMiddlewareResponseWithCorrectString()
    {
        // Act
        await middleware.Handle(request, exception, stateMock.Object, CancellationToken.None);

        // Assert
        var expected = JsonConvert.SerializeObject(stateMock.Object.Response.Message);
        var actual = JsonConvert.SerializeObject("A server error ocurred");
        Assert.Equal(expected, actual);

    }
}