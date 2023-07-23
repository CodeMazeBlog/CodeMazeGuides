namespace CodeMazeShop.Web.Models;

public class CartLineItemViewModel
{
    public Guid CartLineItemId { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }   
    public int Price { get; set; }
    public int Quantity { get; set; }
}
