namespace HowToUseRequestTimeoutsMiddleware.Tests;

public class StarWarsControllerTests
{
    private readonly ICharacterService _starWarsService;
    private readonly StarWarsController _starWarsController;

    public StarWarsControllerTests()
    {
        _starWarsService = Substitute.For<ICharacterService>();

        _starWarsController = new StarWarsController(_starWarsService);
    }

    [Fact]
    public async Task WhenGetCharacterAsyncEndpointIsInvoked_ThenStarWarsServiceIsCalled()
    {
        // Arrange
        _starWarsService
            .GetCharacterAsync(default)
            .ReturnsForAnyArgs(new Character()
            {
                Name = "Luke Skywalker",
                Height = 172,
                BirthYear = "19BBY",
                Gender = "Male"
            });

        _starWarsController
            .ControllerContext
            .HttpContext = new DefaultHttpContext();

        // Act
        await _starWarsController.GetCharacterAsync();

        // Assert
        await _starWarsService
            .ReceivedWithAnyArgs()
            .GetCharacterAsync(default);
    }
}
