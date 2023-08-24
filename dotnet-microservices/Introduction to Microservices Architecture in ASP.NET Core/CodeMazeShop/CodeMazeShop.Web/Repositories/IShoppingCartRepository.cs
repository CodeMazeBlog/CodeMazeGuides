using CodeMazeShop.Web.Entities;

namespace CodeMazeShop.Web.Repositories;

public interface IShoppingCartRepository
{
    Task<IEnumerable<CartLineItem>> GetCartLineItemsForCart(Guid cartId);

    Task<Cart> GetCart(Guid cartId);    

    Task<Cart> CreateCart(Guid userId);

    Task<CartLineItem> AddCartLineItemToCart(CartLineItem cartLineItem);

    Task UpdateCartLineItem(Guid cartId, CartLineItem updatedLineItem);

    Task RemoveLineItem(Guid cartId, Guid cartLineItemId);

    Task ApplyCouponToCart(Guid cartId, Guid couponId);

    Task<PromotionCoupon> GetCouponById(Guid couponId);

    Task<PromotionCoupon> GetCouponByCode(string code);

    Task UsePromotionCoupon(Guid couponId);
}
