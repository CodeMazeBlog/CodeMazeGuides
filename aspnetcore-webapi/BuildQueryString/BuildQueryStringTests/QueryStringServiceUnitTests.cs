using BuildQueryString;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;

namespace BuildQueryStringTests
{
    [TestClass]
    public class QueryStringServiceUnitTests
    {
        [TestMethod]
        public async Task GivenAuthorAndLanguage_WhenBuildQueryStringUsingStringConcat_ThenCorrectApiUrlIsBuilt()
        {
            // Arrange
            string author = "rowling";
            string language = "english";
            string expectedApiUrl = $"https://localhost:7220/api/Books?author={author}&language={language}";

            var httpClientWrapperMock = new Mock<IHttpClientWrapper>();

            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(expectedApiUrl)
            };

            httpClientWrapperMock
                .Setup(client => client.GetAsync(expectedApiUrl))
                .ReturnsAsync(httpResponseMessage);

            QueryStringService booksService = new QueryStringService(httpClientWrapperMock.Object);

            // Act
            string result = await booksService.BuildQueryStringUsingStringConcat(author, language);

            //Assert
            Assert.AreEqual(expectedApiUrl, result);
            httpClientWrapperMock.Verify(client => client.GetAsync(expectedApiUrl), Times.Once);
        }

        [TestMethod]
        public async Task GivenAuthorAndLanguage_WhenBuildQueryStringUsingEncoding_ThenCorrectApiUrlIsBuilt()
        {
            // Arrange
            string author = "George Orwell";
            string language = "english";
            string expectedApiUrl = $"https://localhost:7220/api/Books?author=George+Orwell&language=english";

            var httpClientWrapperMock = new Mock<IHttpClientWrapper>();

            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(expectedApiUrl)
            };

            httpClientWrapperMock
                .Setup(client => client.GetAsync(expectedApiUrl))
                .ReturnsAsync(httpResponseMessage);

            QueryStringService booksService = new QueryStringService(httpClientWrapperMock.Object);

            // Act
            string result = await booksService.BuildQueryStringByEncoding(author, language);

            //Assert
            Assert.AreEqual(expectedApiUrl, result);
            httpClientWrapperMock.Verify(client => client.GetAsync(expectedApiUrl), Times.Once);
        }

        [TestMethod]
        public async Task GivenAuthorAndLanguage_WhenBuildQueryStringUsingUriBuilder_ThenCorrectApiUrlIsBuilt()
        {
            // Arrange
            string author = "Jane Austen";
            string language = "english";
            string expectedApiUrl = "https://localhost:7220/api/Books?author=Jane Austen&language=english";

            var httpClientWrapperMock = new Mock<IHttpClientWrapper>();

            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(expectedApiUrl)
            };

            httpClientWrapperMock
                .Setup(client => client.GetAsync(expectedApiUrl))
                .ReturnsAsync(httpResponseMessage);

            QueryStringService booksService = new QueryStringService(httpClientWrapperMock.Object);

            // Act
            string result = await booksService.BuildQueryStringUsingUriBuilder(author, language);

            //Assert
            Assert.AreEqual(expectedApiUrl, result);
            httpClientWrapperMock.Verify(client => client.GetAsync(expectedApiUrl), Times.Once);
        }

        [TestMethod]
        public async Task GivenAuthorAndLanguage_WhenBuildQueryStringUsingParseQueryStringMethod_ThenCorrectApiUrlIsBuilt()
        {
            // Arrange
            string author = "Agatha Christie";
            string language = "english";
            string expectedApiUrl = "https://localhost:7220/api/Books?author=Agatha+Christie&language=english";

            var httpClientWrapperMock = new Mock<IHttpClientWrapper>();

            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(expectedApiUrl)
            };

            httpClientWrapperMock
                .Setup(client => client.GetAsync(expectedApiUrl))
                .ReturnsAsync(httpResponseMessage);

            QueryStringService booksService = new QueryStringService(httpClientWrapperMock.Object);

            // Act
            string result = await booksService.BuildQueryStringUsingParseQueryStringMethod(author, language);

            //Assert
            Assert.AreEqual(expectedApiUrl, result);
            httpClientWrapperMock.Verify(client => client.GetAsync(expectedApiUrl), Times.Once);
        }

        [TestMethod]
        public async Task GivenAuthorAndLanguage_WhenBuildQueryStringUsingAddQueryStringMethod_ThenCorrectApiUrlIsBuilt()
        {
            // Arrange
            string author = "Haruki Murakami";
            string language = "japanese";
            string expectedApiUrl = "https://localhost:7220/api/Books?author=Haruki+Murakami&language=japanese";

            var httpClientWrapperMock = new Mock<IHttpClientWrapper>();

            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(expectedApiUrl)
            };

            httpClientWrapperMock
                .Setup(client => client.GetAsync(expectedApiUrl))
                .ReturnsAsync(httpResponseMessage);

            QueryStringService booksService = new QueryStringService(httpClientWrapperMock.Object);

            // Act
            string result = await booksService.BuildQueryStringUsingParseQueryStringMethod(author, language);

            //Assert
            Assert.AreEqual(expectedApiUrl, result);
            httpClientWrapperMock.Verify(client => client.GetAsync(expectedApiUrl), Times.Once);
        }

        [TestMethod]
        public async Task GivenAuthorAndLanguage_WhenBuildQueryStringUsingQueryBuilderClass_ThenCorrectApiUrlIsBuilt()
        {
            // Arrange
            string author = "Gabriel Garcia";
            string language = "spanish";
            string expectedApiUrl = "https://localhost:7220/api/Books?author=Gabriel+Garcia&language=spanish";

            var httpClientWrapperMock = new Mock<IHttpClientWrapper>();

            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(expectedApiUrl)
            };

            httpClientWrapperMock
                .Setup(client => client.GetAsync(expectedApiUrl))
                .ReturnsAsync(httpResponseMessage);

            QueryStringService booksService = new QueryStringService(httpClientWrapperMock.Object);

            // Act
            string result = await booksService.BuildQueryStringUsingParseQueryStringMethod(author, language);

            //Assert
            Assert.AreEqual(expectedApiUrl, result);
            httpClientWrapperMock.Verify(client => client.GetAsync(expectedApiUrl), Times.Once);
        }

        [TestMethod]
        public async Task GivenAuthorAndLanguage_WhenBuildQueryStringUsingCreateMethod_ThenCorrectApiUrlIsBuilt()
        {
            // Arrange
            string author = "Leo Tolstoy";
            string language = "russian";
            string expectedApiUrl = "https://localhost:7220/api/Books?author=Leo+Tolstoy&language=russian";

            var httpClientWrapperMock = new Mock<IHttpClientWrapper>();

            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(expectedApiUrl)
            };

            httpClientWrapperMock
                .Setup(client => client.GetAsync(expectedApiUrl))
                .ReturnsAsync(httpResponseMessage);

            QueryStringService booksService = new QueryStringService(httpClientWrapperMock.Object);

            // Act
            string result = await booksService.BuildQueryStringUsingParseQueryStringMethod(author, language);

            //Assert
            Assert.AreEqual(expectedApiUrl, result);
            httpClientWrapperMock.Verify(client => client.GetAsync(expectedApiUrl), Times.Once);
        }
    }
}