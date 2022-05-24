using MockAsynchronousMethods.Repository.DbModels;
using MockAsynchronousMethods.Repository.Tests.Mock;
using System;
using System.Collections.Generic;
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
            var article = new ArticleDbModel
            {
                Id = 1,
                Title = "First Article",
                LastUpdate = DateTime.Now
            };

            var mockArticleRepository = new FakeDbArticleMock()
                .GetByIdAsync(article);

            var articleRepository = new ArticleRepository(mockArticleRepository.Object);
            var result = await articleRepository.GetArticleAsync(1);

            Assert.NotNull(result);
            Assert.Equal(article, result);
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
                .GetAllAsync(new List<ArticleDbModel>
                {
                    new ArticleDbModel
                    {
                        Id = 1,
                        Title = "First Article",
                        LastUpdate = DateTime.Now
                    }
                });

            var articleRepository = new ArticleRepository(mockArticleRepository.Object);
            var result = await articleRepository.GetAllArticlesAsync();

            Assert.NotNull(result);
            Assert.True(result.Any());
        }
    }
}