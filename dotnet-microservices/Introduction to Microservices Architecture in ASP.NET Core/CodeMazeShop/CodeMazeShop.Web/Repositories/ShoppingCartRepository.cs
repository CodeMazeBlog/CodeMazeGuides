using CodeMazeShop.Web.Entities;

namespace CodeMazeShop.Web.Repositories;

public class ShoppingCartRepository : IShoppingCartRepository
{
    private readonly Dictionary<Guid, Cart> _carts = new();
    private readonly Dictionary<Guid, CartLineItem> _cartLineItems = new();
    private readonly Dictionary<Guid, PromotionCoupon> _coupons = new();
    private Random _rnd = new();
    public ShoppingCartRepository()
    {
        InitializeCartData();
    }

    public Task<CartLineItem> AddCartLineItemToCart(CartLineItem cartLineItem)
    {
        cartLineItem.CartLineItemId = Guid.NewGuid();
        if(_carts.TryGetValue(cartLineItem.CartId, out var cart))
        {            
            _cartLineItems.Add(cartLineItem.CartLineItemId, cartLineItem);
            cart.NumberOfItems++;
        }

        return Task.FromResult(cartLineItem);
    }

    public Task<Cart> CreateCart(Guid userId)
    {
        var cart = new Cart
        {
            CartId = Guid.NewGuid(),
            UserId = userId,
        };
        _carts.Add(cart.CartId, cart);

        return Task.FromResult(cart);
    }

    public async Task<Cart> GetCart(Guid cartId)
        => await Task.FromResult(_carts.GetValueOrDefault(cartId));

    public async Task<IEnumerable<CartLineItem>> GetCartLineItemsForCart(Guid cartId) 
        => await Task.FromResult(_cartLineItems.Values.Where(c => c.CartId == cartId)); 
    
    public Task RemoveLineItem(Guid cartId, Guid cartLineItemId)
    {
        if (_carts.TryGetValue(cartId, out var cart) && _cartLineItems.TryGetValue(cartLineItemId, out _))
        {
           _cartLineItems.Remove(cartLineItemId);
            cart.NumberOfItems--;
        }

        return Task.CompletedTask;
    }

    public Task UpdateCartLineItem(Guid cartId, CartLineItem updatedLineItem)
    {
        if (_carts.TryGetValue(cartId, out _) && _cartLineItems.TryGetValue(updatedLineItem.CartLineItemId, out var existingCartLineItem))
        {    
            existingCartLineItem.Quantity = updatedLineItem.Quantity;                        
        }

        return Task.CompletedTask;
    }

    public Task ApplyCouponToCart(Guid cartId, Guid couponId)
    {
        if(_carts.TryGetValue(cartId, out var cart))
        {
            cart.PromotionCouponId = couponId;
        }

        return Task.CompletedTask;
    }

    public async Task<PromotionCoupon> GetCouponById(Guid couponId)
        => await Task.FromResult(_coupons.GetValueOrDefault(couponId));

    public async Task<PromotionCoupon> GetCouponByCode(string code)
        => await Task.FromResult(_coupons.Values.FirstOrDefault(c => c.Code == code));

    public Task UsePromotionCoupon(Guid couponId)
    {
        if(_coupons.TryGetValue(couponId, out var coupon))
        {
            coupon.IsAlreadyUsed = true;
        }

        return Task.CompletedTask;
    }

    private void InitializeCartData()
    {
        for (int i = 0; i < 3; i++)
        {
            var couponId = Guid.NewGuid();
            _coupons.Add(couponId, new PromotionCoupon
            {
                PromotionCouponId = couponId,
                Code = $"TestCoupon{i + 1}",
                Amount = _rnd.Next(1,10),
                IsAlreadyUsed = false
            });
        }  
    }
}