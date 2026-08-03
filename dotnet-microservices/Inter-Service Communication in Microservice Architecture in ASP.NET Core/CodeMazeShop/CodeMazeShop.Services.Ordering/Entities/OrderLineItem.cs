namespace CodeMazeShop.Services.Ordering.Entities;

public class OrderLineItem
{
    public string OrderLineItemId { get; set; }    

    public int Quantity { get; set; }

    public int Price { get; set; }

    public string ProductId { get; set; }

    //Navigation properties
    public string OrderId { get; set; }

    public Order Order { get; set; }
}