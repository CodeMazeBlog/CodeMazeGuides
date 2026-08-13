using MockAsynchronousMethods.Repository.Tests.Mock;
using MockAsynchronousMethods.Tests.Mock;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MockAsynchronousMethods.Repository.Tests
{
    public class ArticleRepositoryTests
    {  
        [Fact]
        public async Task GivenAMockedDatabase_WhenRequestingAnExistingArticleAsynchronously_ThenReturnASingleArticle()
        {
            var mockArticleRepository = new FakeDbArticleMock()
                .GetByIdAsync();

            var articleRepository = new ArticleRepository(mockArticleRepository.Object);
            var result = await articleRepository.GetArticleAsync(1);

            Assert.NotNull(result);
            Assert.Equal(FakeDb.Articles.First(), result);
        }

        [Fact]
        public async Task GivenAMockDatabase_WhenRequestingANotExistentArticleAsynchronously_ThenReturnDefault()
        {
            var mockArticleRepository = new FakeDbArticleMock()
                .GetByIdAsync_Null();

            var articleRepository = new ArticleRepository(mockArticleRepository.Object);
            var result = await articleRepository.GetArticleAsync(99);

            Assert.Null(result);
        }

        [Fact]
        public async Task GivenAMockedDatabase_WhenRequestingAListOfArticleAsynchronously_ThenReturnAListOfArticles()
        {
            var mockArticleRepository = new FakeDbArticleMock()
                .GetAllAsync();

            var articleRepository = new ArticleRepository(mockArticleRepository.Object);
            var result = await articleRepository.GetAllArticlesAsync();

            Assert.NotNull(result);
            Assert.True(result.Any());
        }

        [Fact]
        public async Task GivenAMockedDatabase_WhenDeletingAnArticleAsynchronously_ThenTheDeleteIsCalledOnce()
        {
            var mockArticleRepository = new FakeDbArticleMock()
                .DeleteAsync();

            var articleRepository = new ArticleRepository(mockArticleRepository.Object);
            await articleRepository.DeleteArticleAsync(1);

            mockArticleRepository.Verify(x => x.DeleteAsync(1), Times.Once);
        }
    }
}