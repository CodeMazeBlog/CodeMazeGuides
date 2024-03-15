using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PreventSQLInjectionAttacks.Data;
using PreventSQLInjectionAttacks.Models;
using PreventSQLInjectionAttacks.Pages;

namespace Tests
{
    public class BooksTest
    {
        private readonly IConfiguration _configuration;

        public BooksTest()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        [Fact]
        public void GivenNoSearchTerm_WhenSelectedTableEFCore_OnGet_ReturnsAllBooksUsingEFCore()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<DataContext>()
                    .UseSqlite(connection)
                    .Options;

                using var context = new DataContext(options);
                context.Database.EnsureCreated();

                var mockBooksEFCore = new List<Book>
                    {
                        new Book { Id = 1, Title = "Book 1", Author = "Author 1" },
                        new Book { Id = 2, Title = "Book 2", Author = "Author 2" }
                    };

                context.Books.AddRange(mockBooksEFCore);
                context.SaveChanges();

                var booksModel = new BooksModel(context, _configuration)
                {
                    SelectedTable = "EFCore"
                };

                booksModel.OnGet(searchTerm: "");
                
                Assert.NotNull(booksModel.BooksEFCore);

                Assert.Null(booksModel.BooksDapper);
                
                Assert.Null(booksModel.BooksADO);
                
                Assert.Equal(mockBooksEFCore.Count, booksModel.BooksEFCore.Count);
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public void GivenSearchTerm_WhenSelectedTableEFCore_OnGet_ReturnsSelectedBookUsingEFCore()
        {            
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<DataContext>()
                    .UseSqlite(connection)
                    .Options;

                using var context = new DataContext(options);
                context.Database.EnsureCreated();

                var mockBooksEFCore = new List<Book>
                    {
                        new Book { Id = 1, Title = "Book 1", Author = "Author 1" },
                        new Book { Id = 2, Title = "Book 2", Author = "Author 2" }
                    };

                context.Books.AddRange(mockBooksEFCore);
                context.SaveChanges();

                var booksModel = new BooksModel(context, _configuration)
                {
                    SelectedTable = "EFCore"
                };

                booksModel.OnGet(searchTerm: "Book 1");

                Assert.NotNull(booksModel.BooksEFCore);

                Assert.Null(booksModel.BooksDapper);

                Assert.Null(booksModel.BooksADO);

                Assert.Equal(1, booksModel.BooksEFCore.Count);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}