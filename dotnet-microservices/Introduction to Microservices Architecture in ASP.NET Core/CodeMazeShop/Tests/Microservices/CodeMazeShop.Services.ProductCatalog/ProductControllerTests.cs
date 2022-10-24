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
    public class ProductControllerTests
    {
        private Mock<IProductCatalogRepository> _productCatalogRepository;
        private IMapper _mockMapper;

        [SetUp]
        public void Setup()
        {
            _productCatalogRepository = new Mock<IProductCatalogRepository>();
            
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ProductProfile());
            });
            _mockMapper = mapperConfig.CreateMapper();
        }

        [Test]
        public async Task WhenGetIsInvoked_ProductsAreFetchedFromRepository()
        {
            _productCatalogRepository.Setup(m => m.GetProductsByCategoryId(It.IsAny<string>())).ReturnsAsync(new List<Entities.Product>
            {
                new Entities.Product
                {
                    ProductId = Guid.NewGuid().ToString()

                },
                new Entities.Product
                {
                    ProductId = Guid.NewGuid().ToString()

                }
            });
            var controller = new ProductController(_productCatalogRepository.Object, _mockMapper);

            var result = await controller.Get(String.Empty);

            _productCatalogRepository.Verify(x=>x.GetProductsByCategoryId(string.Empty), Times.Once());
            Assert.IsInstanceOf<ActionResult<IEnumerable<DataContract.Product>>>(result);          
        }

        [Test]
        public async Task WhenGetByIdIsInvoked_SpecificProductIsFetchedFromRepository()
        {
            var productId = Guid.NewGuid().ToString();
            _productCatalogRepository.Setup(m => m.GetProduct(It.IsAny<string>())).ReturnsAsync(
                new Entities.Product
                {
                    ProductId = productId
                });
            var controller = new ProductController(_productCatalogRepository.Object, _mockMapper);

            var result = await controller.GetById(productId);

            _productCatalogRepository.Verify(x => x.GetProduct(productId), Times.Once());
            Assert.IsInstanceOf<ActionResult<DataContract.Product>>(result);
        }
    }
}
