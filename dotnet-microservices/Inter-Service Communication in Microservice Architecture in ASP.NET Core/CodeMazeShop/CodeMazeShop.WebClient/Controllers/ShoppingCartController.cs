using CodeMazeShop.WebClient.Extensions;
using CodeMazeShop.WebClient.Models;
using CodeMazeShop.WebClient.Services;
using Microsoft.AspNetCore.Mvc;


namespace CodeMazeShop.WebClient.Controllers
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
            var responseCartId = await _shoppingCartService.AddToCart(cartId, cartLineItem);
            Response.Cookies.Append(_cookieSettings.CartIdCookieName, responseCartId);

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
            var cartId = Request.Cookies.GetCurrentCartId(_cookieSettings);
            await _shoppingCartService.ApplyPromotionCouponToCart(cartId, code);            

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

                    Response.Cookies.Delete(_cookieSettings.CartIdCookieName);
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
           

            var cartLineItemViewModels = cart.LineItems.Select(cli => new CartLineItemViewModel
            {
                CartLineItemId = cli.CartLineItemId,
                ProductId = cli.Product.ProductId,
                ProductName = cli.Product.Name,               
                Price = cli.Price,
                Quantity = cli.Quantity
            });

            var cartViewModel = new CartViewModel
            {
                CartId = cart.CartId,
                CartLineItems = cartLineItemViewModels.ToList(),
                Code= cart.Code,
                Discount = cart.Discount,
                ShoppingCartTotal= cart.ShoppingCartTotal
            };           

            return cartViewModel;
        }
    }
}