using CreatingMultipleResorcesWithPOST.Infrastructure;
using CreatingMultipleResorcesWithPOST.Models;
using CreatingMultipleResorcesWithPOST.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace Tests
{
    public class BookServiceTest
    {
        [Fact]
        public void GivenOneBookRequest_WhenCreateBookIsCalled_ThenBookIsCreated()
        {
            // Given
            var bookRequest = new BookRequest("name", "isbn");

            var options = new DbContextOptionsBuilder<ApiContext>()
                .UseInMemoryDatabase(databaseName: "api1")
                .Options;

            // When
            var bookService = new BookService(new ApiContext(options));
            var createdBook = bookService.CreateBook(bookRequest);

            // Then
            Assert.Equal("name", createdBook.Name);
        }

        [Theory]
        [InlineData("name1", "isbn1", "200", "name2", "isbn2", "200")]
        [InlineData("name1", "isbn1", "200", "name2", null, "500")]
        public void GivenMultipleBookRequests_WhenCreateBooksIsCalled_ThenBooksAreCreatedWithRespectedStatus(
            string name1, string isbn1, string expectedStatus1,
            string name2, string isbn2, string expectedStatus2)
        {
            // Given
            var bookRequests = new[]
            {
                new BookRequest(name1, isbn1),
                new BookRequest(name2, isbn2)
            };

            var options = new DbContextOptionsBuilder<ApiContext>()
                .UseInMemoryDatabase(databaseName: "api2")
                .Options;

            // When
            var bookService = new BookService(new ApiContext(options));
            var books = bookService.CreateBooks(bookRequests);

            // Then
            Assert.Equal(expectedStatus1, books.ElementAt(0).Status);
            Assert.Equal(expectedStatus2, books.ElementAt(1).Status);
        }

        [Fact]
        public void GivenTwoBooks_WhenGetBooksIsCalled_ThenAllBooksAreReturned()
        {
            // Given
            var options = new DbContextOptionsBuilder<ApiContext>()
                .UseInMemoryDatabase(databaseName: "api3")
                .Options;

            var apiContext = new ApiContext(options);
            apiContext.AddRange(new[]
            {
                new BookModel(0, "name1", "isbn1"),
                new BookModel(0, "name2", "isbn2")
            });
            apiContext.SaveChanges();

            // When
            var bookService = new BookService(apiContext);
            var books = bookService.GetBooks();

            // Then
            Assert.Equal("name1", (books.ElementAt(0)).Name);
            Assert.Equal("name2", (books.ElementAt(1)).Name);
        }
    }
}