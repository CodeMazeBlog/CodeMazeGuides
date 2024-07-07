using RebusSagaPattern.Models;

namespace RebusSagaPattern.Repositories;

public interface IOrderRepository
{
    Task<Order> GetOrderById(Guid orderId);
    Task AddOrder(Order order);
}