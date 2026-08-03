namespace HowToUseRequestTimeoutsMiddleware.Tests;

public class StarWarsServiceTests
{
    [Fact]
    public async Task WhenGetCharacterAsyncIsInvoked_ThenExpectedCharacterIsReturned()
    {
        // Act
        var sut = new StarWarsCharacterService();
        var result = await sut.GetCharacterAsync(default);

        // Assert
        result.Should().NotBeNull();
        result.Name.Should().Be("Luke Skywalker");
    }
}