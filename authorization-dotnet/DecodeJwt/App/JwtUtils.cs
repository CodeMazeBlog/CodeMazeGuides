using System.Buffers.Text;
using System.Text;
using Duende.IdentityModel.Client;
using Microsoft.IdentityModel.JsonWebTokens;

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

    public static JsonWebToken ConvertJwtStringToJsonWebToken(string jwt)
    {
        var handler = new JsonWebTokenHandler();
        var token = handler.ReadJsonWebToken(jwt);

        return token;
    }

    public static DecodedToken DecodeJwt(JsonWebToken token)
    {
        var keyId = token.Kid;
        var audience = token.Audiences.ToList();
        var claims = token.Claims.Select(claim => (claim.Type, claim.Value)).ToList();

        return new DecodedToken(
            keyId,
            token.Issuer,
            audience,
            claims,
            token.ValidTo,
            token.Alg,
            token.EncodedToken,
            token.Subject,
            token.ValidFrom,
            token.EncodedHeader,
            token.EncodedPayload
        );
    }

    public static (string Header, string Payload) DecodeJwtWithoutLibrary(string jwt)
    {
        var parts = jwt.Split('.');
        var header = Encoding.UTF8.GetString(Base64Url.DecodeFromChars(parts[0]));
        var payload = Encoding.UTF8.GetString(Base64Url.DecodeFromChars(parts[1]));

        return (header, payload);
    }
}
