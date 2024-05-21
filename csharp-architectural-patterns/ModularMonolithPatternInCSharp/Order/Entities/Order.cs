using Order.Models;

namespace Order.Entities;

internal class Order
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public List<OrderItem> Items { get; set; } = [];

    public OrderDto ToDto()
    {
        return new OrderDto
        {
            Id = Id,
            Items = Items.Select(x => x.ToDto()).ToList(),
            Total = Items.Sum(x => x.Total)
        };
    }
}
