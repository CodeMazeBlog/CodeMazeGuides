namespace AuthApi.Auth.Models;
public record AuthenticationToken(string Token, int ExpiresIn);
