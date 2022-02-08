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
        [Theory]
        [InlineData("name1", "isbn1", "201", "name2", "isbn2", "201")]
        [InlineData("name1", "isbn1", "201", "name2", null, "500")]
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
    }
}