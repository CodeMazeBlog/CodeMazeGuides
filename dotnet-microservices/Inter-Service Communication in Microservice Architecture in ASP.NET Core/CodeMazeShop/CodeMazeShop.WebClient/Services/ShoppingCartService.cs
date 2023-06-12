using CodeMazeShop.DataContracts.ShoppingCart;
using CodeMazeShop.Utilities.Extensions;
using DataContract = CodeMazeShop.DataContracts.ShoppingCart;
namespace CodeMazeShop.WebClient.Services;

public class ShoppingCartService : IShoppingCartService
{
    private readonly HttpClient _httpClient;
    

    public ShoppingCartService(HttpClient httpClient)
    {
        _httpClient = httpClient;        
    }

    public async Task<DataContract.Cart> GetShoppingCart(Guid cartId) 
    {
        var response = await _httpClient.GetAsync($"api/shoppingcart/{cartId}");
        return await response.ReadContentAs<DataContract.Cart>();
    }

    public async Task<string> AddToCart(Guid cartId, Models.CartLineItemForCreation cartLineItem)
    {        
        var cartLineItemForCreation = new DataContract.CartLineItemForCreation
        {
            CartId = cartId,
            ProductId = cartLineItem.ProductId,
            Price = cartLineItem.Price,
            Quantity = cartLineItem.Quantity            
        };

        var response = await _httpClient.PostAsJsonAsync("api/shoppingcart/add", cartLineItemForCreation);
        return (await response.Content.ReadAsStringAsync()).Trim(new Char[] { '"'});
    }

    public async Task UpdateCartLineItem(Guid cartId, Models.CartLineItemForUpdate cartLineItemUpdate)
    {
        var cartLineItemForUpdate = new DataContract.CartLineItemForUpdate
        {
            CartId = cartId,
            CartLineItemId = cartLineItemUpdate.CartLineItemId,
            Quantity = cartLineItemUpdate.Quantity            
        };

        await _httpClient.PutAsJsonAsync("api/shoppingcart/add", cartLineItemForUpdate);
    }

    public async Task RemoveLineItem(Guid cartId, Guid cartLineItemId) 
        => await _httpClient.DeleteAsync($"api/shoppingcart/{cartId}/remove/{cartLineItemId}");
    
    public async Task ApplyPromotionCouponToCart(Guid cartId, string code) 
        => await _httpClient.PostAsJsonAsync("api/shoppingcart/apply-discount", new DiscountCodeRequest { CartId = cartId, Code = code });

    public async Task Checkout(Models.CartCheckoutViewModel checkoutModel)
    {
        var checkoutRequest = new CheckoutRequest
        {
            CartId = checkoutModel.CartId,
            UserId = checkoutModel.UserId,
            FirstName = checkoutModel.FirstName,
            LastName = checkoutModel.LastName,
            Address = checkoutModel.Address,
            City = checkoutModel.City,
            Country = checkoutModel.Country,
            ZipCode = checkoutModel.ZipCode,
            Email = checkoutModel.Email,
            CardName = checkoutModel.CardName,
            CardNumber = checkoutModel.CardNumber,
            CardExpiration = checkoutModel.CardExpiration,
            CvvCode = checkoutModel.CvvCode
        };

        await _httpClient.PostAsJsonAsync("api/shoppingcart/checkout", checkoutRequest);
    }
}
