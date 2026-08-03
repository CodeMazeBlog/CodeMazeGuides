using AccessTokenFromHttpContext.Middlewares;
using AccessTokenFromHttpContextTests.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Moq;

namespace AccessTokenFromHttpContextTests.Middleware;
public class AccessTokenMiddlewareTests
{
    private readonly HttpContext _context;
    private readonly AccessTokenMiddleware _sut;
    private readonly Mock<IAuthenticationService> _authServiceMock;

    public AccessTokenMiddlewareTests()
    {
        var serviceProviderMock = new Mock<IServiceProvider>();
        _authServiceMock = new Mock<IAuthenticationService>();

        serviceProviderMock.Setup(_ => _.GetService(typeof(IAuthenticationService))).Returns(_authServiceMock.Object);

        _context = new DefaultHttpContext()
        {
            RequestServices = serviceProviderMock.Object,
        };

        static async Task Next(HttpContext next) => await Task.CompletedTask;

        _sut = new AccessTokenMiddleware(Next);
    }

    [Fact]
    public async Task Invoke_WhenAccessTokenExists_ThenWeCanRetrieveItFromItems()
    {
        var authResult = TestAuthenticationExtensions.SetTokenNameAndTokenValue("access_token", MockData.AccessTokenWithoutBearer);

        _authServiceMock
            .Setup(x => x.AuthenticateAsync(It.IsAny<HttpContext>(), null))
            .ReturnsAsync(authResult);

        await _sut.Invoke(_context);

        var result = _context.Items["AccessToken"];

        Assert.Equal(result, MockData.AccessTokenWithoutBearer);
    }

    [Fact]
    public async Task Invoke_WhenAccessTokenEmpty_ThenWeCanRetrieveItFromItems()
    {
        var authResult = TestAuthenticationExtensions.SetTokenNameAndTokenValue("access_token", string.Empty);

        _authServiceMock
            .Setup(x => x.AuthenticateAsync(It.IsAny<HttpContext>(), null))
            .ReturnsAsync(authResult);

        await _sut.Invoke(_context);

        var accessToken = _context.Items["AccessToken"];

        Assert.Equal(accessToken, string.Empty);
    }
}
