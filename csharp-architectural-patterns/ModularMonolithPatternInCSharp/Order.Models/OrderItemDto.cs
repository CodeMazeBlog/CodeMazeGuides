namespace Order.Models;

public class OrderItemDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ItemId { get; set; }
    public string ItemName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public double PricePerUnit { get; set; }
    public double Total { get; set; }
}
