using CodeMazeShop.Web.Entities;
using CodeMazeShop.Web.Extensions;
using CodeMazeShop.Web.Models;
using CodeMazeShop.Web.Services;
using Microsoft.AspNetCore.Mvc;
using NuGet.Configuration;

namespace CodeMazeShop.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly CookieSettings _cookieSettings;

        public ShoppingCartController(IShoppingCartService shoppingCartService, CookieSettings cookieSettings)
        {
            _shoppingCartService = shoppingCartService;
            _cookieSettings = cookieSettings;
        }

        public async Task<IActionResult> Index()
        {
            var cartViewModel = await CreateCartViewModel();
            return View(cartViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCartLineItem(CartLineItemForCreation cartLineItem)
        {
            var cartId = Request.Cookies.GetCurrentCartId(_cookieSettings);
            var newLineItem = await _shoppingCartService.AddToCart(cartId, cartLineItem);
            Response.Cookies.Append(_cookieSettings.CartIdCookieName, newLineItem.CartId.ToString());

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateLineItem(CartLineItemForUpdate cartLineItemUpdate)
        {
            var cartId = Request.Cookies.GetCurrentCartId(_cookieSettings);
            await _shoppingCartService.UpdateCartLineItem(cartId, cartLineItemUpdate);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveLineItem(Guid cartLineItemId)
        {
            var cartId = Request.Cookies.GetCurrentCartId(_cookieSettings);
            await _shoppingCartService.RemoveLineItem(cartId, cartLineItemId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApplyDiscountCode(string code)
        {
            var coupon = await _shoppingCartService.GetPromotionCouponByCode(code);

            if (coupon == null || coupon.IsAlreadyUsed) 
            {
                return RedirectToAction("Index");
            } 

            //coupon will be applied to the basket
            var cartId = Request.Cookies.GetCurrentCartId(_cookieSettings);
            await _shoppingCartService.ApplyPromotionCouponToCart(cartId, coupon.PromotionCouponId);
            await _shoppingCartService.UsePromotionCoupon(coupon.PromotionCouponId);

            return RedirectToAction("Index");
        }

        public IActionResult Checkout() 
            => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(CartCheckoutViewModel cartCheckoutViewModel)
        {
            try
            {                
                if (ModelState.IsValid)
                {
                    var cartId = Request.Cookies.GetCurrentCartId(_cookieSettings);
                    cartCheckoutViewModel.CartId = cartId;
                    cartCheckoutViewModel.UserId = _cookieSettings.UserId;

                    await _shoppingCartService.Checkout(cartCheckoutViewModel);


                    return RedirectToAction("CheckoutComplete");
                }

                return View(cartCheckoutViewModel);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View(cartCheckoutViewModel);
            }
        }

        public IActionResult CheckoutComplete()
        {
            return View();
        }

        private async Task<CartViewModel> CreateCartViewModel()
        {
            var cartId = Request.Cookies.GetCurrentCartId(_cookieSettings);
            if (cartId == Guid.Empty)
            {
                return new CartViewModel();
            }
            
            var cart = await _shoppingCartService.GetShoppingCart(cartId);

            var cartLineItems = await _shoppingCartService.GetCartLineItemsForCart(cartId);

            var cartLineItemViewModels = cartLineItems.Select(cli => new CartLineItemViewModel
            {
                CartLineItemId = cli.CartLineItemId,
                ProductId = cli.ProductId,
                ProductName = cli.Product.Name,               
                Price = cli.Price,
                Quantity = cli.Quantity
            });


            var cartViewModel = new CartViewModel
            {
                CartId = cart.CartId,
                CartLineItems = cartLineItemViewModels.ToList()
            };

            PromotionCoupon coupon = null;

            if (cart.PromotionCouponId.HasValue)
                coupon = await _shoppingCartService.GetPromotionCoupon(cart.PromotionCouponId.Value);

            if (coupon != null)
            {
                cartViewModel.Code = coupon.Code;
                cartViewModel.Discount = coupon.Amount;
            }

            cartViewModel.ShoppingCartTotal = cartViewModel.CartLineItems?.Sum(cli => cli.Price * cli.Quantity) ?? 0;

            return cartViewModel;
        }
    }
}