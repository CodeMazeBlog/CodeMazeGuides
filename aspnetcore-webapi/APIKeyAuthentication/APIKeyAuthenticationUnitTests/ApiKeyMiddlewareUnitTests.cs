using APIKeyAuthentication;
using APIKeyAuthentication.CustomMiddleware;
using APIKeyAuthentication.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;

namespace APIKeyAuthenticationUnitTests
{
    [TestClass]
    public class ApiKeyMiddlewareUnitTests
    {
        [TestMethod]
        public async Task GivenValidApiKey_WhenInvokeAsync_ThenCallNextDelegate()
        {
            // Arrange
            var apiKeyValidation = new Mock<IApiKeyValidation>();
            apiKeyValidation.Setup(x => x.IsValidApiKey(TestConstants.ValidApiKey)).Returns(true);

            var context = new DefaultHttpContext();
            context.Request.Headers[Constants.ApiKeyHeaderName] = TestConstants.ValidApiKey;

            var nextDelegateCalled = false;

            RequestDelegate nextDelegate = (HttpContext httpContext) =>
            {
                nextDelegateCalled = true;
                return Task.CompletedTask;
            };

            var middleware = new ApiKeyMiddleware(nextDelegate, apiKeyValidation.Object);

            // Act
            await middleware.InvokeAsync(context);

            // Assert
            Assert.IsTrue(nextDelegateCalled);
            Assert.AreEqual((int)HttpStatusCode.OK, context.Response.StatusCode);
        }

        [TestMethod]
        public async Task GivenMissingApiKey_WhenInvokeAsync_ThenReturnBadRequest()
        {
            // Arrange
            var apiKeyValidation = new Mock<IApiKeyValidation>();

            var context = new DefaultHttpContext();

            var nextDelegateCalled = false;

            RequestDelegate nextDelegate = (HttpContext httpContext) =>
            {
                nextDelegateCalled = true;
                return Task.CompletedTask;
            };

            var middleware = new ApiKeyMiddleware(nextDelegate, apiKeyValidation.Object);

            // Act
            await middleware.InvokeAsync(context);

            // Assert
            Assert.IsFalse(nextDelegateCalled);
            Assert.AreEqual((int)HttpStatusCode.BadRequest, context.Response.StatusCode);
        }

        [TestMethod]
        public async Task GivenMissingApiKey_WhenInvokeAsync_ThenReturnUnauthorized()
        {
            // Arrange
            var apiKeyValidation = new Mock<IApiKeyValidation>();
            apiKeyValidation.Setup(x => x.IsValidApiKey(TestConstants.InvalidValidApiKey)).Returns(false);

            var context = new DefaultHttpContext();
            context.Request.Headers[Constants.ApiKeyHeaderName] = TestConstants.InvalidValidApiKey;

            var nextDelegateCalled = false;

            RequestDelegate nextDelegate = (HttpContext httpContext) =>
            {
                nextDelegateCalled = true;
                return Task.CompletedTask;
            };

            var middleware = new ApiKeyMiddleware(nextDelegate, apiKeyValidation.Object);

            // Act
            await middleware.InvokeAsync(context);

            // Assert
            Assert.IsFalse(nextDelegateCalled);
            Assert.AreEqual((int)HttpStatusCode.Unauthorized, context.Response.StatusCode);
        }
    }
}