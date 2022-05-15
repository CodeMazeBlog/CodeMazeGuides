using Article.Api.Repositories.Interfaces;
using Article.Tests.Mock.Models;
using Moq;

namespace Article.Tests.Mock
{
    public class ArticleRepositoryMock : Mock<IArticleRepository>
    {
        public ArticleRepositoryMock GetAll()
        {
            Setup(x => x.GetAll())
                .Returns(new ArticleMock().GetAll())
                .Verifiable();

            return this;
        }

        public ArticleRepositoryMock GetById()
        {
            Setup(x => x.Get(It.IsAny<int>()))
                .Returns(new ArticleMock().Get())
                .Verifiable();

            return this;
        }

        public ArticleRepositoryMock GetByIdNotFound()
        {
            Setup(x => x.Get(It.IsAny<int>()))
                .Returns(new ArticleMock().GetNotFound())
                .Verifiable();

            return this;
        }

        public ArticleRepositoryMock Delete()
        {
            Setup(x => x.Delete(It.IsAny<int>()))
                .Returns(1)
                .Verifiable();

            return this;
        }

        public ArticleRepositoryMock DeleteNotFound()
        {
            Setup(x => x.Delete(It.IsAny<int>()))
                .Returns(0)
                .Verifiable();

            return this;
        }
    }
}
