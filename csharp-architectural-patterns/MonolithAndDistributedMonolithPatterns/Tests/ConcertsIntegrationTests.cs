using ConcertsApplication.Controllers;

namespace Tests;

public class ConcertsIntegrationTests
{
    [Fact]
    public void WhenCallingGet_Concerts_ReturnsAllConcerts()
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