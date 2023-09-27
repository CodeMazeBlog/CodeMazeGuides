using Localization.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;

namespace Localization.Controllers;
public class LocalizationController : Controller
{
    private readonly IHtmlLocalizer<LocalizationController> _localizer;

    public LocalizationController(IHtmlLocalizer<LocalizationController> localizer)
    {
        _localizer = localizer;
    }

    public IActionResult Index()
    {
        ViewData["Greeting"] = _localizer["Greeting"];
        return View();
    }

    public IActionResult LocalizedView()
    {
        return View();
    }

    public IActionResult DataAnnotationView([FromQuery] string? culture)
    {
        ViewData["culture"] = culture;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DataAnnotationView(PersonViewModel personViewModel, [FromQuery] string? culture)
    {
        ViewData["culture"] = culture;

        if (!ModelState.IsValid)
        {
            return View();
        }

        return View();
    }
}
