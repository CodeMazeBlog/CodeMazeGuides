using FirebaseAuthentication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;

namespace FirebaseAuthentication.Pages.Auth
{
    public class LogoutModel : PageModel
    {
        private readonly IFirebaseAuthService _firebaseAuthService;

        public LogoutModel(IFirebaseAuthService firebaseAuthService)
        {
            _firebaseAuthService = firebaseAuthService;
        }

        public IActionResult OnGet()
        {
            _firebaseAuthService.SignOut();

            HttpContext.Session.Remove("token");

            return Page();
        }
    }
}
