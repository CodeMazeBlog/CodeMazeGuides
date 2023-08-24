using Microsoft.Extensions.Logging;
using Moq;
using SwashbuckleVsNSwag.Models.Products;
using SwashbuckleVsNSwag.NSwag.Controllers;
using SwashbuckleVsNSwag.Repositories.ProductRepository;

namespace SwashbuckleVsNSwag.NSwag.Tests
{
    public class ProductConsollerTest
    {
        private Mock<ILogger<ProductController>> _logger;
        private Mock<IProductRepository> _productRepository;
        private ProductController _controller;

        [SetUp]
        public void Setup()
        {
            _logger= new Mock<ILogger<ProductController>>();
            _productRepository= new Mock<IProductRepository>();

            _controller = new ProductController(_logger.Object, _productRepository.Object);
        }

        [Test]
        public void WhenGettingProductById_ThenReturnCorrectProduct()
        {
            var product = new Product
            {
                ProductId = new Guid("59d37b43-01c4-4bc7-8ccf-7d67bb10229c"),
                Name = "John Smith"
            };
            _productRepository.Setup(r => r.GetById(It.IsAny<Guid>())).Returns(product);

            var result = _controller.Get(product.ProductId).Value;

            Assert.That(result, Is.Not.Null);
            Assert.That(result.ProductId, Is.EqualTo(product.ProductId));
            Assert.That(result.Name, Is.EqualTo(product.Name));
        }

        [Test]
        public void WhenAddingProduct_ThenProductIsStored()
        {
            var product = new Product
            {
                ProductId = new Guid("59d37b43-01c4-4bc7-8ccf-7d67bb10229c"),
                Name = "John Smith"
            };

            _controller.Post(product);

            _productRepository.Verify(r => r.Add(It.IsAny<Product>()), Times.Once);
        }
    }
}