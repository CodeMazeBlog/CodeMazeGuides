using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccessHttpContext.Pages;

public class ExampleModel : PageModel
{
    private string? _path;

    public void OnGet()
    {
        _path = HttpContext.Request.Path;
    }

    public string Path => $"Path: {_path}";
}