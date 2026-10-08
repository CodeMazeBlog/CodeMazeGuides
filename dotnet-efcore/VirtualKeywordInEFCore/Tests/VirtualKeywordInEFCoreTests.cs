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

        [Fact]
        public void GivenInjectedLazyLoader_WhenAuthorRetrievedInFreshContext_ThenBooksLazyLoadedWithoutProxy()
        {
            // Arrange
            using (var seedContext = new DataContextInjected())
            {
                DataSeeder.SeedInjected(seedContext);
            }

            using var context = new DataContextInjected();

            // Act
            var author = context.AuthorsInjected.First(a => a.FullName == "Freida MCFADDEN");

            // Assert
            Assert.Equal(typeof(AuthorInjected), author.GetType());
            Assert.NotNull(author.Books);
            Assert.Equal(2, author.Books.Count);
        }

        [Fact]
        public void GivenNoLazyLoading_WhenCollectionExplicitlyLoaded_ThenEmptyCollectionIsFilled()
        {
            // Arrange
            using var context = new DataContextWithoutLazyLoading();
            var author = context.Authors.First(a => a.FullName == "Lucy FOLEY");
            Assert.Empty(author.Books);

            // Act
            context.Entry(author).Collection(a => a.Books).Load();

            // Assert
            Assert.Equal(4, author.Books.Count);
        }
    }
}