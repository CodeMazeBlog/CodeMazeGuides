namespace TwoFactorAuthenticationGoogleAuthenticatorAngular.Models
{
    public class AuthResponseDto
    {
        public bool IsAuthSuccessful { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Token { get; set; }
    }
}
