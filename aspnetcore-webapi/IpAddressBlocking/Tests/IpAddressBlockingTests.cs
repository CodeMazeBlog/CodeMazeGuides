using IpAddressBlocking;
using Moq;
using Xunit;
using Microsoft.Extensions.Configuration;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc.Abstractions;
using System.Collections.Generic;

namespace Tests;
public class IpAddressBlockingTests
{
    private readonly Mock<IIpBlockingService> _mockIpBlockingService = new();
    private readonly IpBlockingService _ipBlockingService;
    private readonly string _ipAddress = "127.0.0.1";

    public IpAddressBlockingTests()
    {
        var mockConfigSection = new Mock<IConfigurationSection>();
        mockConfigSection.Setup(x => x.Value).Returns(_ipAddress);

        var mockConfig = new Mock<IConfiguration>();
        mockConfig.Setup(x => x.GetSection(It.IsAny<string>())).Returns(mockConfigSection.Object);

        _ipBlockingService = new IpBlockingService(mockConfig.Object);
    }

    [Fact]
    public void GivenIpAddressIsBlocked_WhenCheckingIfIpIsBlocked_ThenReturnsTrue()
    {
        // Arrange
        var ipAddress = IPAddress.Parse(_ipAddress);

        // Act
        var result = _ipBlockingService.IsBlocked(ipAddress);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void GivenIpAddressIsNotBlocked_WhenCheckingIfIpIsBlocked_ThenReturnsFalse()
    {
        // Arrange
        var ipAddress = IPAddress.Parse("127.0.0.2");

        // Act
        var result = _ipBlockingService.IsBlocked(ipAddress);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public async Task GivenABlockedIpAddress_WhenRequestIsMade_ThenResponseIsForbidden()
    {
        // Arrange
        const int expectedStatusCode = (int)HttpStatusCode.Forbidden;
        var ipAddress = IPAddress.Parse("127.0.0.1");

        _mockIpBlockingService.Setup(x => x.IsBlocked(ipAddress)).Returns(true);

        var httpContext = new DefaultHttpContext();
        httpContext.Connection.RemoteIpAddress = ipAddress;

        var middlewareInstance = new IpBlockMiddelware(next: (innerHttpContext) =>
        {
            return Task.CompletedTask;
        }, _mockIpBlockingService.Object);

        // Act
        await middlewareInstance.Invoke(httpContext);

        // Assert
        Assert.Equal(expectedStatusCode, httpContext.Response.StatusCode);
    }

    [Fact]
    public async Task GivenAnUnblockedIpAddress_WhenRequestIsMadeWithMiddleware_ThenNextDelegateIsInvoked()
    {
        // Arrange
        const string expectedOutput = "Request handed to next request delegate";
        var ipAddress = IPAddress.Parse("127.0.0.2");

        _mockIpBlockingService.Setup(x => x.IsBlocked(ipAddress)).Returns(false);

        var httpContext = new DefaultHttpContext();
        httpContext.Response.Body = new MemoryStream();
        httpContext.Connection.RemoteIpAddress = ipAddress;

        var middlewareInstance = new IpBlockMiddelware(next: (innerHttpContext) =>
        {
            innerHttpContext.Response.WriteAsync(expectedOutput);
            return Task.CompletedTask;
        }, _mockIpBlockingService.Object);

        // Act
        await middlewareInstance.Invoke(httpContext);

        // Assert
        httpContext.Response.Body.Seek(0, SeekOrigin.Begin);
        var body = new StreamReader(httpContext.Response.Body).ReadToEnd();

        Assert.Equal(expectedOutput, body);
    }

    [Fact]
    public void GivenABlockedIpAddress_WhenRequestIsMadeWithActionFilter_ThenResponseIsForbidden()
    {
        // Arrange
        const int expectedStatusCode = (int)HttpStatusCode.Forbidden;
        var ipAddress = IPAddress.Parse("127.0.0.1");

        _mockIpBlockingService.Setup(x => x.IsBlocked(ipAddress)).Returns(true);

        var httpContext = new DefaultHttpContext();
        httpContext.Connection.RemoteIpAddress = ipAddress;

        var actionExecutingContext = new ActionExecutingContext(
            new ActionContext(
                httpContext, new RouteData(), new ActionDescriptor()),
            new List<IFilterMetadata>(),
            new Dictionary<string, object>(),
            new object());

        var actionFilter = new IpBlockActionFilter(_mockIpBlockingService.Object);

        // Act
        actionFilter.OnActionExecuting(actionExecutingContext);

        var result = actionExecutingContext.Result as StatusCodeResult;

        // Assert
        Assert.Equal(expectedStatusCode, result.StatusCode);
    }

    [Fact]
    public void GivenAnUnblockedIpAddress_WhenRequestIsMadeWithActionFilter_ThenResultIsNull()
    {
        // Arrange
        const int expectedStatusCode = (int)HttpStatusCode.OK;
        var ipAddress = IPAddress.Parse("127.0.0.1");

        _mockIpBlockingService.Setup(x => x.IsBlocked(ipAddress)).Returns(false);

        var httpContext = new DefaultHttpContext();
        httpContext.Connection.RemoteIpAddress = ipAddress;

        var actionExecutingContext = new ActionExecutingContext(
            new ActionContext(
                httpContext, new RouteData(), new ActionDescriptor()),
            new List<IFilterMetadata>(),
            new Dictionary<string, object>(),
            new object());

        var actionFilter = new IpBlockActionFilter(_mockIpBlockingService.Object);

        // Act
        actionFilter.OnActionExecuting(actionExecutingContext);

        // Assert
        Assert.Null(actionExecutingContext.Result);
    }
}