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
    public class ShoppingCartControllerTests
    {
        private Mock<IShoppingCartService> _shoppingCartService;
        private CookieSettings _cookieSettings;

        [SetUp]
        public void Setup()
        {
           
            _shoppingCartService = new Mock<IShoppingCartService>();
            _cookieSettings = new CookieSettings();
        }
        
        [Test]
        public async Task WhenIndexActionInvokedWithNoCartId_CartViewModelEmpty()
        {
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Cookies = new RequestCookieCollectionFake(new Dictionary<string, string>());
            var controller = new ShoppingCartController(_shoppingCartService.Object, _cookieSettings)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };

            var result = await controller.Index();

            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            var model = viewResult.Model;
            var cartId = ((CartViewModel)model).CartId;
            Assert.That(cartId, Is.EqualTo(Guid.Empty));
        }
        
        [Test]
        public async Task WhenIndexActionInvokedWithCartId_CartDetailsIsFetched()
        {
            var cartId = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Cookies = new RequestCookieCollectionFake(new Dictionary<string, string> { { "CartId", cartId.ToString() } });
            _shoppingCartService.Setup(m => m.GetShoppingCart(It.IsAny<Guid>())).ReturnsAsync(new Cart { CartId = cartId, UserId = userId, NumberOfItems = 3 });
            _shoppingCartService.Setup(m => m.GetCartLineItemsForCart(It.IsAny<Guid>())).ReturnsAsync(new List<CartLineItem>
            {
                new CartLineItem
                {
                    CartLineItemId = Guid.NewGuid(),
                    CartId = cartId,
                    Product = new Product
                    {
                        ProductId = Guid.NewGuid(),
                        Name = "Test Product 1"
                    }
                },
                new CartLineItem
                {
                    CartLineItemId = Guid.NewGuid(),
                    CartId = cartId,
                    Product = new Product
                    {
                        ProductId = Guid.NewGuid(),
                        Name = "Test Product 2"
                    }
                }
            });
            var controller = new ShoppingCartController(_shoppingCartService.Object, _cookieSettings)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };

            var result = await controller.Index();

            Assert.IsInstanceOf<ViewResult>(result);
            _shoppingCartService.Verify(x => x.GetShoppingCart(cartId), Times.Once());
            _shoppingCartService.Verify(x => x.GetCartLineItemsForCart(cartId), Times.Once());
        }
        
        [Test]
        public async Task WhenIndexActionInvokedValidPromoCoupon_PromoCouponDetailsIsFetched()
        {
            var cartId = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var promoCouponId = Guid.NewGuid();
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Cookies = new RequestCookieCollectionFake(new Dictionary<string, string> { { "CartId", cartId.ToString() } });
            _shoppingCartService.Setup(m => m.GetShoppingCart(It.IsAny<Guid>())).ReturnsAsync(new Cart { CartId = cartId, UserId = userId, NumberOfItems = 3, PromotionCouponId = promoCouponId });
            _shoppingCartService.Setup(m => m.GetCartLineItemsForCart(It.IsAny<Guid>())).ReturnsAsync(new List<CartLineItem>
            {
                new CartLineItem
                {
                    CartLineItemId = Guid.NewGuid(),
                    CartId = cartId,
                    Product = new Product
                    {
                        ProductId = Guid.NewGuid(),
                        Name = "Test Product 1"
                    }
                },
                new CartLineItem
                {
                    CartLineItemId = Guid.NewGuid(),
                    CartId = cartId,
                    Product = new Product
                    {
                        ProductId = Guid.NewGuid(),
                        Name = "Test Product 2"
                    }
                }
            });
            _shoppingCartService.Setup(m => m.GetPromotionCoupon(It.IsAny<Guid>())).ReturnsAsync(new PromotionCoupon
            {
                PromotionCouponId = promoCouponId
            });
            var controller = new ShoppingCartController(_shoppingCartService.Object, _cookieSettings)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };

            var result = await controller.Index();

            Assert.IsInstanceOf<ViewResult>(result);
            _shoppingCartService.Verify(x => x.GetPromotionCoupon(promoCouponId), Times.Once());            
        }
        
        [Test]
        public async Task WhenIndexActionInvokedNoPromoCoupon_PromoCouponDetailsIsNotFetched()
        {
            var cartId = Guid.NewGuid();
            var userId = Guid.NewGuid();           
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Cookies = new RequestCookieCollectionFake(new Dictionary<string, string> { { "CartId", cartId.ToString() } });
            _shoppingCartService.Setup(m => m.GetShoppingCart(It.IsAny<Guid>())).ReturnsAsync(new Cart { CartId = cartId, UserId = userId, NumberOfItems = 3});
            _shoppingCartService.Setup(m => m.GetCartLineItemsForCart(It.IsAny<Guid>())).ReturnsAsync(new List<CartLineItem>
            {
                new CartLineItem
                {
                    CartLineItemId = Guid.NewGuid(),
                    CartId = cartId,
                    Product = new Product
                    {
                        ProductId = Guid.NewGuid(),
                        Name = "Test Product 1"
                    }
                },
                new CartLineItem
                {
                    CartLineItemId = Guid.NewGuid(),
                    CartId = cartId,
                    Product = new Product
                    {
                        ProductId = Guid.NewGuid(),
                        Name = "Test Product 2"
                    }
                }
            });
            _shoppingCartService.Setup(m => m.GetPromotionCoupon(It.IsAny<Guid>())).ReturnsAsync(It.IsAny<PromotionCoupon>());
            var controller = new ShoppingCartController(_shoppingCartService.Object, _cookieSettings)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };

            var result = await controller.Index();

            Assert.IsInstanceOf<ViewResult>(result);
            _shoppingCartService.Verify(x => x.GetPromotionCoupon(It.IsAny<Guid>()), Times.Never);
        }
        
        [Test]
        public async Task WhenAddCartLineItemActionInvoked_ItemIsAddedToCartAndRedirected()
        {
            var cartId = Guid.NewGuid();            
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Cookies = new RequestCookieCollectionFake(new Dictionary<string, string> { { "CartId", cartId.ToString() } });
            _shoppingCartService.Setup(m => m.AddToCart(It.IsAny<Guid>(), It.IsAny<CartLineItemForCreation>())).ReturnsAsync(new CartLineItem
            {
                CartLineItemId = Guid.NewGuid(),
                CartId = cartId
            });
            var controller = new ShoppingCartController(_shoppingCartService.Object, _cookieSettings)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };

            var result = await controller.AddCartLineItem(new CartLineItemForCreation());

            Assert.IsInstanceOf<RedirectToActionResult>(result);
            _shoppingCartService.Verify(x => x.AddToCart(cartId, It.IsAny<CartLineItemForCreation>()), Times.Once());
            var redirectResult = result as RedirectToActionResult;
            Assert.That(redirectResult.ActionName, Is.EqualTo("Index"));
        }
        
        [Test]
        public async Task WhenUpdateLineItemActionInvoked_ItemIsUpdatedInCartAndRedirected()
        {
            var cartId = Guid.NewGuid();
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Cookies = new RequestCookieCollectionFake(new Dictionary<string, string> { { "CartId", cartId.ToString() } });
            _shoppingCartService.Setup(m => m.UpdateCartLineItem(It.IsAny<Guid>(), It.IsAny<CartLineItemForUpdate>())).Returns(Task.CompletedTask);
            var controller = new ShoppingCartController(_shoppingCartService.Object, _cookieSettings)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };

            var result = await controller.UpdateLineItem(new CartLineItemForUpdate());

            Assert.IsInstanceOf<RedirectToActionResult>(result);
            _shoppingCartService.Verify(x => x.UpdateCartLineItem(cartId, It.IsAny<CartLineItemForUpdate>()), Times.Once());
            var redirectResult = result as RedirectToActionResult;
            Assert.That(redirectResult.ActionName, Is.EqualTo("Index"));
        }
        
        [Test]
        public async Task WhenRemoveLineItemActionInvoked_ItemIsRemovedFromCartAndRedirected()
        {
            var cartId = Guid.NewGuid();
            var cartLineItemId = Guid.NewGuid();
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Cookies = new RequestCookieCollectionFake(new Dictionary<string, string> { { "CartId", cartId.ToString() } });
            _shoppingCartService.Setup(m => m.RemoveLineItem(cartId, It.IsAny<Guid>())).Returns(Task.CompletedTask);
            var controller = new ShoppingCartController(_shoppingCartService.Object, _cookieSettings)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };

            var result = await controller.RemoveLineItem(cartLineItemId);

            Assert.IsInstanceOf<RedirectToActionResult>(result);
            _shoppingCartService.Verify(x => x.RemoveLineItem(cartId, cartLineItemId), Times.Once());
            var redirectResult = result as RedirectToActionResult;
            Assert.That(redirectResult.ActionName, Is.EqualTo("Index"));
        }
        
        [Test]
        public async Task WhenApplyDiscountCodeActionInvoked_PromotionCouponIsFetchedAlways()
        {
            var cartId = Guid.NewGuid();            
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Cookies = new RequestCookieCollectionFake(new Dictionary<string, string> { { "CartId", cartId.ToString() } });
            _shoppingCartService.Setup(m => m.GetPromotionCouponByCode(It.IsAny<string>())).ReturnsAsync(new PromotionCoupon());
            var controller = new ShoppingCartController(_shoppingCartService.Object, _cookieSettings)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };

            var result = await controller.ApplyDiscountCode("TestCode");
           
            _shoppingCartService.Verify(x => x.GetPromotionCouponByCode("TestCode"), Times.Once());           
        }
        
        [Test]
        public async Task WhenApplyDiscountCodeActionInvoked_PromotionCouponIsAlreadyUsedRedirectsToIndex()
        {
            var cartId = Guid.NewGuid();
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Cookies = new RequestCookieCollectionFake(new Dictionary<string, string> { { "CartId", cartId.ToString() } });
            _shoppingCartService.Setup(m => m.GetPromotionCouponByCode(It.IsAny<string>())).ReturnsAsync(new PromotionCoupon
            {
                IsAlreadyUsed = true
            });
            var controller = new ShoppingCartController(_shoppingCartService.Object, _cookieSettings)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };

            var result = await controller.ApplyDiscountCode("TestCode");

            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectResult = result as RedirectToActionResult;
            Assert.That(redirectResult.ActionName, Is.EqualTo("Index"));
        }
        //ApplyDiscountCodecoupon is valid ApplyPromotionCouponToCart and UsePromotionCoupon invoked and redirected to index
        [Test]
        public async Task WhenApplyDiscountCodeActionInvoked_PromotionCouponIsValidDiscountApplied()
        {
            var cartId = Guid.NewGuid();
            var promoId = Guid.NewGuid();
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Cookies = new RequestCookieCollectionFake(new Dictionary<string, string> { { "CartId", cartId.ToString() } });
            _shoppingCartService.Setup(m => m.GetPromotionCouponByCode(It.IsAny<string>())).ReturnsAsync(new PromotionCoupon
            {
               PromotionCouponId = promoId
            });
            _shoppingCartService.Setup(m => m.ApplyPromotionCouponToCart(It.IsAny<Guid>(), It.IsAny<Guid>())).Returns(Task.CompletedTask);
            _shoppingCartService.Setup(m => m.UsePromotionCoupon(It.IsAny<Guid>())).Returns(Task.CompletedTask);
            var controller = new ShoppingCartController(_shoppingCartService.Object, _cookieSettings)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };

            var result = await controller.ApplyDiscountCode("TestCode");

            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectResult = result as RedirectToActionResult;
            Assert.That(redirectResult.ActionName, Is.EqualTo("Index"));
        }
    }
}
