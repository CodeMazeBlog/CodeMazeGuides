using System.Text.Json;
using CodeMazeShop.Services.ShoppingCart.Entities;
using Microsoft.Extensions.Caching.Distributed;

namespace CodeMazeShop.Services.ShoppingCart.Repositories;

public class ShoppingCartRepository : IShoppingCartRepository
{
    private readonly IDistributedCache _redisCache;
    private const string CartKey = "Cart:";

    public ShoppingCartRepository(IDistributedCache redisCache)
    {
        _redisCache = redisCache;
    }

    public async Task<Cart?> GetCart(string cartId)
    {
        var cartAsString = await _redisCache.GetStringAsync($"{CartKey}{cartId}");

        if (string.IsNullOrEmpty(cartAsString))
        {
            return null;
        }

        return  JsonSerializer.Deserialize<Cart>(cartAsString);
        
    }

    public async Task AddCartLineItem(string cartId, CartLineItem cartLineItem)
    {      
        var cart = await GetCart(cartId);

        if(cart is null)
        {
            cart = new Cart
            {
                CartId = cartId
            };                 
        }

        cart.LineItems.Add(cartLineItem);

        await SaveCartInRedisStore(cart);       
    }

    public async Task<bool> UpdateLineItem(string cartId, CartLineItem updateLineItem)
    {
        var cart = await GetCart(cartId);

        if (cart is null)
        {
            return false;
        }

        var existingLineItem = cart.LineItems.FirstOrDefault(li => li.CartLineItemId== updateLineItem.CartLineItemId);
        if(existingLineItem is null) 
        {
            return false;
        }

        existingLineItem.Quantity = updateLineItem.Quantity;
        
        await SaveCartInRedisStore(cart);

        return true;
    }

    public async Task<bool> RemoveLineItem(string cartId, string cartLineItemId)
    {
        var cart = await GetCart(cartId);

        if (cart is null)
        {
            return false;
        }

        var existingLineItem = cart.LineItems.FirstOrDefault(li => li.CartLineItemId == cartLineItemId);
        if (existingLineItem is null)
        {
            return false;
        }

        cart.LineItems.Remove(existingLineItem);

        if(cart.LineItems.Count < 1) 
        {
            await RemoveCartFromRedisStore(cartId);
            return true;
        }

        await SaveCartInRedisStore(cart);

        return true;
    }

    public async Task ApplyPromotionCouponToCart(string cartId, string couponId)
    {
        var cart = await GetCart(cartId);

        if (cart is not null)
        {
            cart.PromotionCouponId = couponId;

            await SaveCartInRedisStore(cart);
        }
    }

    public async Task RemoveCartFromRedisStore(string cartId) => await _redisCache.RemoveAsync(GetCartKey(cartId));

    private string GetCartKey(string cartId) => $"{CartKey}{cartId}";

    private async Task SaveCartInRedisStore(Cart cart) => await _redisCache.SetStringAsync(GetCartKey(cart.CartId), JsonSerializer.Serialize(cart));

    
}