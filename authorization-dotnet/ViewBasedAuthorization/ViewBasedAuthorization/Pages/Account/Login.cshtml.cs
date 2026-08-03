using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ViewBasedAuthorization.Pages.Account;

public class LoginModel : PageModel
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public LoginModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [BindProperty]
    public InputModel Input { get; set; }

    public class InputModel
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            var result = _signInManager.PasswordSignInAsync(Input.Email, Input.Password, isPersistent: false, lockoutOnFailure: false).Result;
            if (result.Succeeded)
            {
                return RedirectToPage("/Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
        }

        return Page();
    }
}
