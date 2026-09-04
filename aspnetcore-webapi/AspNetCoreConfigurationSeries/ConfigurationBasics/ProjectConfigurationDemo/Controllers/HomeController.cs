using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjectConfigurationDemo.Models;

namespace ProjectConfigurationDemo.Controllers;

public class HomeController(ILogger<HomeController> logger, IConfiguration configuration) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;
    private readonly IConfiguration _configuration = configuration;

    public IActionResult Index()
    {
        var logLevelConfiguration = new LoggingLevelConfiguration();

        _configuration.Bind("Logging:LogLevel", logLevelConfiguration);

        var homeModel = new HomeModel
        {
            DefaultLogLevel = logLevelConfiguration.Default
        };

        return View(homeModel);
    }

    public IActionResult Privacy() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() =>
        View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
