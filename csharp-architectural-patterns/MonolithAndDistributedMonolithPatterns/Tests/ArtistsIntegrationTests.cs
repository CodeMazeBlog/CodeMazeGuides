using ArtistsApplication.Controllers;

namespace Tests;

public class ArtistsIntegrationTests
{
    [Fact]
    public void GivenArtistsController_WhenCallingGet_ThenReturnsAllArtists()
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