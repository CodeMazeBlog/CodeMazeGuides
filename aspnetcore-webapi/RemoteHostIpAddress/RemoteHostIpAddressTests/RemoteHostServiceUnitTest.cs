using Microsoft.AspNetCore.Http;
using Moq;
using RemoteHostIpAddress;
using System.Net;
using Xunit;

namespace RemoteHostIpAddressTests
{
    public class RemoteHostServiceUnitTest
    {
        private readonly IRemoteHostService _service;
        public RemoteHostServiceUnitTest()
        {
            _service = new RemoteHostService();
        }

        [Fact]
        public void WhenGetRemoteHostIpAddressWithValidRemoteIpAddress_ThenReturnsValidIpAddress()
        {
            // Arrange
            var connection = new Mock<ConnectionInfo>();
            connection.SetupGet(c => c.RemoteIpAddress).Returns(IPAddress.Parse("192.168.1.1"));

            var httpContext = new Mock<HttpContext>();
            httpContext.SetupGet(h => h.Connection).Returns(connection.Object);

            // Act
            var result = _service.GetRemoteHostIpAddressUsingRemoteIpAddress(httpContext.Object);

            // Assert
            Assert.Equal(IPAddress.Parse("192.168.1.1"), result);
        }

        [Fact]
        public void WhenGetRemoteHostIpAddressUsingXForwardedForWithValidRemoteIpAddress_ThenReturnsValidIpAddress()
        {
            // Arrange
            var headerDictionary = new HeaderDictionary
            {
                { "X-Forwarded-For", "192.168.1.1" }
            };

            var httpContext = new Mock<HttpContext>();
            httpContext.SetupGet(h => h.Request.Headers).Returns(headerDictionary);

            // Act
            var result = _service.GetRemoteHostIpAddressUsingXForwardedFor(httpContext.Object);

            // Assert
            Assert.Equal(IPAddress.Parse("192.168.1.1"), result);
        }

        [Fact]
        public void WhenGetRemoteHostIpAddressUsingXForwardedForWithInvalidIp_ThenReturnsNull()
        {
            // Arrange
            var headerDictionary = new HeaderDictionary
            {
                { "X-Forwarded-For", "invalid ip" }
            };

            var httpContext = new Mock<HttpContext>();
            httpContext.SetupGet(h => h.Request.Headers).Returns(headerDictionary);

            // Act
            var result = _service.GetRemoteHostIpAddressUsingXForwardedFor(httpContext.Object);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void WhenGetRemoteHostIpAddressUsingXRealIp_ThenReturnsValidIpAddress()
        {
            // Arrange
            var headerDictionary = new HeaderDictionary
            {
                { "X-Real-IP", "192.168.1.1" }
            };

            var httpContext = new Mock<HttpContext>();
            httpContext.SetupGet(h => h.Request.Headers).Returns(headerDictionary);

            // Act
            var result = _service.GetRemoteHostIpAddressUsingXRealIp(httpContext.Object);

            // Assert
            Assert.Equal(IPAddress.Parse("192.168.1.1"), result);
        }

        [Fact]
        public void WhenGetRemoteHostIpAddressUsingXRealIpWithInvalidIp_ThenReturnsNull()
        {
            // Arrange
            var headerDictionary = new HeaderDictionary
            {
                { "X-Real-IP", "invalid ip" }
            };

            var httpContext = new Mock<HttpContext>();
            httpContext.SetupGet(h => h.Request.Headers).Returns(headerDictionary);

            // Act
            var result = _service.GetRemoteHostIpAddressUsingXRealIp(httpContext.Object);

            // Assert
            Assert.Null(result);
        }
    }
}