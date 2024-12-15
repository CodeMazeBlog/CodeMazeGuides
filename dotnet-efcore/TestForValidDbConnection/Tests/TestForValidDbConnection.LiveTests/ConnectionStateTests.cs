namespace TestForValidDbConnection.LiveTests;

using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

public class ConnectionStateLiveTests
{
    private readonly HttpClient _client;

    public ConnectionStateLiveTests()
    {
        var factory = new WebApplicationFactory<Program>();

        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GivenDatabaseIsAvailable_WhenRequestingConectivityStatus_ThenReturnOk()
    {
        // Arrange
        var requestUri = "/can-connect";

        // Act
        var response = await _client.GetAsync(requestUri);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GivenDatabaseIsAvailable_WhenRequestingHealthCheckStatus_ThenReturnOk()
    {
        // Arrange
        var requestUri = "/health";

        // Act
        var response = await _client.GetAsync(requestUri);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}