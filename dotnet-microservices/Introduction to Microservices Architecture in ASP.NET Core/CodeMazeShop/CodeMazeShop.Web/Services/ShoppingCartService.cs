using CodeMazeShop.Web.Entities;
using CodeMazeShop.Web.Models;
using CodeMazeShop.Web.Repositories;

namespace CodeMazeShop.Web.Services;

public class ShoppingCartService : IShoppingCartService
{
    private readonly IShoppingCartRepository _shoppingCartRepository;
    private readonly IProductCatalogRepository _productCatalogRepository;
    private readonly IOrderService _orderService;
    private readonly IPaymentService _paymentService;
    private readonly CookieSettings _cookieSettings;

    public ShoppingCartService(IShoppingCartRepository shoppingCartRepository, 
                               IProductCatalogRepository productCatalogRepository, 
                               CookieSettings cookieSettings, 
                               IOrderService orderService, 
                               IPaymentService paymentService)
    {
        _shoppingCartRepository = shoppingCartRepository;
        _cookieSettings = cookieSettings;
        _productCatalogRepository = productCatalogRepository;
        _orderService = orderService;
        _paymentService = paymentService;
    }

    public async Task<IEnumerable<CartLineItem>> GetCartLineItemsForCart(Guid cartId)
    { 
        var cartLineItems = await _shoppingCartRepository.GetCartLineItemsForCart(cartId);
        foreach (var lineItem in cartLineItems)
        {
            lineItem.Product = await _productCatalogRepository.GetProduct(lineItem.ProductId);
        }

        return cartLineItems;
    }

    public Task<Cart> GetShoppingCart(Guid cartId) 
        => _shoppingCartRepository.GetCart(cartId);   

    public async Task<CartLineItem> AddToCart(Guid cartId, CartLineItemForCreation cartLineItem)
    {
        if(cartId == Guid.Empty || (await _shoppingCartRepository.GetCart(cartId) is null))
        {
            var cart = await _shoppingCartRepository.CreateCart(_cookieSettings.UserId);
            cartId = cart.CartId;
        }

        return await _shoppingCartRepository.AddCartLineItemToCart(await GetCartLineItem());

        async Task<CartLineItem> GetCartLineItem()
        => new CartLineItem
        {            
            CartId = cartId,
            Price = cartLineItem.Price,
            Quantity = cartLineItem.Quantity,
            ProductId = cartLineItem.ProductId,
            Product = await _productCatalogRepository.GetProduct(cartLineItem.ProductId)
        };
    }

    public async Task UpdateCartLineItem(Guid cartId, CartLineItemForUpdate cartLineItemUpdate) 
        => await _shoppingCartRepository.UpdateCartLineItem(cartId, new CartLineItem
           {
               CartLineItemId = cartLineItemUpdate.CartLineItemId,
               Quantity = cartLineItemUpdate.Quantity
           });

    public Task RemoveLineItem(Guid cartId, Guid cartLineItemId) 
        => _shoppingCartRepository.RemoveLineItem(cartId, cartLineItemId);

    public Task ApplyPromotionCouponToCart(Guid cartId, Guid couponId) 
        => _shoppingCartRepository.ApplyCouponToCart(cartId, couponId);     

    public Task<PromotionCoupon> GetPromotionCoupon(Guid couponId)
       => _shoppingCartRepository.GetCouponById(couponId);

    public Task<PromotionCoupon> GetPromotionCouponByCode(string code) 
        => _shoppingCartRepository.GetCouponByCode(code);    

    public Task UsePromotionCoupon(Guid couponId) 
        => _shoppingCartRepository.UsePromotionCoupon(couponId);

    public async Task Checkout(CartCheckoutViewModel checkoutModel)
    {
        //Get current cart and cart line items also get coupon and calculate OrderTotal
        var cart = await GetShoppingCart(checkoutModel.CartId);

        var cartLineItems = await GetCartLineItemsForCart(checkoutModel.CartId);

        PromotionCoupon coupon = null;

        if (cart.PromotionCouponId.HasValue)
            coupon = await GetPromotionCoupon(cart.PromotionCouponId.Value);

        var cartLineTotal = cartLineItems?.Sum(cli => cli.Price * cli.Quantity) ?? 0;

        var orderTotal = cartLineTotal == 0 ? 0 : cartLineTotal - (coupon?.Amount ?? 0);

        //Create Order
        var orderId = Guid.NewGuid();
        await _orderService.CreateOrder(new Order
        {
            OrderId = orderId,
            UserId = checkoutModel.UserId,
            OrderPaid = false,
            OrderPlaced = DateTime.UtcNow,
            OrderTotal = orderTotal
        });

        //Complete Payment
        var isPaymentSuccessful = await _paymentService.MakePayment(orderId, new PaymentInfo
        {
            CardExpiration = checkoutModel.CardExpiration,
            CardName = checkoutModel.CardName,
            CardNumber = checkoutModel.CardNumber,
            Total = orderTotal
        });

        //Update Order Payment Status
        await _orderService.UpdateOrderStatus(orderId, isPaymentSuccessful);
    }
}
