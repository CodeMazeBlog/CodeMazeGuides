using SagaPattern.Models;

namespace SagaPattern.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderById(Guid orderId);
        Task AddOrder(Order order);
    }
}
