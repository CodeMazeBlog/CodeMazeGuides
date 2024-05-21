using Order.Models;

namespace Order.Interfaces;

public interface IOrderService
{
    Task AddAsync(OrderDto orderDto);
    Task<List<OrderDto>> GetAllAsync();
}
