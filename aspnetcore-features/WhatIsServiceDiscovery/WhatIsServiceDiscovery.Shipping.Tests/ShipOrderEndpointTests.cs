namespace WhatIsServiceDiscovery.Shipping.Tests;

public class ShipOrderEndpointTests(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory = factory;

    [Fact]
    public async Task WhenShipOrderEndpointIsCalled_ThenSuccessStatusCodeIsReturned()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/shiporder");

        // Assert
        response.EnsureSuccessStatusCode();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var content = await response.Content.ReadAsStringAsync();
        content.Should().Contain("Your order has been shipped");
    }
}