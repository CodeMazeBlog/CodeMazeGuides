using CodeMazeShop.DataContracts.ShoppingCart;
using CodeMazeShop.DataContracts.Discount;
using CodeMazeShop.WebClient.Models;


namespace CodeMazeShop.WebClient.Services;

public class ShoppingCartService : IShoppingCartService
{
   
    public ShoppingCartService()
    {
       
    }

    public async Task<IEnumerable<CartLineItem>> GetCartLineItemsForCart(Guid cartId)
    {
        throw new NotImplementedException();
    }

    public Task<Cart> GetShoppingCart(Guid cartId) 
        => throw new NotImplementedException();

    public async Task<CartLineItem> AddToCart(Guid cartId, CartLineItemForCreation cartLineItem)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateCartLineItem(Guid cartId, CartLineItemForUpdate cartLineItemUpdate) 
        => throw new NotImplementedException();

    public Task RemoveLineItem(Guid cartId, Guid cartLineItemId) 
        => throw new NotImplementedException();

    public Task ApplyPromotionCouponToCart(Guid cartId, Guid couponId) 
        => throw new NotImplementedException();

    public Task<PromotionCoupon> GetPromotionCoupon(Guid couponId)
       => throw new NotImplementedException();

    public Task<PromotionCoupon> GetPromotionCouponByCode(string code) 
        => throw new NotImplementedException();

    public Task UsePromotionCoupon(Guid couponId) 
        => throw new NotImplementedException();

    public async Task Checkout(CartCheckoutViewModel checkoutModel)
    {
        throw new NotImplementedException();
    }
}
