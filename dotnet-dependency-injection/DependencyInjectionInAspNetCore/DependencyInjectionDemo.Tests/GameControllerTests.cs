using DependencyInjectionDemo.Controllers;
using DependencyInjectionDemo.Models;
using DependencyInjectionDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;

namespace DependencyInjectionDemo.Tests;

public class GameControllerTests
{
    [Fact]
    public void Index_ShowsThePlayerFromTheGenerator()
    {
        var controller = new GameController(NullLogger<GameController>.Instance, new FakePlayerGenerator());

        var result = controller.Index();

        var view = Assert.IsType<ViewResult>(result);
        var player = Assert.IsType<Player>(view.Model);
        Assert.Equal("Test Hero", player.Name);
    }

    private class FakePlayerGenerator : IPlayerGenerator
    {
        public Player CreateNewPlayer() => new() { Name = "Test Hero", Race = "Human" };
    }
}
