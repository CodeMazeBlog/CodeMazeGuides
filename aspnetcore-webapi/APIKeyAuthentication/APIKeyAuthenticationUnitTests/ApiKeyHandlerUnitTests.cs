using APIKeyAuthentication;
using APIKeyAuthentication.Interface;
using APIKeyAuthentication.PolicyBased;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace APIKeyAuthenticationUnitTests
{
    [TestClass]
    public class ApiKeyHandlerUnitTests
    {
        [TestMethod]
        public async Task GivenValidApiKey_WhenHandleRequirementAsync_ThenReturnSucceeds()
        {
            // Arrange
            var context = new DefaultHttpContext();
            context.Request.Headers[Constants.ApiKeyHeaderName] = TestConstants.ValidApiKey;

            var httpContextAccessor = new HttpContextAccessor { HttpContext = context };
            var apiKeyValidation = new Mock<IApiKeyValidation>();
            apiKeyValidation.Setup(x => x.IsValidApiKey(TestConstants.ValidApiKey)).Returns(true);

            var requirement = new ApiKeyRequirement();
            var handler = new ApiKeyHandler(httpContextAccessor, apiKeyValidation.Object);
            var authContext = new AuthorizationHandlerContext(new[] { requirement }, null!, requirement);

            // Act
            await handler.HandleAsync(authContext);

            // Assert
            Assert.IsTrue(authContext.HasSucceeded);
        }

        [TestMethod]
        public async Task GivenInvalidValidApiKey_WhenHandleRequirementAsync_ThenReturnFailed()
        {
            // Arrange
            var context = new DefaultHttpContext();
            context.Request.Headers[Constants.ApiKeyHeaderName] = TestConstants.InvalidValidApiKey;

            var httpContextAccessor = new HttpContextAccessor { HttpContext = context };
            var apiKeyValidation = new Mock<IApiKeyValidation>();
            apiKeyValidation.Setup(x => x.IsValidApiKey(TestConstants.InvalidValidApiKey)).Returns(false);

            var requirement = new ApiKeyRequirement();
            var handler = new ApiKeyHandler(httpContextAccessor, apiKeyValidation.Object);
            var authContext = new AuthorizationHandlerContext(new[] { requirement }, null!, requirement);

            // Act
            await handler.HandleAsync(authContext);

            // Assert
            Assert.IsFalse(authContext.HasSucceeded);
        }
    }
}