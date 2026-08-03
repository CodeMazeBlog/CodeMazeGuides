namespace Services.Tests
{
    [TestClass]
    public class WritingServiceTests
    {
        [TestMethod]
        public async Task WhenStartArticleAsync_RepositoryGetIdsAndUpdateAreCalledCalled()
        {
            var authorRepositoryMock = new Mock<IAuthorRepository>();
            var articleRepositoryMock = new Mock<IArticleRepository>();

            authorRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>()).Result).Returns(new Author { Name = "Name" });
            articleRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>()).Result).Returns(new Article { Title = "Title" });

            var writingService = new WritingService(authorRepositoryMock.Object, articleRepositoryMock.Object);

            await writingService.StartWritingAsync(Guid.NewGuid(), Guid.NewGuid());

            authorRepositoryMock.Verify(x => x.GetByIdAsync(It.IsAny<Guid>()), Times.Once);
            articleRepositoryMock.Verify(x => x.GetByIdAsync(It.IsAny<Guid>()), Times.Once);
            articleRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<Article>()), Times.Once);
        }

        [TestMethod]
        public async Task WhenChangeArticleStatus_RepositoryGetByIdAsyncAndUpdateAsyncAreCalled()
        {
            var authorRepositoryMock = new Mock<IAuthorRepository>();
            var articleRepositoryMock = new Mock<IArticleRepository>();

            articleRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>()).Result).Returns(new Article { Title = "Title" });

            var writingService = new WritingService(authorRepositoryMock.Object, articleRepositoryMock.Object);

            await writingService.ChangeArticleStatusAsync(Guid.NewGuid(), WritingStatus.Writing);

            articleRepositoryMock.Verify(x => x.GetByIdAsync(It.IsAny<Guid>()), Times.Once);
            articleRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<Article>()), Times.Once);
        }
    }
}