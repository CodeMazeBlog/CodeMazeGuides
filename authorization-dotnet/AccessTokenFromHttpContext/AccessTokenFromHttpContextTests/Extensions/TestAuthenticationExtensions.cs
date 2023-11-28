using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace AccessTokenFromHttpContextTests.Extensions;
public static class TestAuthenticationExtensions
{
    public static AuthenticateResult SetTokenNameAndTokenValue(string tokenName, string tokenValue)
    {
        var authResult = AuthenticateResult.Success(
            new AuthenticationTicket(new ClaimsPrincipal(), null!));

        authResult.Properties!.StoreTokens(new[]
        {
            new AuthenticationToken { Name = tokenName, Value = tokenValue }
        });

        return authResult;
    }
}
