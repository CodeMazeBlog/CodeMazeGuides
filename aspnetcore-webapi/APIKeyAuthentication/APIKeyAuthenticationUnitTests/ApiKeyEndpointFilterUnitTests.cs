using APIKeyAuthentication;
using APIKeyAuthentication.EndpointFilter;
using APIKeyAuthentication.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace APIKeyAuthenticationUnitTests
{
    [TestClass]
    public class ApiKeyEndpointFilterUnitTests
    {
        private ApiKeyEndpointFilter? _filter;
        private Mock<IApiKeyValidation>? _mockApiKeyValidator;
        private Mock<EndpointFilterInvocationContext>? _mockInvocationContext;
        private Mock<EndpointFilterDelegate>? _mockNextDelegate;

        [TestInitialize]
        public void Initialize()
        {
            _mockApiKeyValidator = new Mock<IApiKeyValidation>();
            _mockInvocationContext = new Mock<EndpointFilterInvocationContext>();
            _mockNextDelegate = new Mock<EndpointFilterDelegate>();
            _filter = new ApiKeyEndpointFilter(_mockApiKeyValidator.Object);
        }

        [TestMethod]
        public async Task GivenApiKeyHeaderIsMissing_WhenInvokeAsync_Then_ReturnsBadRequest()
        {
            //Arrange
            HeaderDictionary header = new HeaderDictionary();
            _mockInvocationContext!.Setup(x => x.HttpContext.Request.Headers).Returns(header);

            //Act
            var result = await _filter!.InvokeAsync(_mockInvocationContext.Object, _mockNextDelegate!.Object);

            //Assert
            Assert.IsInstanceOfType(result, typeof(BadRequest));
        }

        [TestMethod]
        public async Task GivenApiKeyIsInvalid_WhenInvokeAsync_ThenReturnsUnauthorized()
        {
            //Arrange
            var header = new HeaderDictionary
            {
                { Constants.ApiKeyHeaderName, TestConstants.InvalidValidApiKey }
            };
            _mockInvocationContext!.Setup(x => x.HttpContext.Request.Headers).Returns(header);
            _mockApiKeyValidator!.Setup(x => x.IsValidApiKey(TestConstants.InvalidValidApiKey)).Returns(false);

            //Act
            var result = await _filter!.InvokeAsync(_mockInvocationContext.Object, _mockNextDelegate!.Object);

            //Assert
            Assert.IsInstanceOfType(result, typeof(UnauthorizedHttpResult));
        }

        [TestMethod]
        public async Task GivenApiKeyIsValid_WhenInvokeAsync_ThenCallsNextDelegate()
        {
            //Arrange
            var header = new HeaderDictionary
            {
                { Constants.ApiKeyHeaderName, TestConstants.ValidApiKey }
            };
            _mockInvocationContext!.Setup(x => x.HttpContext.Request.Headers).Returns(header);
            _mockApiKeyValidator!.Setup(x => x.IsValidApiKey(TestConstants.ValidApiKey)).Returns(true);

            //Act
            var result = await _filter!.InvokeAsync(_mockInvocationContext.Object, _mockNextDelegate!.Object);

            //Assert
            Assert.IsNull(result);
        }
    }
}