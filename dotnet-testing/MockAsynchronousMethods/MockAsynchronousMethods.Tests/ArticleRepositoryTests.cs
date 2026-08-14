using MockAsynchronousMethods.Repository.DbModels;
using MockAsynchronousMethods.Repository.Tests.Mock;
using MockAsynchronousMethods.Tests.Mock;
using Moq;
using System;
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
            mockArticleRepository.Verify(x => x.GetByIdAsync(1), Times.Once);
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
        public async Task GivenAMockedDatabase_WhenSavingAnArticleAsynchronously_ThenTheSaveCompletes()
        {
            var mockArticleRepository = new FakeDbArticleMock()
                .SaveAsync();

            var articleRepository = new ArticleRepository(mockArticleRepository.Object);
            var article = new ArticleDbModel { Id = 4, Title = "Fourth Article", LastUpdate = DateTime.Now };

            await articleRepository.SaveArticleAsync(article);

            mockArticleRepository.Verify(x => x.SaveAsync(article), Times.Once);
        }
    }
}