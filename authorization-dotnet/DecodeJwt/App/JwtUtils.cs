using System.IdentityModel.Tokens.Jwt;
using IdentityModel.Client;

namespace App;

public static class JwtUtils
{
    public static async Task<string?> GetAccessTokenFromDuendeIdentityServerAsync()
    {
        TokenResponse tokenResponse;
        using (var client = new HttpClient())
        {
            var disco = await client.GetDiscoveryDocumentAsync("https://demo.duendesoftware.com");
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return string.Empty;
            }

            tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                { Address = disco.TokenEndpoint, ClientId = "m2m", ClientSecret = "secret", Scope = "api" });
        }

        if (!tokenResponse.IsError) return tokenResponse.AccessToken;
        Console.WriteLine(tokenResponse.Error);
        return string.Empty;
    }

    public static JwtSecurityToken ConvertJwtStringToJwtSecurityToken(string? jwt)
    {
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadJwtToken(jwt);
        return token;
    }

    public static (string Issuer, List<string> Audience, List<(string Type, string Value)> Claims, DateTime Expiration,
        string SigningAlgorithm, string RawData, string Subject, DateTime ValidFrom, string Header, string Payload)
        DecodeJwt(JwtSecurityToken token)
    {
        // Get the issuer
        var issuer = token.Issuer;

        // Get the audience
        var audience = token.Audiences.ToList();

        // Get the claims
        var claims = token.Claims.Select(claim => (claim.Type, claim.Value)).ToList();

        // Get the expiration
        var expiration = token.ValidTo;

        // Get the signing algorithm
        var signingAlgorithm = token.SignatureAlgorithm;

        // Get the raw data
        var rawData = token.RawData;

        // Get the subject (it will be empty as the grant_type is client_credentials - Machine to Machine)
        var subject = token.Subject;

        // Get the valid from
        var validFrom = token.ValidFrom;

        // Get the header 
        var header = token.EncodedHeader;

        // Get the payload 
        var payload = token.EncodedPayload;

        return (issuer, audience, claims, expiration, signingAlgorithm, rawData, subject, validFrom, header, payload);
    }
}