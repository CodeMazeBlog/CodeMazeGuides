using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace Firebase.Authentication;

public class FirebaseAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private const string BearerPrefix = "Bearer ";

    private readonly FirebaseApp _firebaseApp;

    public FirebaseAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            FirebaseApp firebaseApp)
            : base(options, logger, encoder, clock)
    {
        _firebaseApp = firebaseApp;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Context.Request.Headers.ContainsKey("Authorization"))
        {
            return AuthenticateResult.NoResult();
        }

        var bearerToken = Context.Request.Headers["Authorization"].FirstOrDefault();

        if (bearerToken is null || !bearerToken.StartsWith(BearerPrefix))
        {
            return AuthenticateResult.Fail("Invalid authentication scheme");
        }

        var token = bearerToken[BearerPrefix.Length..];

        try
        {
            var firebaseToken = await FirebaseAuth.GetAuth(_firebaseApp).VerifyIdTokenAsync(token);

            return AuthenticateResult.Success(CreateAuthenticationTicket(firebaseToken));
        }
        catch (Exception ex)
        {
            return AuthenticateResult.Fail(ex);
        }
    }

    private AuthenticationTicket CreateAuthenticationTicket(FirebaseToken firebaseToken)
    {
        var claimsPrincipal = new ClaimsPrincipal(new List<ClaimsIdentity>()
        {
            new ClaimsIdentity(ConverFirebaseTokenToClaims(firebaseToken.Claims), nameof(ClaimsIdentity))
        });

        return new AuthenticationTicket(claimsPrincipal, JwtBearerDefaults.AuthenticationScheme);
    }

    private static IEnumerable<Claim> ConverFirebaseTokenToClaims(IReadOnlyDictionary<string, object> claims)
    {
        return new List<Claim>
        {
            new Claim("id", claims.GetValueOrDefault("user_id", string.Empty).ToString() ?? string.Empty),
            new Claim("email", claims.GetValueOrDefault("email", string.Empty).ToString() ?? string.Empty),
        };
    }
}
