using BuildQueryString;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuildQueryStringTests
{
    [TestClass]
    public class QueryStringHelperUnitTests
    {
        const string basePath = $"https://localhost:7220/api/Books";

        [TestMethod]
        public void GivenBasePathAndQueryParams_WhenBuildUrlWithQueryStringUsingStringConcat_ThenCorrectApiUrlIsBuilt()
        {
            // Arrange
            var author = "George Orwell";
            var language = "english";
            var dict = new Dictionary<string, string>
            {
                { "author", author },
                { "language", language }
            };
            var expectedApiUrl = $"https://localhost:7220/api/Books?author=George+Orwell&language={language}";

            // Act
            var result = QueryStringHelper.BuildUrlWithQueryStringUsingStringConcat(basePath, dict);

            //Assert
            Assert.AreEqual(expectedApiUrl, result);
        }

        [TestMethod]
        public void GivenBasePathAndQueryParams_WhenBuildUrlWithQueryStringUsingUriBuilder_ThenCorrectApiUrlIsBuilt()
        {
            // Arrange
            var author = "Jane Austen";
            var language = "english";
            var dict = new Dictionary<string, string>
            {
                { "author", author },
                { "language", language }
            };
            var expectedApiUrl = $"https://localhost:7220/api/Books?author=Jane%20Austen&language={language}";

            // Act
            var result = QueryStringHelper.BuildUrlWithQueryStringUsingUriBuilder(basePath, dict);

            //Assert
            Assert.AreEqual(expectedApiUrl, result);
        }

        [TestMethod]
        public void GivenBasePathAndQueryParams_WhenBuildUrlWithQueryStringUsingParseQueryStringMethod_ThenCorrectApiUrlIsBuilt()
        {
            // Arrange
            var author = "Agatha Christie";
            var language = "english";
            var dict = new Dictionary<string, string>
            {
                { "author", author },
                { "language", language }
            };
            var expectedApiUrl = $"https://localhost:7220/api/Books?author=Agatha+Christie&language={language}";

            // Act
            var result = QueryStringHelper.BuildUrlWithQueryStringUsingParseQueryStringMethod(basePath, dict);

            //Assert
            Assert.AreEqual(expectedApiUrl, result);
        }

        [TestMethod]
        public void GivenBasePathAndQueryParams_WhenBuildUrlWithQueryStringUsingAddQueryStringMethod_ThenCorrectApiUrlIsBuilt()
        {
            // Arrange
            var author = "Haruki Murakami";
            var language = "japanese";
            var dict = new Dictionary<string, string>
            {
                { "author", author },
                { "language", language }
            };
            var expectedApiUrl = $"https://localhost:7220/api/Books?author=Haruki%20Murakami&language={language}";

            // Act
            var result = QueryStringHelper.BuildUrlWithQueryStringUsingAddQueryStringMethod(basePath, dict);

            //Assert
            Assert.AreEqual(expectedApiUrl, result);
        }

        [TestMethod]
        public void GivenBasePathAndQueryParams_WhenBuildUrlWithQueryStringUsingQueryBuilderClass_ThenCorrectApiUrlIsBuilt()
        {
            // Arrange
            var author = "Gabriel Garcia";
            var language = "spanish";
            var dict = new Dictionary<string, string>
            {
                { "author", author },
                { "language", language }
            };
            var expectedApiUrl = "https://localhost:7220/api/Books?author=Gabriel%20Garcia&language=spanish";

            // Act
            var result = QueryStringHelper.BuildUrlWithQueryStringUsingQueryBuilderClass(basePath, dict);

            //Assert
            Assert.AreEqual(expectedApiUrl, result);
        }

        [TestMethod]
        public void GivenBasePathAndQueryParams_WhenBuildurlWithQueryStringUsingCreateMethod_ThenCorrectApiUrlIsBuilt()
        {
            // Arrange
            var author = "Leo Tolstoy";
            var language = "russian";
            var dict = new Dictionary<string, string>
            {
                { "author", author },
                { "language", language }
            };
            var expectedApiUrl = $"https://localhost:7220/api/Books?author=Leo%20Tolstoy&language={language}";

            // Act
            var result = QueryStringHelper.BuildUrlWithQueryStringUsingCreateMethod(basePath, dict);

            //Assert
            Assert.AreEqual(expectedApiUrl, result);
        }
    }
}