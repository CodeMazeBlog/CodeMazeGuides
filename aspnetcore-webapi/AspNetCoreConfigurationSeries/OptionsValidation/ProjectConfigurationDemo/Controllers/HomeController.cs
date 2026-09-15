using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ProjectConfigurationDemo.Models;
using ProjectConfigurationDemo.Services;

namespace ProjectConfigurationDemo.Controllers;

public class HomeController(
    ILogger<HomeController> logger,
    IOptionsSnapshot<TitleConfiguration> homePageTitleConfiguration,
    ITitleColorService titleColorService) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;
    private readonly TitleConfiguration _homePageTitleConfiguration = homePageTitleConfiguration.Value;
    private readonly ITitleColorService _titleColorService = titleColorService;

    public IActionResult Index()
    {
        var homeModel = new HomeModel
        {
            Configuration = _homePageTitleConfiguration
        };

        homeModel.Configuration.Color = _titleColorService.GetTitleColor();

        return View(homeModel);
    }

    public IActionResult Privacy() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() =>
        View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
