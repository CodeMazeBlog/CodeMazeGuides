using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc.Testing;
using TestingGrpcService;
using static TestingGrpcService.Greeter;

namespace GrpcServiceTests;

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
        GrpcChannelOptions options = new() { HttpHandler = _factory.Server.CreateHandler() };
        GrpcChannel channel = GrpcChannel.ForAddress(_factory.Server.BaseAddress, options);
        GreeterClient client = new(channel);

        var testName = "Test Name";
        var expectedResponse = $"Hello {testName}";
        var request = new HelloRequest { Name = testName };

        // Act
        var response = await client.SayHelloAsync(request);

        // Assert
        Assert.Equal(expectedResponse, response.Message);
    }
}
