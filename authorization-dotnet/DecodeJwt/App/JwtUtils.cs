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
            var discoveryDocument = await client.GetDiscoveryDocumentAsync("https://demo.duendesoftware.com");
            if (discoveryDocument.IsError)
            {
                throw new Exception(discoveryDocument.Error);
            }

            tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                { Address = discoveryDocument.TokenEndpoint, ClientId = "m2m", ClientSecret = "secret", Scope = "api" });
        }

        if (tokenResponse.IsError) 
        {
            throw new Exception(tokenResponse.Error);
        }
        
        return tokenResponse.AccessToken;
    }

    public static JwtSecurityToken ConvertJwtStringToJwtSecurityToken(string? jwt)
    {
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadJwtToken(jwt);
        
        return token;
    }

    public static DecodedToken DecodeJwt(JwtSecurityToken token)
    {
        var keyId = token.Header.Kid;
        var audience = token.Audiences.ToList();
        var claims = token.Claims.Select(claim => (claim.Type, claim.Value)).ToList();

        return new DecodedToken(
            keyId,
            token.Issuer,
            audience,
            claims,
            token.ValidTo,
            token.SignatureAlgorithm,
            token.RawData,
            token.Subject,
            token.ValidFrom,
            token.EncodedHeader,
            token.EncodedPayload
        );
    }
}
