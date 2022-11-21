using CodeMazeShop.Web.Entities;
using CodeMazeShop.Web.Repositories;

namespace CodeMazeShop.Web.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public Task CreateOrder(Order order) 
        => _orderRepository.CreateOrder(order);    

    public Task<Order> GetOrderDetails(Guid orderId) 
        => _orderRepository.GetOrderDetails(orderId);    

    public Task<List<Order>> GetOrdersForUser(Guid userId) 
        => _orderRepository.GetOrdersForUser(userId);

    public Task UpdateOrderStatus(Guid orderId, bool isPaymentComplted) 
        => _orderRepository.UpdateOrderStatus(orderId, isPaymentComplted);
    
}
