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
            string result = QueryStringHelper.BuildUrlWithQueryStringUsingStringConcat(basePath, dict);

            //Assert
            Assert.AreEqual(expectedApiUrl, result);
        }

        [TestMethod]
        public void GivenBasePathAndQueryParams_WhenBuildUrlWithQueryStringUsingUriBuilder_ThenCorrectApiUrlIsBuilt()
        {
            // Arrange
            string author = "Jane Austen";
            string language = "english";
            var dict = new Dictionary<string, string>
            {
                { "author", author },
                { "language", language }
            };
            string expectedApiUrl = $"https://localhost:7220/api/Books?author=Jane%20Austen&language={language}";

            // Act
            string result = QueryStringHelper.BuildUrlWithQueryStringUsingUriBuilder(basePath, dict);

            //Assert
            Assert.AreEqual(expectedApiUrl, result);
        }

        [TestMethod]
        public void GivenBasePathAndQueryParams_WhenBuildUrlWithQueryStringUsingParseQueryStringMethod_ThenCorrectApiUrlIsBuilt()
        {
            // Arrange
            string author = "Agatha Christie";
            string language = "english";
            var dict = new Dictionary<string, string>
            {
                { "author", author },
                { "language", language }
            };
            string expectedApiUrl = $"https://localhost:7220/api/Books?author=Agatha+Christie&language={language}";

            // Act
            string result = QueryStringHelper.BuildUrlWithQueryStringUsingParseQueryStringMethod(basePath, dict);

            //Assert
            Assert.AreEqual(expectedApiUrl, result);
        }

        [TestMethod]
        public void GivenBasePathAndQueryParams_WhenBuildUrlWithQueryStringUsingAddQueryStringMethod_ThenCorrectApiUrlIsBuilt()
        {
            // Arrange
            string author = "Haruki Murakami";
            string language = "japanese";
            var dict = new Dictionary<string, string>
            {
                { "author", author },
                { "language", language }
            };
            string expectedApiUrl = $"https://localhost:7220/api/Books?author=Haruki%20Murakami&language={language}";

            // Act
            string result = QueryStringHelper.BuildUrlWithQueryStringUsingAddQueryStringMethod(basePath, dict);

            //Assert
            Assert.AreEqual(expectedApiUrl, result);
        }

        [TestMethod]
        public void GivenBasePathAndQueryParams_WhenBuildUrlWithQueryStringUsingQueryBuilderClass_ThenCorrectApiUrlIsBuilt()
        {
            // Arrange
            string author = "Gabriel Garcia";
            string language = "spanish";
            var dict = new Dictionary<string, string>
            {
                { "author", author },
                { "language", language }
            };
            string expectedApiUrl = "https://localhost:7220/api/Books?author=Gabriel%20Garcia&language=spanish";

            // Act
            string result = QueryStringHelper.BuildUrlWithQueryStringUsingQueryBuilderClass(basePath, dict);

            //Assert
            Assert.AreEqual(expectedApiUrl, result);
        }

        [TestMethod]
        public void GivenBasePathAndQueryParams_WhenBuildurlWithQueryStringUsingCreateMethod_ThenCorrectApiUrlIsBuilt()
        {
            // Arrange
            string author = "Leo Tolstoy";
            string language = "russian";
            var dict = new Dictionary<string, string>
            {
                { "author", author },
                { "language", language }
            };
            string expectedApiUrl = $"https://localhost:7220/api/Books?author=Leo%20Tolstoy&language={language}";

            // Act
            string result = QueryStringHelper.BuildUrlWithQueryStringUsingCreateMethod(basePath, dict);

            //Assert
            Assert.AreEqual(expectedApiUrl, result);
        }
    }
}