using APIKeyAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APIKeyAuthenticationUnitTests
{
    [TestClass]
    public class ApiKeyValidationUnitTests
    {
        [TestMethod]
        public void GivenValidApiKey_WhenValidation_ThenReturnTrue()
        {
            // Arrange
            string validApiKey = TestConstants.ValidApiKey;

            var inMemorySettings = new Dictionary<string, string> {
                {TestConstants.ApiKeyName, validApiKey}
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings!)
                .Build();

            var apiKeyValidation = new ApiKeyValidation(configuration);

            // Act
            var result = apiKeyValidation.IsValidApiKey(validApiKey);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenNullApiKey_WhenValidation_ThenReturnFalse()
        {
            //Arrange
            var inMemorySettings = new Dictionary<string, string> {
                {TestConstants.ApiKeyName, TestConstants.ValidApiKey}
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings!)
                .Build();

            var apiKeyValidation = new ApiKeyValidation(configuration);

            // Act
            var result = apiKeyValidation.IsValidApiKey(null!);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenInvalidApiKey_WhenValidation_ThenReturnFalse()
        {
            // Arrange
            string invalidApiKey = TestConstants.InvalidValidApiKey;

            var inMemorySettings = new Dictionary<string, string> {
                {TestConstants.ApiKeyName, TestConstants.ValidApiKey}
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings!)
                .Build();

            var apiKeyValidation = new ApiKeyValidation(configuration);

            // Act
            var result = apiKeyValidation.IsValidApiKey(invalidApiKey);

            // Assert
            Assert.IsFalse(result);
        }
    }
}