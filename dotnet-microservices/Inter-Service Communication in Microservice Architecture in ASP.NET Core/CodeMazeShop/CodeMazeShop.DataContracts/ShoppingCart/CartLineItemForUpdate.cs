namespace CodeMazeShop.DataContracts.ShoppingCart;

public class CartLineItemForUpdate
{
    public Guid CartId { get; set; }

    public Guid CartLineItemId { get; set; }

    public int Quantity { get; set; }
}
