using CodeMazeShop.Web.Entities;

namespace CodeMazeShop.Web.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly Dictionary<Guid, Order> _orders = new();

    public Task CreateOrder(Order order)
    {
        _orders.Add(order.OrderId, order);
        return Task.CompletedTask;
    }   

    public async Task<Order> GetOrderDetails(Guid orderId) 
        => await Task.FromResult(_orders.GetValueOrDefault(orderId));

    public async Task<List<Order>> GetOrdersForUser(Guid userId) => 
        await Task.FromResult(_orders.Values.Where(o => o.UserId == userId).ToList());

    public Task UpdateOrderStatus(Guid orderId, bool isPaymentComplted)
    {
        if(_orders.TryGetValue(orderId, out var order))
        {
            order.OrderPaid = isPaymentComplted;
        }

        return Task.CompletedTask;
    }
}