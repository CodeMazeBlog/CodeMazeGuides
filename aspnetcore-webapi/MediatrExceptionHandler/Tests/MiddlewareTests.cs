using MediatR.Pipeline;
using MediatrExceptionHandler.Common;
using MediatrExceptionHandler;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;

public class MiddlewareTests
{
    private Mock<ILogger<GlobalRequestExceptionHandler<BaseRequest<WeatherResponse>, WeatherResponse, Exception>>> loggerMock;
    private BaseRequest<WeatherResponse> _request;
    private Exception _exception;
    private Mock<RequestExceptionHandlerState<WeatherResponse>> _stateMock;
    private GlobalRequestExceptionHandler<BaseRequest<WeatherResponse>, WeatherResponse, Exception> _middleware;

    public MiddlewareTests()
    {
        // Arrange
        loggerMock = new();
        _request = new();
        _exception = new ("Test exception");
        _stateMock = new();
        _middleware = new(loggerMock.Object);
    }

    [Fact]
    public async Task WhenThrowingHandlerException_ThenMiddlewareHandlesResponse()
    {
        // Act
        await _middleware.Handle(_request, _exception, _stateMock.Object, CancellationToken.None);

        // Assert
        Assert.True(_stateMock.Object.Handled);
     }

    [Fact]
    public async Task WhenThrowingHandlerException_ThenMiddlewareResponseWithCorrectString()
    {
        // Act
        await _middleware.Handle(_request, _exception, _stateMock.Object, CancellationToken.None);

        // Assert
        var expected = JsonConvert.SerializeObject(_stateMock.Object.Response.Message);
        var actual = JsonConvert.SerializeObject("A server error ocurred");
        Assert.Equal(expected, actual);
    }
}