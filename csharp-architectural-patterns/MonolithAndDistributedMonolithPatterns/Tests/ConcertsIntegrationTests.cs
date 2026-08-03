using Business.Models;
using ConcertsApplication.Controllers;
using Microsoft.AspNetCore.Mvc;

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
        var actionResult = controller.Get();

        // Assert.
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var concerts = Assert.IsType<Concert[]>(okResult.Value);
        Assert.NotNull(concerts);
        Assert.NotEmpty(concerts);
    }
}