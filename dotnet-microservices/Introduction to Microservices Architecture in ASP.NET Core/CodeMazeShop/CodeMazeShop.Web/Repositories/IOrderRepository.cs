using CodeMazeShop.Web.Entities;

namespace CodeMazeShop.Web.Repositories;

public interface IOrderRepository
{
    Task<List<Order>> GetOrdersForUser(Guid userId);

    Task<Order> GetOrderDetails(Guid orderId);

    Task CreateOrder(Order order);

    Task UpdateOrderStatus(Guid orderId, bool isPaymentComplted);
}
