using Article.Api.Controllers;
using Article.Api.Repositories.Interfaces;
using Article.Tests.Mock;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Article.Tests
{
    [TestClass]
    public class ArticleControllerTests
    {
        [TestMethod]
        public void GivenTheGetEndpoint_WhenNoParameters_ThenReturnEveryArticles()
        {
            var articleRepositoryMock = new ArticleRepositoryMock()
                .GetAll();

            var controller = InstantiateController(articleRepositoryMock);
            var result = controller.Get();

            Assert.IsNotNull(result);
            Assert.IsTrue(result is OkObjectResult);
        }

        [TestMethod]
        public void GivenTheGetEndpoint_WhenSendIdAsParameter_ThenReturnTheArticleWithThisId()
        {
            var articleRepositoryMock = new ArticleRepositoryMock()
                .GetById();

            var controller = InstantiateController(articleRepositoryMock);
            var result = controller.Get(1);

            Assert.IsNotNull(result);
            Assert.IsTrue(result is OkObjectResult);
        }

        [TestMethod]
        public void GivenTheGetEndpoint_WhenSendNotFoundIdAsParameter_ThenReturnNotFound()
        {
            var articleRepositoryMock = new ArticleRepositoryMock()
                .GetByIdNotFound();

            var controller = InstantiateController(articleRepositoryMock);
            var result = controller.Get(99);

            Assert.IsNotNull(result);
            Assert.IsTrue(result is NotFoundResult);
        }

        [TestMethod]
        public void GivenTheDeleteEndpoint_WhenSendIdAsParameter_ThenDeleteTheArticleWithThisId()
        {
            var articleRepositoryMock = new ArticleRepositoryMock()
                .Delete();

            var controller = InstantiateController(articleRepositoryMock);
            var result = controller.Delete(1);

            Assert.IsNotNull(result);
            Assert.IsTrue(result is NoContentResult);
        }

        [TestMethod]
        public void GivenTheDeleteEndpoint_WhenSendNotFoundIdAsParameter_ThenReturnNotFound()
        {
            var articleRepositoryMock = new ArticleRepositoryMock()
                .DeleteNotFound();

            var controller = InstantiateController(articleRepositoryMock);
            var result = controller.Delete(1);

            Assert.IsNotNull(result);
            Assert.IsTrue(result is NotFoundResult);
        }

        private ArticlesController InstantiateController(ArticleRepositoryMock? articleRepositoryMock = null)
        {
            var mockArticle = articleRepositoryMock ?? new Mock<IArticleRepository>();

            return new ArticlesController(mockArticle.Object);
        }
    }
}