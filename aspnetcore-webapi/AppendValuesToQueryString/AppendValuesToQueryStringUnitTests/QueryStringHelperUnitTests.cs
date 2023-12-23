using AppendValuesToQueryString;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppendValuesToQueryStringUnitTests
{
    [TestClass]
    public class QueryStringHelperUnitTests
    {
        private const string Url = "https://test.com/Books?author=rowling&language=english#section1";
        private const string BaseApiUrl = "https://test.com/Books";

        Dictionary<string, string> queryParams = new()
        {
            {"genre", "mystery" },
            {"author", "Orwell" }
        };

        [TestMethod]
        public void WhenModifyQueryStringUsingParseQueryStringMethod_ThenCorrectApiUrlIsBuilt()
        {
            //Arrange
            var expectedApiUrl = $"{BaseApiUrl}?author=Orwell&language=english&genre=mystery#section1";

            //Act
            var result = QueryStringHelper.CreateURLUsingParseQueryString(Url, queryParams);

            //Assert
            Assert.AreEqual(expectedApiUrl, result);
        }

        [TestMethod]
        public void WhenModifyQueryStringUsingParseQueryMethod_ThenCorrectApiUrlIsBuilt()
        {
            //Arrange
            var expectedApiUrl = $"{BaseApiUrl}?author=Orwell&language=english&genre=mystery#section1";

            //Act
            var result = QueryStringHelper.CreateURLUsingParseQuery(Url, queryParams);

            //Assert
            Assert.AreEqual(expectedApiUrl, result);
        }

        [TestMethod]
        public void WhenModifyQueryStringUsingAddQueryStringMethod_ThenCorrectApiUrlIsBuilt()
        {
            //Arrange
            var expectedApiUrl = $"{BaseApiUrl}?author=rowling&language=english&genre=fantasy#section1";

            //Act
            var result = QueryStringHelper.CreateURLUsingParseQuery(Url, new Dictionary<string, string> { { "genre", "fantasy" } });

            //Assert
            Assert.AreEqual(expectedApiUrl, result);
        }

        [TestMethod]
        public void WhenModifyQueryStringManually_ThenCorrectApiUrlIsBuilt()
        {
            //Arrange
            var expectedApiUrl = $"{BaseApiUrl}?author=Orwell&language=english&genre=mystery#section1";

            //Act
            var result = QueryStringHelper.CreateURL(Url, queryParams);

            //Assert
            Assert.AreEqual(expectedApiUrl, result);
        }
    }
}