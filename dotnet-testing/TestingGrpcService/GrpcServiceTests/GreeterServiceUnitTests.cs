using Grpc.Core.Testing;
using Microsoft.Extensions.Logging;
using Moq;
using TestingGrpcService;
using TestingGrpcService.Services;

namespace GrpcServiceTests
{
    public class GreeterServiceUnitTests
    {
        private readonly Mock<ILogger<GreeterService>> _logger;

        public GreeterServiceUnitTests()
        {
            _logger = new Mock<ILogger<GreeterService>>();
        }

        private GreeterService CreateGreeterService()
        {
            return new GreeterService(_logger.Object);
        }

        [Fact]
        public async Task WhenSayHelloIsCalled_ThenItReturnsExpectedResponse2()
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
            _logger.Verify(
                 x => x.Log(
                     LogLevel.Information,
                     It.IsAny<EventId>(),
                     It.Is<It.IsAnyType>((o, t) => string.Equals("Request from: localhost", o.ToString(), StringComparison.InvariantCultureIgnoreCase)),
                     null,
                     It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                 Times.Once);
        }
    }
}