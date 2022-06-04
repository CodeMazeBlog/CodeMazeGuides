using MockAsynchronousMethods.Repository.DbModels;
using MockAsynchronousMethods.Repository.Interfaces;
using MockAsynchronousMethods.Tests.Mock;
using Moq;
using System.Linq;

namespace MockAsynchronousMethods.Repository.Tests.Mock
{
    public class FakeDbArticleMock : Mock<IFakeDbArticles>
    {
        public FakeDbArticleMock GetByIdAsync()
        {
            Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(FakeDb.Articles.First());

            return this;
        }

        public FakeDbArticleMock GetByIdAsync_Null()
        {
            Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(default(ArticleDbModel));

            return this;
        }

        public FakeDbArticleMock GetAllAsync()
        {
            Setup(x => x.GetAsync())
                .ReturnsAsync(FakeDb.Articles);

            return this;
        }
    }
}
