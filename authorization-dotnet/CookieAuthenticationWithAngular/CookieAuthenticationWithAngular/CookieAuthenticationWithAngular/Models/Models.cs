namespace CookieAuthenticationWithAngular.Models;

public record SignInRequest(string Email, string Password);

public record Response(bool IsSuccess, string Message);

public record UserClaim(string Type, string Value);

public record User(string Email, string Name, string Password);
