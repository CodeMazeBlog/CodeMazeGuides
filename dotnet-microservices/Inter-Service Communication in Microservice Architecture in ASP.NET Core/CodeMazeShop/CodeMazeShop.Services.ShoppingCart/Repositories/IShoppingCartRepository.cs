using CodeMazeShop.Services.ShoppingCart.Entities;

namespace CodeMazeShop.Services.ShoppingCart.Repositories;

public interface IShoppingCartRepository
{
    Task<Cart?> GetCart(string cartId);

    Task AddCartLineItem(string cartId, CartLineItem cartLineItem);

    Task<bool> UpdateLineItem(string cartId, CartLineItem updateLineItem);

    Task<bool> RemoveLineItem(string cartId, string cartLineItemId);

    Task ApplyPromotionCouponToCart(string cartId, string couponId);

    Task RemoveCartFromRedisStore(string cartId);
}
