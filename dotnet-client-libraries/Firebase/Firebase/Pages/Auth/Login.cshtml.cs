using Firebase.Dtos;
using Firebase.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Firebase.Pages.Auth
{
    public class LoginModel : PageModel
    {

        private readonly IFirebaseAuthService _authService;

        [BindProperty]
        public UserDto UserDto { get; set; }

        public LoginModel(IFirebaseAuthService authService)
        {
            _authService = authService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var token = await _authService.Login(UserDto.Email, UserDto.Password);

            if (token is not null)
            {
                HttpContext.Session.SetString("token", token);
                return RedirectToPage("/Firestore/Index");
            }

            return BadRequest();
        }
    }
}
