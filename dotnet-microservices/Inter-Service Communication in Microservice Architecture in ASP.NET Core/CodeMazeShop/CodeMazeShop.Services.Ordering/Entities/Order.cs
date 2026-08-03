namespace CodeMazeShop.Services.Ordering.Entities;

public class Order
{
    public string OrderId { get; set; }

    public string UserId { get; set; }   

    public int OrderTotal { get; set; }

    public DateTime OrderPlaced { get; set; }

    public bool OrderPaid { get; set; }

    //Navigation Properties
    public ICollection<OrderLineItem> LineItems { get; set; } = new List<OrderLineItem>();

    public ShippingDetails ShippingDetails { get; set; }
}