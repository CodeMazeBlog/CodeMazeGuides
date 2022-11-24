namespace CodeMazeShop.Web.Models;

public class CartViewModel
{
    public Guid CartId { get; set; }
    public List<CartLineItemViewModel> CartLineItems { get; set; }
    public int ShoppingCartTotal { get; set; }
    public string Code { get; set; }
    public int Discount { get; set; }
}
