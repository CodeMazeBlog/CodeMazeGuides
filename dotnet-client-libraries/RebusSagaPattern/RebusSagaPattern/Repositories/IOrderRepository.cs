using RebusSagaPattern.Models;

namespace RebusSagaPattern.Repositories;

public interface IOrderRepository
{
    Order GetOrderById(Guid orderId);
    void AddOrder(Order order);
}