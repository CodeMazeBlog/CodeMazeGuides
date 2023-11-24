using App;

var accessToken = await JwtUtils.GetAccessTokenFromDuendeIdentityServerAsync();
Console.WriteLine(accessToken);
var jwt = JwtUtils.ConvertJwtStringToJwtSecurityToken(accessToken);
Console.WriteLine(jwt);
var jwtData = JwtUtils.DecodeJwt(jwt);
Console.WriteLine(jwtData.Issuer);
Console.WriteLine(jwtData.Audience);
Console.WriteLine(jwtData.Claims);
Console.WriteLine(jwtData.Expiration);
Console.WriteLine(jwtData.SigningAlgorithm);
Console.WriteLine(jwtData.RawData);
Console.WriteLine(jwtData.Subject);
Console.WriteLine(jwtData.ValidFrom);
Console.WriteLine(jwtData.Header);
Console.WriteLine(jwtData.Payload);
Console.WriteLine(jwtData.KeyId);
