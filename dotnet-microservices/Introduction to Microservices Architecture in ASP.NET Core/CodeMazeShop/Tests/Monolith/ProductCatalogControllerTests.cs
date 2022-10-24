using CodeMazeShop.Web.Controllers;
using CodeMazeShop.Web.Entities;
using CodeMazeShop.Web.Models;
using CodeMazeShop.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Tests.Common;

namespace Tests.Monolith
{
    [TestFixture]
    public class ProductCatalogControllerTests
    {
        private Mock<IProductCatalogService> _productCatalogService;
        private Mock<IShoppingCartService> _shoppingCartService;
        private CookieSettings _cookieSettings;
        private Random _rnd = new();        

        [SetUp]
        public void Setup()
        {
            _productCatalogService = new Mock<IProductCatalogService>();
            _shoppingCartService = new Mock<IShoppingCartService>();
            _cookieSettings = new CookieSettings();
            
            var (products, categories) = InitializeProductCatalogMockData();
            
            _productCatalogService.Setup(m => m.GetAll()).ReturnsAsync(products);
            _productCatalogService.Setup(m => m.GetCategories()).ReturnsAsync(categories);
        }

        [Test]
        public async Task WhenIndexActionInvokedWithNoCartId_CartItemsAreZero() 
        {
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Cookies = new RequestCookieCollectionFake(new Dictionary<string, string>());
            var controller = new ProductCatalogController(_productCatalogService.Object, _shoppingCartService.Object, _cookieSettings)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };

            var result = await controller.Index(Guid.Empty);

            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            var model = viewResult.Model;
            var cartItemCount = ((ProductListModel)model).NumberOfItems;
            Assert.That(cartItemCount, Is.EqualTo(0));
        }

        [Test]
        public async Task WhenIndexActionInvokedWithCartId_CartItemsAreAvailable()
        {
            var cartId = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Cookies = new RequestCookieCollectionFake(new Dictionary<string, string> { { "CartId", cartId.ToString() } });
            _shoppingCartService.Setup(m => m.GetShoppingCart(It.IsAny<Guid>())).ReturnsAsync(new Cart { CartId = cartId, UserId = userId, NumberOfItems = 3 });
           var controller = new ProductCatalogController(_productCatalogService.Object, _shoppingCartService.Object, _cookieSettings)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };

            var result = await controller.Index(Guid.Empty);

            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            var model = viewResult.Model;
            var cartItemCount = ((ProductListModel)model).NumberOfItems;
            Assert.That(cartItemCount, Is.EqualTo(3));
            _shoppingCartService.Verify(x=>x.GetShoppingCart(cartId), Times.Once());
        }

        [Test]
        public async Task WhenIndexActionInvokedWithoutCategoryId_AllProductsAreFetched()
        {
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Cookies = new RequestCookieCollectionFake(new Dictionary<string, string>());
            var controller = new ProductCatalogController(_productCatalogService.Object, _shoppingCartService.Object, _cookieSettings)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };

            var result = await controller.Index(Guid.Empty);

            _productCatalogService.Verify(x => x.GetAll(), Times.Once);
        }

        [Test]
        public async Task WhenIndexActionInvokedWithCategoryId_ProductsForThatCategoryAreFetched()
        {
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Cookies = new RequestCookieCollectionFake(new Dictionary<string, string>());
            _productCatalogService.Setup(m => m.GetByCategoryId(It.IsAny<Guid>())).ReturnsAsync(new List<Product>
            {
                new Product{ ProductId = Guid.NewGuid() },
                new Product{ ProductId  = Guid.NewGuid() }
            });
            var controller = new ProductCatalogController(_productCatalogService.Object, _shoppingCartService.Object, _cookieSettings)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };

            var result = await controller.Index(Guid.NewGuid());

            _productCatalogService.Verify(x => x.GetByCategoryId(It.IsAny<Guid>()), Times.Once);
            var viewResult = result as ViewResult;
            var model = viewResult.Model;
            var productCount = ((ProductListModel)model).Products.Count();
            Assert.That(productCount, Is.EqualTo(2));
        }

        [Test]
        public async Task WhenDetailActionInvokedForAProduct_CorrespondingProductFetched()
        {
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Cookies = new RequestCookieCollectionFake(new Dictionary<string, string>());
            var productId = Guid.NewGuid();
            _productCatalogService.Setup(m => m.GetProduct(It.IsAny<Guid>())).ReturnsAsync(new Product { ProductId = productId });
            var controller = new ProductCatalogController(_productCatalogService.Object, _shoppingCartService.Object, _cookieSettings)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };

            var result = await controller.Detail(productId);

            _productCatalogService.Verify(x => x.GetProduct(productId), Times.Once);
            var viewResult = result as ViewResult;
            var model = viewResult.Model;
            var product = (Product)model;
            Assert.That(product.ProductId, Is.EqualTo(productId));
        }

        private (List<Product>, List<Category>) InitializeProductCatalogMockData()
        {
            Dictionary<Guid, Product> _products = new();
            Dictionary<Guid, Category> _categories = new();

            for (var i = 0; i < 3; i++)
            {
                var categoryId = Guid.NewGuid();
                _categories.Add(categoryId, new Category
                {
                    CategoryId = categoryId,
                    Name = $"Category{i + 1}"
                });
            }

            for (var i = 0; i < 6; i++)
            {
                var productId = Guid.NewGuid();
                var categoryIndex = _rnd.Next(0, 3);
                _products.Add(productId, new Product
                {
                    ProductId = productId,
                    Name = $"Test Product {i + 1}",
                    Description = $"Test Product {i + 1} - Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Price = _rnd.Next(10, 200),
                    ImageUrl = $"/img/test_product{i + 1}.png",
                    CategoryId = _categories.Keys.ElementAt(categoryIndex),
                    CategoryName = _categories.Values.ElementAt(categoryIndex).Name
                });

            }

            return (_products.Values.ToList(), _categories.Values.ToList());
        }
    }
}
