using AccessTokenFromHttpContext.Services;
using AccessTokenFromHttpContextTests.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;

namespace AccessTokenFromHttpContextTests.Services;
public class HttpContextAccessorServiceTests
{
    private readonly HttpContextAccessorService _sut;
    private readonly Mock<IHttpContextAccessor> _httpContextAccessorMock;
    private readonly Mock<IAuthenticationService> _authServiceMock;

    public HttpContextAccessorServiceTests()
    {
        _httpContextAccessorMock = new Mock<IHttpContextAccessor>();

        var serviceProviderMock = new Mock<IServiceProvider>();
        _authServiceMock = new Mock<IAuthenticationService>();

        serviceProviderMock.Setup(_ => _.GetService(typeof(IAuthenticationService))).Returns(_authServiceMock.Object);

        var httpContext = new DefaultHttpContext()
        {
            RequestServices = serviceProviderMock.Object,
        };

        _httpContextAccessorMock.Setup(x => x.HttpContext).Returns(httpContext);
        _sut = new HttpContextAccessorService(_httpContextAccessorMock.Object);
    }

    [Fact]
    public async Task GetAccessToken_WhenAccessTokenExists_ThenReturnRightToken()
    {
        var authResult = TestAuthenticationExtensions.SetTokenNameAndTokenValue("access_token", MockData.AccessTokenWithoutBearer);

        _authServiceMock
            .Setup(x => x.AuthenticateAsync(It.IsAny<HttpContext>(), null))
            .ReturnsAsync(authResult);

        var result = await _sut.GetAccessToken();

        Assert.Equal(result, MockData.AccessTokenWithoutBearer);
    }

    [Fact]
    public async Task GetAccessToken_WhenAccessTokenEmpty_ThenReturnEmptyToken()
    {
        var authResult = TestAuthenticationExtensions.SetTokenNameAndTokenValue("access_token", string.Empty);

        _authServiceMock
            .Setup(x => x.AuthenticateAsync(It.IsAny<HttpContext>(), null))
            .ReturnsAsync(authResult);

        var result = await _sut.GetAccessToken();

        Assert.Equal(result, string.Empty);
    }
}
