namespace CodeMazeShop.DataContracts.ShoppingCart;

public class DiscountCodeRequest
{
    public Guid CartId { get; set; }

    public string Code { get; set; }
}