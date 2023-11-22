namespace Services.Tests
{
    [TestClass]
    public class ArticleServiceTests
    {
        [TestMethod]
        public async Task WhenAddArticle_RepositoryAddAsyncIsCalled()
        {
            var articleRepositoryMock = new Mock<IArticleRepository>();

            var articleService = new ArticleService(articleRepositoryMock.Object);

            var article = new Article
            {
                Title = "Test",
                Description = "Test",
            };

            await articleService.AddAsync(article);

            articleRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Article>()), Times.Once);
        }

        [TestMethod]
        public async Task WhenDeleteArticle_RepositoryDeleteAsyncIsCalled()
        {
            var articleRepositoryMock = new Mock<IArticleRepository>();

            var articleService = new ArticleService(articleRepositoryMock.Object);

            await articleService.DeleteAsync(Guid.NewGuid());

            articleRepositoryMock.Verify(x => x.DeleteAsync(It.IsAny<Guid>()), Times.Once);
        }

        [TestMethod]
        public async Task WhenGetArticleById_RepositoryGetByIdAsyncIsCalled()
        {
            var articleRepositoryMock = new Mock<IArticleRepository>();

            var articleService = new ArticleService(articleRepositoryMock.Object);

            await articleService.GetByIdAsync(Guid.NewGuid());

            articleRepositoryMock.Verify(x => x.GetByIdAsync(It.IsAny<Guid>()), Times.Once);
        }

        [TestMethod]
        public async Task WhenGetAll_RepositoryGetAllAsyncIsCalled()
        {
            var articleRepositoryMock = new Mock<IArticleRepository>();

            var articleService = new ArticleService(articleRepositoryMock.Object);

            await articleService.GetAllAsync();

            articleRepositoryMock.Verify(x => x.GetAllAsync(), Times.Once);
        }
    }
}