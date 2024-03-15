namespace CodeMazeShop.Services.ShoppingCart.Entities; 

public class CartLineItem 
{
    public string CartLineItemId { get; set; }

    public int Quantity { get; set; }

    public int Price { get; set; }

    public Product Product { get; set; }
}
