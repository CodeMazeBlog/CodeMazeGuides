using AutoMapper;
using CodeMazeShop.Services.ProductCatalog.Controllers;
using CodeMazeShop.Services.ProductCatalog.Profiles;
using CodeMazeShop.Services.ProductCatalog.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using DataContract = CodeMazeShop.DataContracts.ProductCatalog;
using Entities = CodeMazeShop.Services.ProductCatalog.Entities;

namespace Tests.Microservices.CodeMazeShop.Services.ProductCatalog
{
    [TestFixture]
    public class CategoryControllerTests
    {
        private Mock<IProductCatalogRepository> _productCatalogRepository;
        private IMapper _mockMapper;

        [SetUp]
        public void Setup()
        {
            _productCatalogRepository = new Mock<IProductCatalogRepository>();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CategoryProfile());
            });
            _mockMapper = mapperConfig.CreateMapper();
        }

        [Test]
        public async Task WhenGetIsInvoked_CategoriesAreFetchedFromRepository()
        {
            _productCatalogRepository.Setup(m => m.GetCategories()).ReturnsAsync(new List<Entities.Category>
            {
                new Entities.Category
                {
                    CategoryId = Guid.NewGuid().ToString()

                },
                new Entities.Category
                {
                   CategoryId = Guid.NewGuid().ToString()

                }
            });
            var controller = new CategoryController(_productCatalogRepository.Object, _mockMapper);

            var result = await controller.Get();

            _productCatalogRepository.Verify(x => x.GetCategories(), Times.Once());
            Assert.IsInstanceOf<ActionResult<IEnumerable<DataContract.Category>>>(result);
        }
       
    }
}
