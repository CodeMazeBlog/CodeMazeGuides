using AccessTokenFromHttpContext.Controllers;
using AccessTokenFromHttpContextTests.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Security.Claims;

namespace AccessTokenFromHttpContextTests.Controllers;
public class AccessTokenControllerTests
{
    private readonly AccessTokenController _sut;
    private readonly Mock<IAuthenticationService> _authServiceMock;
    private readonly HttpContext _context;

    public AccessTokenControllerTests()
    {
        var serviceProvider = new Mock<IServiceProvider>();
        _authServiceMock = new Mock<IAuthenticationService>();

        serviceProvider.Setup(_ => _.GetService(typeof(IAuthenticationService))).Returns(_authServiceMock.Object);

        _context = new DefaultHttpContext()
        {
            RequestServices = serviceProvider.Object,
        };

        _sut = new AccessTokenController
        {
            ControllerContext = new()
            {
                HttpContext = _context
            }
        };
    }

    [Fact]
    public async Task GetAccessToken_WhenCalled_ThenReturnsAccessToken()
    {
        var authResult = TestAuthenticationExtensions.SetTokenNameAndTokenValue("access_token", MockData.AccessTokenWithoutBearer);

        _authServiceMock
            .Setup(x => x.AuthenticateAsync(It.IsAny<HttpContext>(), null))
            .ReturnsAsync(authResult);

        var accessToken = await _sut.GetAccessToken();

        Assert.Equal(MockData.AccessTokenWithoutBearer, accessToken);
    }

    [Fact]
    public async Task GetAccessToken_WhenCalled_ThenReturnsEmpty()
    {
        var authResult = TestAuthenticationExtensions.SetTokenNameAndTokenValue("access_token", string.Empty);

        _authServiceMock
            .Setup(x => x.AuthenticateAsync(It.IsAny<HttpContext>(), null))
            .ReturnsAsync(authResult);

        var accessToken = await _sut.GetAccessToken();

        Assert.Equal(accessToken, string.Empty);
    }

    [Fact]
    public async Task GetAccessTokenViaHeaders_WhenCalled_ThenReturnsAccessToken()
    {
        _context.Request.Headers["access_token"] = MockData.AccessTokenWithBearer;

        var accessToken = _sut.GetAccessTokenViaHeaders();

        Assert.Equal(MockData.AccessTokenWithoutBearer, accessToken);
    }

    [Fact]
    public async Task GetAccessTokenViaHeaders_WhenCalled_ThenReturnsEmpty()
    {
        _context.Request.Headers["access_token"] = string.Empty;

        var accessToken = _sut.GetAccessTokenViaHeaders();

        Assert.Equal(accessToken, string.Empty);
    }
}
