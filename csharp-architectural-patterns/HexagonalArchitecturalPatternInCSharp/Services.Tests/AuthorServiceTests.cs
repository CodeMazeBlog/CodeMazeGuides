namespace Services.Tests
{
    [TestClass]
    public class AuthorServiceTests
    {
        [TestMethod]
        public async Task WhenAddAuthor_RepositoryAddAsyncIsCalled()
        {
            var authorRepositoryMock = new Mock<IAuthorRepository>();

            var authorService = new AuthorService(authorRepositoryMock.Object);

            var article = new Author
            {
                Name = "Test",
            };

            await authorService.AddAsync(article);

            authorRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Author>()), Times.Once);
        }

        [TestMethod]
        public async Task WhenDeleteAuthor_RepositoryDeleteAsyncIsCalled()
        {
            var authorRepositoryMock = new Mock<IAuthorRepository>();

            var authorService = new AuthorService(authorRepositoryMock.Object);

            await authorService.DeleteAsync(Guid.NewGuid());

            authorRepositoryMock.Verify(x => x.DeleteAsync(It.IsAny<Guid>()), Times.Once);
        }

        [TestMethod]
        public async Task WhenGetArticleById_RepositoryGetByIdAsyncIsCalled()
        {
            var authorRepositoryMock = new Mock<IAuthorRepository>();

            var authorService = new AuthorService(authorRepositoryMock.Object);

            await authorService.GetByIdAsync(Guid.NewGuid());

            authorRepositoryMock.Verify(x => x.GetByIdAsync(It.IsAny<Guid>()), Times.Once);
        }

        [TestMethod]
        public async Task WhenGetAll_RepositoryGetAllAsyncIsCalled()
        {
            var authorRepositoryMock = new Mock<IAuthorRepository>();

            var authorService = new AuthorService(authorRepositoryMock.Object);

            await authorService.GetAllAsync();

            authorRepositoryMock.Verify(x => x.GetAllAsync(), Times.Once);
        }
    }
}