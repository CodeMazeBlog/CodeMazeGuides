using ConcertsApplication.Controllers;

namespace Tests;

public class ConcertsIntegrationTests
{
    [Fact]
    public void GivenConcertsController_WhenCallingGet_ThenReturnsAllConcerts()
    {
        // Arrange.
        var musicRepository = new MusicRepository();
        var controller = new ConcertsController(musicRepository);

        // Act.
        var concerts = controller.Get();

        // Assert.
        Assert.NotNull(concerts);
        Assert.NotEmpty(concerts);
    }
}