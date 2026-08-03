using HttpClientCookies.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Tests;

public class CookieTests
{

    [Fact]
    public void WhenGetCookie_ThenReturnOkResultAndSetsCookie()
    {
        // Arrange
        var controller = new CookieController();
        var httpContextMock = new Mock<HttpContext>();
        var responseMock = new Mock<HttpResponse>();

        // Configure response mock
        var mockResponseCookies = new MockResponseCookies();
        responseMock.Setup(r => r.Cookies).Returns(mockResponseCookies);
        httpContextMock.Setup(c => c.Response).Returns(responseMock.Object);

        controller.ControllerContext = new ControllerContext
        {
            HttpContext = httpContextMock.Object
        };

        // Act
        var result = controller.GetCookie() as OkResult;

        // Assert
        Assert.NotNull(result);

        // Check if the cookie has been added
        var receivedCookie = mockResponseCookies.TryGetValue("SimpleCookie", out string value) ? value : null;

        Assert.Equal("RHsMeXPsMK", receivedCookie);
    }

    // Mock implementation of ResponseCookies for testing
    class MockResponseCookies : IResponseCookies
    {
        private Dictionary<string, string> _cookies = new Dictionary<string, string>();

        public void Append(string key, string value, CookieOptions options)
        {
            // Store the cookie in a dictionary for retrieval later
            _cookies[key] = value;
        }

        public void Append(string key, string value)
        {
            throw new NotImplementedException();
        }

        public void Delete(string key)
        {
            throw new NotImplementedException();
        }

        public void Delete(string key, CookieOptions options)
        {
            throw new NotImplementedException();
        }
        public bool TryGetValue(string key, out string value)
        {
            return _cookies.TryGetValue(key, out value);
        }
    }

}
