using CodeMazeShop.Services.Ordering.Entities;

namespace CodeMazeShop.Services.Ordering.Repositories;

public interface IOrderRepository
{
    Task<List<Order>> GetOrdersForUser(string userId);

    Task<Order> GetOrderDetails(string orderId);

    Task CreateOrder(Order order);

    Task UpdateOrderStatus(string orderId, bool isPaymentComplted);
}
