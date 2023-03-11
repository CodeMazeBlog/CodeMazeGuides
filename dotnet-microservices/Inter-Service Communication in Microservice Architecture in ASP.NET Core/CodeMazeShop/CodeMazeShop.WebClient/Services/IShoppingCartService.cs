using CodeMazeShop.DataContracts.ShoppingCart;
using CodeMazeShop.WebClient.Models;

namespace CodeMazeShop.WebClient.Services;

public interface IShoppingCartService
{   

    Task<Cart> GetShoppingCart(Guid cartId);    

    Task<string> AddToCart(Guid cartId, Models.CartLineItemForCreation cartLineItem);

    Task UpdateCartLineItem(Guid cartId, Models.CartLineItemForUpdate cartLineItemUpdate);

    Task RemoveLineItem(Guid cartId, Guid cartLineItemId);

    Task ApplyPromotionCouponToCart(Guid cartId, string code);   

    Task Checkout(CartCheckoutViewModel checkoutModel);
}

