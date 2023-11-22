using App;

var accessToken = await JwtUtils.GetAccessTokenFromDuendeIdentityServerAsync();
Console.WriteLine(accessToken);
var jwt = JwtUtils.ConvertJwtStringToJwtSecurityToken(accessToken);
Console.WriteLine(jwt);
JwtUtils.DecodeJwt(jwt);