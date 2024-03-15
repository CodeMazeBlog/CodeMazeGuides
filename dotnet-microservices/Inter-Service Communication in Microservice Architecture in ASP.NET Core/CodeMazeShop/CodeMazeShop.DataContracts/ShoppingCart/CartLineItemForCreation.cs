namespace CodeMazeShop.DataContracts.ShoppingCart;

public class CartLineItemForCreation
{
    public Guid CartId { get; set; }

    public Guid ProductId { get; set; }
    
    public int Quantity { get; set; }
    
    public int Price { get; set; }
}
