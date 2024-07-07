namespace RebusSagaPattern.Models;

public class Order
{
    public Guid OrderId { get; set; }
    public OrderStatus Status { get; set; }
}