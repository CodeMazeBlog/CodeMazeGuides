using DependencyInjectionDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionDemo.Controllers;

public class GameController : Controller
{
    private readonly ILogger<GameController> _logger;
    private readonly IPlayerGenerator _playerGenerator;

    public GameController(ILogger<GameController> logger, IPlayerGenerator playerGenerator)
    {
        _logger = logger;
        _playerGenerator = playerGenerator;
    }

    public IActionResult Index()
    {
        var newPlayer = _playerGenerator.CreateNewPlayer();
        _logger.LogInformation("Created a new player: {Name}", newPlayer.Name);

        return View(newPlayer);
    }
}
