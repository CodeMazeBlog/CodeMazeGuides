namespace Tests;

public class DecodeJwtTest
{
    [Fact]
    public async Task WhenJwtIsRetrievedFromServer_ThenItShouldNotBeNull_Live()
    {
        var jwt = await JwtUtils.GetAccessTokenFromDuendeIdentityServerAsync();

        Assert.NotNull(jwt);
    }

    [Theory]
    [ClassData(typeof(JwtTestData))]
    public void WhenJwtIsValid_ThenItShouldDecode(string token)
    {
        var jwt = JwtUtils.ConvertJwtStringToJsonWebToken(token);
        var jwtData = JwtUtils.DecodeJwt(jwt);

        Assert.NotNull(jwtData.Issuer);
        Assert.NotEmpty(jwtData.Audience);
        Assert.NotEmpty(jwtData.Claims);
    }

    [Theory]
    [ClassData(typeof(JwtTestData))]
    public void WhenJwtIsDecodedWithoutLibrary_ThenHeaderAndPayloadAreJson(string token)
    {
        var (header, payload) = JwtUtils.DecodeJwtWithoutLibrary(token);

        Assert.Contains("\"alg\":\"RS256\"", header);
        Assert.Contains("\"iss\":\"https://demo.duendesoftware.com\"", payload);
    }
}
