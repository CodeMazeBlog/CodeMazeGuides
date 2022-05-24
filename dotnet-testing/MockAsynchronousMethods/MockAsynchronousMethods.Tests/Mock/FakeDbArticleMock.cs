using MockAsynchronousMethods.Repository.DbModels;
using MockAsynchronousMethods.Repository.Interfaces;
using Moq;
using System.Collections.Generic;

namespace MockAsynchronousMethods.Repository.Tests.Mock
{
    public class FakeDbArticleMock : Mock<IFakeDbArticles>
    {
        public FakeDbArticleMock GetByIdAsync(ArticleDbModel articleDbModel)
        {
            Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(articleDbModel);

            return this;
        }

        public FakeDbArticleMock GetByIdAsync_Null()
        {
            Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(default(ArticleDbModel));

            return this;
        }

        public FakeDbArticleMock GetAllAsync(List<ArticleDbModel> articlesDbModel)
        {
            Setup(x => x.GetAsync())
                .ReturnsAsync(articlesDbModel);

            return this;
        }
    }
}
