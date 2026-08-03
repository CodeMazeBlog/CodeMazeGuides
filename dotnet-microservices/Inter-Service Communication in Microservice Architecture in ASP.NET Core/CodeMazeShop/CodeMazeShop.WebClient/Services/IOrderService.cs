using CodeMazeShop.DataContracts.Ordering;

namespace CodeMazeShop.WebClient.Services;

public interface IOrderService
{
    Task<List<Order>> GetOrdersForUser(Guid userId);   
}
