using Grpc.Core.Testing;
using Microsoft.Extensions.Logging;
using NSubstitute;
using TestingGrpcService;
using TestingGrpcService.Services;

namespace GrpcServiceTests;

public class GreeterServiceUnitTests
{
    private readonly ILogger<GreeterService> _logger;

    public GreeterServiceUnitTests()
    {
        _logger = Substitute.For<ILogger<GreeterService>>();
    }

    private GreeterService CreateGreeterService() => new(_logger);

    [Fact]
    public async Task WhenSayHelloAsyncIsCalled_ThenItShouldReturnCorrectName()
    {
        // Arrange
        var service = CreateGreeterService();
        var testName = "Test Name";
        var expectedOutput = $"Hello {testName}";
        var request = new HelloRequest { Name = testName };

        var peer = "localhost";
        var mockContext = TestServerCallContext.Create(
            method: "",
            host: "",
            deadline: DateTime.UtcNow.AddMinutes(30),
            requestHeaders: [],
            cancellationToken: CancellationToken.None,
            peer: peer,
            authContext: null,
            contextPropagationToken: null,
            writeHeadersFunc: null,
            writeOptionsGetter: null,
            writeOptionsSetter: null);

        // Act
        var response = await service.SayHello(request, mockContext);

        // Assert
        Assert.Equal(expectedOutput, response.Message);

        _logger.Received(1).Log(
            LogLevel.Information,
            Arg.Any<EventId>(),
            Arg.Is<object>(o => o.ToString()!.Contains("Request from: localhost")),
            null,
            Arg.Any<Func<object, Exception, string>>());
    }
}
