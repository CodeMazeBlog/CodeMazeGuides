using ArtistsApplication.Controllers;

namespace Tests;

public class ArtistsIntegationTests
{
    [Fact]
    public void WhenCallingGet_Artists_ReturnsAllArtists()
    {
        // Arrange.
        var musicRepository = new MusicRepository();
        var controller = new ArtistsController(musicRepository);

        // Act.
        var artists = controller.Get();

        // Assert.
        Assert.NotNull(artists);
        Assert.NotEmpty(artists);
    }
}