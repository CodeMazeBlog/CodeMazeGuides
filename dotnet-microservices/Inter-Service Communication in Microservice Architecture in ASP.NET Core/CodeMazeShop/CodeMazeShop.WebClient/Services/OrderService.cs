using CodeMazeShop.DataContracts.Ordering;
using CodeMazeShop.Utilities.Extensions;

namespace CodeMazeShop.WebClient.Services;

public class OrderService : IOrderService
{
    private readonly HttpClient _httpClient;

    public OrderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }   

    public async Task<List<Order>> GetOrdersForUser(Guid userId)
    {        
            var response = await _httpClient.GetAsync($"/api/orders/?userId={userId}");
            return await response.ReadContentAs<List<Order>>();        
    }
}
