namespace TwoFactorAuthenticationGoogleAuthenticatorAngular.DataTransferObjects
{
    public class AuthResponseDto
    {
        public bool IsAuthSuccessful { get; set; }
        public bool IsTfaEnabled { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Token { get; set; }
    }
}
