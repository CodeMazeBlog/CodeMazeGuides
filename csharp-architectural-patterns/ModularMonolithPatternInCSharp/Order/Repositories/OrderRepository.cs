using Order.Interfaces;
using Order.Models;

namespace Order.Repositories;

internal class OrderRepository : IOrderRepository
{
    private static readonly List<Entities.Order> _orders = [];

    public void Add(OrderDto orderDto)
    {
        var order = new Entities.Order
        {
            Items = orderDto.Items.Select(i => new Entities.OrderItem
            {
                ItemId = i.ItemId,
                Id = i.Id,
                PricePerUnit = i.PricePerUnit,
                Quantity = i.Quantity,
                Total = i.Total,
            }).ToList()
        };

        _orders.Add(order);
    }

    public List<OrderDto> GetAll()
    {
        return _orders.Select(i => i.ToDto()).ToList();
    }
}
