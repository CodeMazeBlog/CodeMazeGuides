using Microsoft.AspNetCore.Identity;

namespace TwoFactorAuthenticationGoogleAuthenticatorAngular.Models
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
