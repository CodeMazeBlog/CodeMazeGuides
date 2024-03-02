using VirtualKeywordInEFCore.Models;

namespace Tests
{
    public class VirtualKeywordInEFCoreTests
    {
        private readonly DataContextWithoutLazyLoading _context;
        private readonly DataContextLazyLoading _contextLazyLoading;

        public VirtualKeywordInEFCoreTests()
        {
            _context = new DataContextWithoutLazyLoading();
            _contextLazyLoading = new DataContextLazyLoading();
            DataSeeder.SeedWhitoutLazy(_context);
            DataSeeder.SeedLazy(_contextLazyLoading);
        }

        [Fact]
        public void GivenDefaultSetup_WhenAuthorRetrieved_ThenNoBooksLazyLoaded()
        {
            // Act
            var colleenHOOVER_author = _context.Authors.First(a => a.FullName == "Colleen HOOVER");

            // Assert
            Assert.NotNull(colleenHOOVER_author);
            Assert.Empty(colleenHOOVER_author.Books);
        }

        [Fact]
        public void GivenLazyLoading_WhenAuthorRetrieved_ThenBooksLazyLoaded()
        {
            // Arrange
            var hollyJACKSON_author = new Author_lazy();

            // Act
            hollyJACKSON_author = _contextLazyLoading.Authors_lazy.First(a => a.FullName == "Holly JACKSON");

            // Assert
            Assert.NotNull(hollyJACKSON_author);
            Assert.True(hollyJACKSON_author.Books.Any());
            Assert.IsNotType<Author_lazy>(hollyJACKSON_author);
            Assert.Equal("Castle.Proxies.Author_lazyProxy", hollyJACKSON_author.GetType().ToString());
            Assert.Equal("Castle.Proxies.Book_lazyProxy", hollyJACKSON_author.Books.First().GetType().ToString());
        }
    }
}