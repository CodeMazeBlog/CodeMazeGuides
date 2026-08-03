using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ViewBasedAuthorization.Pages.Account;

public class LogoutModel : PageModel
{
    private readonly SignInManager<IdentityUser> _signInManager;

    public LogoutModel(SignInManager<IdentityUser> signInManager)
    {
        _signInManager = signInManager;
    }

    public IActionResult OnGet()
    {
        return RedirectToPage("/Index");
    }

    public IActionResult OnPost()
    {
        _signInManager.SignOutAsync();
        return RedirectToPage("/Index");
    }
}
