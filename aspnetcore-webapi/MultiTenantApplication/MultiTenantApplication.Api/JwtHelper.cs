namespace MultiTenantApplication.Api;

public class JwtHelper
{
    public const string ISSUER = "http://localhost:5113/";
    public const string AUDIENCE = "http://localhost:5113/";
    public const string SECURITY_KEY = "tokenSecurityKey@1";

    public static TokenValidationParameters GetTokenParameters()
    {
        return new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = ISSUER,
            ValidAudience = AUDIENCE,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECURITY_KEY))
        };
    }

    public static string GenerateToken(Tenant tenant)
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECURITY_KEY));
        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var tokenOptions = new JwtSecurityToken(
            issuer: ISSUER,
            audience: AUDIENCE,
            claims: new List<Claim>() { new(ClaimConstants.TenantId, tenant.Name ?? string.Empty) },
            expires: DateTime.Now.AddMinutes(10),
            signingCredentials: signinCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }
}