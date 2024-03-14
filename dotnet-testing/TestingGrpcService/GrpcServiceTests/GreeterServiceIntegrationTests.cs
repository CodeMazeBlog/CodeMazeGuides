using Grpc.Net.Client;
using TestingGrpcService;
using Microsoft.AspNetCore.Mvc.Testing;

namespace GrpcServiceTests
{
    public class GreeterServiceIntegrationTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public GreeterServiceIntegrationTests(CustomWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task WhenSayHelloAsyncIsCalled_ThenItShouldReturnCorrectName()
        {
            // Arrange
            var channel = GrpcChannel.ForAddress(_factory.Server.BaseAddress, new GrpcChannelOptions { HttpHandler = _factory.Server.CreateHandler() });
            var client = new Greeter.GreeterClient(channel);

            var testName = "Test Name";
            var expectedResponse = $"Hello {testName}";
            var request = new HelloRequest { Name = testName };

            // Act
            var response = await client.SayHelloAsync(request);

            // Assert
            Assert.Equal(expectedResponse, response.Message);
        }
    }
}
