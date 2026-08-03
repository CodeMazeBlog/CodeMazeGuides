using Order.Models;

namespace Order.Entities;

internal class OrderItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ItemId { get; set; }
    public int Quantity { get; set; }
    public double PricePerUnit { get; set; }
    public double Total { get; set; }

    public OrderItemDto ToDto()
    {
        return new OrderItemDto
        {
            Id = Id,
            ItemId = ItemId,
            Quantity = Quantity,
            PricePerUnit = PricePerUnit,
            Total = Total
        };
    }
}
