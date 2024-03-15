using ArtistsApplication.Controllers;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

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
        var actionResult = controller.Get();

        // Assert.
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var artists = Assert.IsType<Artist[]>(okResult.Value);
        Assert.NotNull(artists);
        Assert.NotEmpty(artists);
    }
}