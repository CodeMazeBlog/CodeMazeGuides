using Order.Models;

namespace Order.Interfaces;

public interface IOrderRepository
{
    void Add(OrderDto orderDto);
    List<OrderDto> GetAll();
}
