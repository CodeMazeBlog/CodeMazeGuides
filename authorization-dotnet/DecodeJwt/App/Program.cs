using App;

var accessToken = await JwtUtils.GetAccessTokenFromDuendeIdentityServerAsync()
    ?? throw new InvalidOperationException("The token endpoint returned no access token.");
Console.WriteLine(accessToken);
var jwt = JwtUtils.ConvertJwtStringToJsonWebToken(accessToken);
Console.WriteLine(jwt);
var jwtData = JwtUtils.DecodeJwt(jwt);
Console.WriteLine(jwtData);
var (header, payload) = JwtUtils.DecodeJwtWithoutLibrary(accessToken);
Console.WriteLine(header);
Console.WriteLine(payload);
