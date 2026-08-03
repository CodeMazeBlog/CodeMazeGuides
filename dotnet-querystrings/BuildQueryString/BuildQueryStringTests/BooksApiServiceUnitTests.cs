using BuildQueryString;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;

namespace BuildQueryStringUnitTests
{
    [TestClass]
    public class BooksApiServiceUnitTests
    {
        [TestMethod]
        public async Task GivenApiUrl_WhenHttpGetAsync_ThenReturnResponse()
        {
            // Arrange
            var author = "rowling";
            var language = "english";
            var basepath = $"https://localhost:7220/api/Books?author={author}&language={language}";
            var expectedBooksDetails = $"Author: {author}, Language:{language}";

            var httpClientWrapperMock = new Mock<IHttpClientWrapper>();

            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(expectedBooksDetails)
            };

            httpClientWrapperMock
                .Setup(client => client.GetAsync(basepath))
                .ReturnsAsync(httpResponseMessage);

            var booksService = new BooksApiService(httpClientWrapperMock.Object);

            // Act
            var result = await booksService.HttpGetAsync(basepath);

            //Assert
            Assert.AreEqual(expectedBooksDetails, result);
            httpClientWrapperMock.Verify(client => client.GetAsync(basepath), Times.Once);
        }

        [TestMethod]
        public async Task GivenAuthorAndLanguage_WhenGetWithQueryParamsUsingStringConcat_ThenReturnBookDetails()
        {
            // Arrange
            var author = "rowling";
            var language = "english";
            var basepath = $"https://localhost:7220/api/Books?author={author}&language={language}";
            var expectedBooksDetails = $"Author: {author}, Language:{language}";

            var httpClientWrapperMock = new Mock<IHttpClientWrapper>();

            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(expectedBooksDetails)
            };

            httpClientWrapperMock
                .Setup(client => client.GetAsync(basepath))
                .ReturnsAsync(httpResponseMessage);

            var booksService = new BooksApiService(httpClientWrapperMock.Object);

            // Act
            var result = await booksService.GetWithQueryParamsUsingStringConcatenation(author, language);

            //Assert
            Assert.AreEqual(expectedBooksDetails, result);
            httpClientWrapperMock.Verify(client => client.GetAsync(basepath), Times.Once);
        }

        [TestMethod]
        public async Task GivenAuthorAndLanguage_WhenGetWithQueryParamsUsingUriBuilder_ThenReturnBookDetails()
        {
            // Arrange
            var author = "Jane Austen";
            var language = "english";
            var basepath = $"https://localhost:7220/api/Books?author=Jane%20Austen&language={language}";
            var expectedBooksDetails = $"Author: {author}, Language:{language}";

            var httpClientWrapperMock = new Mock<IHttpClientWrapper>();

            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(expectedBooksDetails)
            };

            httpClientWrapperMock
                .Setup(client => client.GetAsync(basepath))
                .ReturnsAsync(httpResponseMessage);

            var booksService = new BooksApiService(httpClientWrapperMock.Object);

            // Act
            var result = await booksService.GetWithQueryParamsUsingUriBuilder(author, language);

            //Assert
            Assert.AreEqual(expectedBooksDetails, result);
            httpClientWrapperMock.Verify(client => client.GetAsync(basepath), Times.Once);
        }

        [TestMethod]
        public async Task GivenAuthorAndLanguage_WhenGetWithQueryParamsUsingParseQueryString_ThenReturnBookDetails()
        {
            // Arrange
            var author = "Agatha Christie";
            var language = "english";
            var basepath = $"https://localhost:7220/api/Books?author=Agatha+Christie&language={language}";
            var expectedBooksDetails = $"Author: {author}, Language:{language}";

            var httpClientWrapperMock = new Mock<IHttpClientWrapper>();

            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(expectedBooksDetails)
            };

            httpClientWrapperMock
                .Setup(client => client.GetAsync(basepath))
                .ReturnsAsync(httpResponseMessage);

            var booksService = new BooksApiService(httpClientWrapperMock.Object);

            // Act
            var result = await booksService.GetWithQueryParamsUsingParseQueryStringMethod(author, language);

            //Assert
            Assert.AreEqual(expectedBooksDetails, result);
            httpClientWrapperMock.Verify(client => client.GetAsync(basepath), Times.Once);
        }

        [TestMethod]
        public async Task GivenAuthorAndLanguage_WhenGetWithQueryParamsUsingAddQueryStringMethod_ThenReturnBookDetails()
        {
            // Arrange
            var author = "Haruki Murakami";
            var language = "japanese";
            var basepath = $"https://localhost:7220/api/Books?author=Haruki%20Murakami&language={language}";
            var expectedBooksDetails = $"Author: {author}, Language:{language}";

            var httpClientWrapperMock = new Mock<IHttpClientWrapper>();

            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(expectedBooksDetails)
            };

            httpClientWrapperMock
                .Setup(client => client.GetAsync(basepath))
                .ReturnsAsync(httpResponseMessage);

            var booksService = new BooksApiService(httpClientWrapperMock.Object);

            // Act
            var result = await booksService.GetWithQueryParamsUsingAddQueryStringMethod(author, language);

            //Assert
            Assert.AreEqual(expectedBooksDetails, result);
            httpClientWrapperMock.Verify(client => client.GetAsync(basepath), Times.Once);
        }

        [TestMethod]
        public async Task GivenAuthorAndLanguage_WhenGetWithQueryParamsUsingQueryBuilder_ThenReturnBookDetails()
        {
            // Arrange
            var author = "Gabriel Garcia";
            var language = "spanish";
            var basepath = $"https://localhost:7220/api/Books?author=Gabriel%20Garcia&language={language}";
            var expectedBooksDetails = $"Author: {author}, Language:{language}";

            var httpClientWrapperMock = new Mock<IHttpClientWrapper>();

            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(expectedBooksDetails)
            };

            httpClientWrapperMock
                .Setup(client => client.GetAsync(basepath))
                .ReturnsAsync(httpResponseMessage);

            var booksService = new BooksApiService(httpClientWrapperMock.Object);

            // Act
            var result = await booksService.GetWithQueryParamsUsingQueryBuilderClass(author, language);

            //Assert
            Assert.AreEqual(expectedBooksDetails, result);
            httpClientWrapperMock.Verify(client => client.GetAsync(basepath), Times.Once);
        }

        [TestMethod]
        public async Task GivenAuthorAndLanguage_WhenGetWithQueryParamsUsingCreateMethod_ThenReturnBookDetails()
        {
            // Arrange
            var author = "Leo Tolstoy";
            var language = "russian";
            var basepath = $"https://localhost:7220/api/Books?author=Leo%20Tolstoy&language={language}";
            var expectedBooksDetails = $"Author: {author}, Language:{language}";

            var httpClientWrapperMock = new Mock<IHttpClientWrapper>();

            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(expectedBooksDetails)
            };

            httpClientWrapperMock
                .Setup(client => client.GetAsync(basepath))
                .ReturnsAsync(httpResponseMessage);

            var booksService = new BooksApiService(httpClientWrapperMock.Object);

            // Act
            var result = await booksService.GetWithQueryParamsUsingCreateMethod(author, language);

            //Assert
            Assert.AreEqual(expectedBooksDetails, result);
            httpClientWrapperMock.Verify(client => client.GetAsync(basepath), Times.Once);
        }
    }
}
