using Microsoft.EntityFrameworkCore;
using VirtualKeywordInEFCore.Models;

namespace Tests
{
    public class VirtualKeywordInEFCoreTests
    {
        private readonly DataContextWithoutLazyLoading _context = new();
        private readonly DataContextLazyLoading _contextLazyLoading = new();

        public VirtualKeywordInEFCoreTests()
        {
            DataSeeder.SeedWithoutLazy(_context);
            DataSeeder.SeedLazy(_contextLazyLoading);
        }

        [Fact]
        public void GivenDefaultSetup_WhenAuthorRetrieved_ThenNoBooksLazyLoaded()
        {
            // Act
            var authorColleenHoover = _context.Authors.AsNoTracking().First(a => a.FullName == "Colleen HOOVER");

            // Assert
            Assert.NotNull(authorColleenHoover);
            Assert.Empty(authorColleenHoover.Books);
        }

        [Fact]
        public void GivenLazyLoading_WhenAuthorRetrieved_ThenBooksLazyLoaded()
        {
            // Arrange
            var authorHollyJackson = new AuthorLazy();

            // Act
            authorHollyJackson = _contextLazyLoading.AuthorsLazy.AsNoTracking().First(a => a.FullName == "Holly JACKSON");

            // Assert
            Assert.NotNull(authorHollyJackson);
            Assert.True(authorHollyJackson.Books.Any());
            Assert.IsNotType<AuthorLazy>(authorHollyJackson);
            Assert.Equal("Castle.Proxies.AuthorLazyProxy", authorHollyJackson.GetType().ToString());
            Assert.Equal("Castle.Proxies.BookLazyProxy", authorHollyJackson.Books.First().GetType().ToString());
        }


        [Fact]
        public void GivenLazyLoading_WithLazyLoadingEnabledPropertySetToFalse_WhenAuthorRetrieved_ThenNoBooksLazyLoaded()
        {
            // Arrange & Act
            _contextLazyLoading.ChangeTracker.LazyLoadingEnabled = false;
            var authorHollyJackson = _contextLazyLoading.AuthorsLazy.AsNoTracking().First(a => a.FullName == "Holly JACKSON");

            // Assert
            Assert.NotNull(authorHollyJackson);
            Assert.False(authorHollyJackson.Books.Any());
            Assert.Empty(authorHollyJackson.Books);
        }
    }
}