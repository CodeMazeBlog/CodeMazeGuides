using CodeMazeShop.DataContracts.Ordering;

namespace CodeMazeShop.WebClient.Services;

public class OrderService : IOrderService
{    

    public OrderService()
    {
        
    }

    public Task CreateOrder(Order order) 
        => throw new NotImplementedException();

    public Task<Order> GetOrderDetails(Guid orderId) 
        => throw new NotImplementedException();

    public Task<List<Order>> GetOrdersForUser(Guid userId) 
        => throw new NotImplementedException();

    public Task UpdateOrderStatus(Guid orderId, bool isPaymentComplted) 
        => throw new NotImplementedException();

}
