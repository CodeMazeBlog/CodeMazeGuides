using APIKeyAuthentication;
using APIKeyAuthentication.CustomAttribute;
using APIKeyAuthentication.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace APIKeyAuthenticationUnitTests
{
    [TestClass]
    public class ApiKeyAuthFilterUnitTests
    {
        [TestMethod]
        public void GivenValidApiKey_WhenAuthorization_ThenNotSetContextResult()
        {
            // Arrange
            var apiKeyValidation = new Mock<IApiKeyValidation>();

            apiKeyValidation.Setup(x => x.IsValidApiKey(TestConstants.ValidApiKey)).Returns(true);

            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers[Constants.ApiKeyHeaderName] = TestConstants.ValidApiKey;

            var controllerContext = new ControllerContext()
            {
                HttpContext = httpContext,
                RouteData = new RouteData(),
                ActionDescriptor = new Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor()
            };

            var filterContext = new AuthorizationFilterContext(controllerContext, new IFilterMetadata[] { });

            var filter = new ApiKeyAuthFilter(apiKeyValidation.Object);

            // Act
            filter.OnAuthorization(filterContext);

            // Assert
            Assert.IsNull(filterContext.Result);
        }

        [TestMethod]
        public void GivenMissingApiKey_WhenAuthorization_ThenSetBadRequestResult()
        {
            // Arrange
            var apiKeyValidation = new Mock<IApiKeyValidation>();

            var httpContext = new DefaultHttpContext();

            var controllerContext = new ControllerContext()
            {
                HttpContext = httpContext,
                RouteData = new RouteData(),
                ActionDescriptor = new Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor()
            };

            var filterContext = new AuthorizationFilterContext(controllerContext, new IFilterMetadata[] { });

            var filter = new ApiKeyAuthFilter(apiKeyValidation.Object);

            // Act
            filter.OnAuthorization(filterContext);

            // Assert
            Assert.IsInstanceOfType(filterContext.Result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void GivenInvalidApiKey_WhenAuthorization_ThenSetUnauthorizedResult()
        {
            // Arrange
            var apiKeyValidation = new Mock<IApiKeyValidation>();
            apiKeyValidation.Setup(x => x.IsValidApiKey(TestConstants.InvalidValidApiKey)).Returns(false);

            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers[Constants.ApiKeyHeaderName] = TestConstants.InvalidValidApiKey;

            var controllerContext = new ControllerContext()
            {
                HttpContext = httpContext,
                RouteData = new RouteData(),
                ActionDescriptor = new Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor()
            };

            var filterContext = new AuthorizationFilterContext(controllerContext, new IFilterMetadata[] { });

            var filter = new ApiKeyAuthFilter(apiKeyValidation.Object);

            // Act
            filter.OnAuthorization(filterContext);

            // Assert
            Assert.IsInstanceOfType(filterContext.Result, typeof(UnauthorizedResult));
        }
    }
}