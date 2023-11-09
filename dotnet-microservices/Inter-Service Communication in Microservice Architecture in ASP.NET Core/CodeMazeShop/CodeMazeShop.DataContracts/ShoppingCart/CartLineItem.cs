namespace CodeMazeShop.DataContracts.ShoppingCart;

public class CartLineItem
{
    public Guid CartLineItemId { get; set; }

    public int Quantity { get; set; }
    
    public int Price { get; set; }
    
    public Product Product { get; set; }
}
