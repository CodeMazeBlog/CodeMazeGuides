using Microsoft.Extensions.Logging;

namespace CodeMazeShop.Web.Entities;

public class CartLineItem
{
    public Guid CartLineItemId { get; set; }
    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public int Price { get; set; }
    public Product Product { get; set; }
}
