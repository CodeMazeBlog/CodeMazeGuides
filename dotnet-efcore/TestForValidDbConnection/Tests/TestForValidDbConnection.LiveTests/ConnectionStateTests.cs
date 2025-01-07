using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace TestForValidDbConnection.LiveTests;

public class ConnectionStateLiveTests(WebApplicationFactory<Program> Factory) : IClassFixture<WebApplicationFactory<Program>>
{
    [Fact]
    public async Task GivenDatabaseIsAvailable_WhenRequestingConnectivityStatus_ThenReturnOk()
    {
        // Arrange
        var requestUri = "/can-connect";
        var client = Factory.CreateClient();

        // Act
        var response = await client.GetAsync(requestUri);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GivenDatabaseIsAvailable_WhenRequestingHealthCheckStatus_ThenReturnOk()
    {
        // Arrange
        var requestUri = "/health";
        var client = Factory.CreateClient();

        // Act
        var response = await client.GetAsync(requestUri);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}