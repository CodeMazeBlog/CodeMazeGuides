using CodeMazeShop.DataContracts.ShoppingCart;
using CodeMazeShop.DataContracts.Discount;
using CodeMazeShop.WebClient.Models;

namespace CodeMazeShop.WebClient.Services;

public interface IShoppingCartService
{
    Task<IEnumerable<CartLineItem>> GetCartLineItemsForCart(Guid cartId);

    Task<Cart> GetShoppingCart(Guid cartId);    

    Task<CartLineItem> AddToCart(Guid cartId, CartLineItemForCreation cartLineItem);

    Task UpdateCartLineItem(Guid cartId, CartLineItemForUpdate cartLineItemUpdate);

    Task RemoveLineItem(Guid cartId, Guid cartLineItemId);

    Task ApplyPromotionCouponToCart(Guid cartId, Guid couponId);

    Task<PromotionCoupon> GetPromotionCoupon(Guid couponId);

    Task<PromotionCoupon> GetPromotionCouponByCode(string code);
    
    Task UsePromotionCoupon(Guid couponId);

    Task Checkout(CartCheckoutViewModel checkoutModel);
}

