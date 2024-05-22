namespace Order.Models;

public class OrderDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public double Total { get; set; }
    public List<OrderItemDto> Items { get; set; } = [];
}
