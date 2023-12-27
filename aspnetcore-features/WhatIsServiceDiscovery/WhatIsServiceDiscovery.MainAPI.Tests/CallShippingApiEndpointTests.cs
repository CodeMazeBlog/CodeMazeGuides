namespace WhatIsServiceDiscovery.MainAPI.Tests;

public class CallShippingApiEndpointTests(MainAPIApplicationFactory factory) : IClassFixture<MainAPIApplicationFactory>
{
    private readonly MainAPIApplicationFactory _factory = factory;

    [Fact]
    public async Task WhenCallShippingApiEndpointIsCalled_ThenSuccessStatusCodeIsReturned()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/callshippingapi");

        // Assert
        response.EnsureSuccessStatusCode();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        
        var content = await response.Content.ReadAsStringAsync();
        content.Should().Contain("Shipping API returned");
    }
}