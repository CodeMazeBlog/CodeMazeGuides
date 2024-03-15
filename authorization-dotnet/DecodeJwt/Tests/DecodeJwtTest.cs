namespace Tests;

public class DecodeJwtTest
{
    [Fact]
    public async Task WhenJwtIsRetrievedFromServer_ThenItShouldNotBeNull()
    {
        var jwt = await JwtUtils.GetAccessTokenFromDuendeIdentityServerAsync();

        Assert.NotNull(jwt);
    }

    [Theory]
    [ClassData(typeof(JwtTestData))]
    public void WhenJwtIsValid_ThenItShouldDecode(string token)
    {
        var jwt = JwtUtils.ConvertJwtStringToJwtSecurityToken(token);
        var jwtData = JwtUtils.DecodeJwt(jwt);

        Assert.NotNull(jwtData.Issuer);
        Assert.NotEmpty(jwtData.Audience);
        Assert.NotEmpty(jwtData.Claims);
    }
}