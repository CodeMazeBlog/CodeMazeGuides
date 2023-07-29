using APIKeyAuthentication;
using APIKeyAuthentication.Controllers;
using APIKeyAuthentication.Interface;
using APIKeyAuthentication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace APIKeyAuthenticationUnitTests
{
    [TestClass]
    public class WeatherForecastControllerUnitTests
    {
        private Mock<IApiKeyValidation>? _apiKeyValidationMock;

        private WeatherForecastController? _controller;

        [TestInitialize]
        public void Initialize()
        {
            _apiKeyValidationMock = new Mock<IApiKeyValidation>();
            _controller = new WeatherForecastController(_apiKeyValidationMock.Object);
        }

        [TestMethod]
        public void WhenPassingValidApiKeyViaQueryParams_ThenReturnOkResult()
        {
            // Arrange
            string validApiKey = TestConstants.ValidApiKey;

            _apiKeyValidationMock!.Setup(x => x.IsValidApiKey(validApiKey)).Returns(true);

            // Act
            IActionResult result = _controller!.AuthenticateViaQueryParam(validApiKey);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void WhenPassingInavlidValidApiKeyViaQueryParams_ThenReturnUnauthorizedResult()
        {
            // Arrange
            string invalidApiKey = TestConstants.InvalidValidApiKey;

            _apiKeyValidationMock!.Setup(x => x.IsValidApiKey(invalidApiKey)).Returns(false);

            // Act
            IActionResult result = _controller!.AuthenticateViaQueryParam(invalidApiKey);

            // Assert
            Assert.IsInstanceOfType(result, typeof(UnauthorizedResult));
        }

        [TestMethod]
        public void WhenPassingEmptyApiKeyViaQueryParams_ThenReturnOkResult()
        {
            // Arrange
            string invalidApiKey = string.Empty;

            _apiKeyValidationMock!.Setup(x => x.IsValidApiKey(invalidApiKey)).Returns(false);

            // Act
            IActionResult result = _controller!.AuthenticateViaQueryParam(invalidApiKey);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void WhenPassingValidApiKeyViaRequestBody_ThenReturnOkResult()
        {
            // Arrange
            RequestModel requestModel = new RequestModel
            {
                ApiKey = TestConstants.ValidApiKey
            };

            string validApiKey = TestConstants.ValidApiKey;

            _apiKeyValidationMock!.Setup(x => x.IsValidApiKey(validApiKey)).Returns(true);

            // Act
            IActionResult result = _controller!.AuthenticateViaBody(requestModel);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void WhenPassingInavlidValidApiKeyViaRequestBody_ThenReturnUnauthorizedResult()
        {
            // Arrange
            RequestModel requestModel = new RequestModel
            {
                ApiKey = TestConstants.InvalidValidApiKey
            };

            string validApiKey = TestConstants.ValidApiKey;

            _apiKeyValidationMock!.Setup(x => x.IsValidApiKey(validApiKey)).Returns(true);

            // Act
            IActionResult result = _controller!.AuthenticateViaBody(requestModel);

            // Assert
            Assert.IsInstanceOfType(result, typeof(UnauthorizedResult));
        }

        [TestMethod]
        public void WhenPassingEmptyApiKeyViaRequestBody_ThenReturnBadRequestResult()
        {
            // Arrange
            RequestModel requestModel = new RequestModel();

            string validApiKey = TestConstants.ValidApiKey;

            _apiKeyValidationMock!.Setup(x => x.IsValidApiKey(validApiKey)).Returns(true);

            // Act
            IActionResult result = _controller!.AuthenticateViaBody(requestModel);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void WhenPassingEmptyApiKeyViaHeader_ThenReturnOkResult()
        {
            // Arrange
            string validApiKey = TestConstants.ValidApiKey;

            _apiKeyValidationMock!.Setup(x => x.IsValidApiKey(validApiKey)).Returns(true);

            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers[Constants.ApiKeyHeaderName] = validApiKey;

            _controller!.ControllerContext = new ControllerContext
            {
                HttpContext = httpContext
            };

            // Act
            IActionResult result = _controller.AuthenticateViaHeader();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void WhenPassingEmptyApiKeyViaHeader_ThenReturnUnauthorizedResult()
        {
            // Arrange
            string invalidApiKey = TestConstants.InvalidValidApiKey;

            _apiKeyValidationMock!.Setup(x => x.IsValidApiKey(invalidApiKey)).Returns(false);

            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers[Constants.ApiKeyHeaderName] = invalidApiKey;

            _controller!.ControllerContext = new ControllerContext
            {
                HttpContext = httpContext
            };

            // Act
            IActionResult result = _controller.AuthenticateViaHeader();

            // Assert
            Assert.IsInstanceOfType(result, typeof(UnauthorizedResult));
        }

        [TestMethod]
        public void WhenPassingEmptyApiKeyViaHeader_ThenReturnBadRequestResult()
        {
            // Arrange
            string invalidApiKey = string.Empty;

            _apiKeyValidationMock!.Setup(x => x.IsValidApiKey(invalidApiKey)).Returns(false);

            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers[Constants.ApiKeyHeaderName] = invalidApiKey;

            _controller!.ControllerContext = new ControllerContext
            {
                HttpContext = httpContext
            };

            // Act
            IActionResult result = _controller.AuthenticateViaHeader();

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }
    }
}