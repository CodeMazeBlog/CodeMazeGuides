using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using RemoteHostIpAddress.Controllers;
using System.Net;
using Xunit;

namespace RemoteHostIpAddressTests
{
    public class RemoteHostIpAddressTests
    {
        private readonly WeatherForecastController _controller;

        public RemoteHostIpAddressTests()
        {
            _controller = new WeatherForecastController(new NullLogger<WeatherForecastController>());
        }

        [Fact]
        public void WhenGetRemoteHostIpAddressUsingRemoteIpAddress_ThenReturnsValidIpAddress()
        {
            // Arrange
            var connection = new Mock<ConnectionInfo>();
            connection.SetupGet(c => c.RemoteIpAddress).Returns(IPAddress.Parse("192.168.1.1"));

            var httpContext = new Mock<HttpContext>();
            httpContext.SetupGet(h => h.Connection).Returns(connection.Object);

            _controller.ControllerContext.HttpContext = httpContext.Object;

            // Act
            var result = _controller.GetRemoteHostIpAddressUsingRemoteIpAddress();

            // Assert
            Assert.Equal(IPAddress.Parse("192.168.1.1"), result);
        }

        [Fact]
        public void WhenGetRemoteHostIpAddressUsingXForwardedFor_ThenReturnsValidIpAddress()
        {
            // Arrange
            var headerDictionary = new HeaderDictionary
            {
                { "X-Forwarded-For", "192.168.1.1" }
            };

            var httpContext = new Mock<HttpContext>();
            httpContext.SetupGet(h => h.Request.Headers).Returns(headerDictionary);

            _controller.ControllerContext.HttpContext = httpContext.Object;

            // Act
            var result = _controller.GetRemoteHostIpAddressUsingXForwardedFor();

            // Assert
            Assert.Equal(IPAddress.Parse("192.168.1.1"), result);
        }

        [Fact]
        public void WhenGetRemoteHostIpAddressUsingXForwardedFor_WithInvalidIp_ThenReturnsNull()
        {
            // Arrange
            var headerDictionary = new HeaderDictionary
            {
                { "X-Forwarded-For", "invalid ip" }
            };

            var httpContext = new Mock<HttpContext>();
            httpContext.SetupGet(h => h.Request.Headers).Returns(headerDictionary);

            _controller.ControllerContext.HttpContext = httpContext.Object;

            // Act
            var result = _controller.GetRemoteHostIpAddressUsingXForwardedFor();

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void WhenGetRemoteHostIpAddressUsingXRealIp_WithInvalidIp_ThenReturnsValidIpAddress()
        {
            // Arrange
            var headerDictionary = new HeaderDictionary
            {
                { "X-Real-IP", "192.168.1.1" }
            };

            var httpContext = new Mock<HttpContext>();
            httpContext.SetupGet(h => h.Request.Headers).Returns(headerDictionary);

            _controller.ControllerContext.HttpContext = httpContext.Object;

            // Act
            var result = _controller.GetRemoteHostIpAddressUsingXRealIp();

            // Assert
            Assert.Equal(IPAddress.Parse("192.168.1.1"), result);
        }

        [Fact]
        public void WhenGetRemoteHostIpAddressUsingXRealIp_WithInvalidIp_ThenReturnsNull()
        {
            // Arrange
            var headerDictionary = new HeaderDictionary
            {
                { "X-Real-IP", "invalid ip" }
            };

            var httpContext = new Mock<HttpContext>();
            httpContext.SetupGet(h => h.Request.Headers).Returns(headerDictionary);

            _controller.ControllerContext.HttpContext = httpContext.Object;

            // Act
            var result = _controller.GetRemoteHostIpAddressUsingXRealIp();

            // Assert
            Assert.Null(result);
        }
    }
}