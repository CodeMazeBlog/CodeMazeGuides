namespace UniqueConstraintsInEFCore.Tests;

public class AddPlanetEndpointLiveTests(SolarSystemApiApplicationFactory factory)
    : IClassFixture<SolarSystemApiApplicationFactory>
{
    [Fact]
    public async Task GivenThatPlanetDoesNotExist_WhenAddPlanetEndpointIsInvoked_Then201IsReturned()
    {
        // Arrange
        var client = factory.CreateClient();
        var planet = new Planet
        {
            Name = "Mars",
            Mass = 6.4171,
            Radius = 3389.5
        };

        // Act
        var response = await client.PostAsJsonAsync("/planets", planet);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }

    [Fact]
    public async Task GivenThatPlanetExist_WhenAddPlanetEndpointIsInvoked_Then400IsReturned()
    {
        // Arrange
        var client = factory.CreateClient();
        var planet = new Planet
        {
            Name = "Venus",
            Mass = 6.4171,
            Radius = 3389.5
        };

        // Act
        await client.PostAsJsonAsync("/planets", planet);
        var response = await client.PostAsJsonAsync("/planets", planet);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}
