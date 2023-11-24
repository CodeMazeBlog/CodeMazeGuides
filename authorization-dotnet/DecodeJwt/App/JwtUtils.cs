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

        if (!tokenResponse.IsError) return tokenResponse.AccessToken;
        throw new Exception(tokenResponse.Error);
    }

    public static JwtSecurityToken ConvertJwtStringToJwtSecurityToken(string? jwt)
    {
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadJwtToken(jwt);
        
        return token;
    }

    public static DecodedToken DecodeJwt(JwtSecurityToken token)
    {
        // Get the KeyId
        var keyId = token.Header.Kid;

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

        return new DecodedToken(
            keyId,
            issuer,
            audience,
            claims,
            expiration,
            signingAlgorithm,
            rawData,
            subject,
            validFrom,
            header,
            payload
        );
    }

}