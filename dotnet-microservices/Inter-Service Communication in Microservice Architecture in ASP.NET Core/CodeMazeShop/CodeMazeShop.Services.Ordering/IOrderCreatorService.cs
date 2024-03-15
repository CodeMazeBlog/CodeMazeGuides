using CodeMazeShop.Integration.Messages;

namespace CodeMazeShop.Services.Ordering;

public interface IOrderCreatorService
{
    Task<Guid> CreateOrder(CartCheckoutMessage cartCheckoutMessage);
}
