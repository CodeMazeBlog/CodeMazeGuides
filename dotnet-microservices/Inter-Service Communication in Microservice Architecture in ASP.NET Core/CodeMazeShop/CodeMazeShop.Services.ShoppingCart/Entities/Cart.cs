namespace CodeMazeShop.Services.ShoppingCart.Entities; 

public class Cart 
{ 
    public string CartId { get; set; }

    public List<CartLineItem> LineItems { get; set; } = new List<CartLineItem>();

    public string PromotionCouponId { get; set; }
}
