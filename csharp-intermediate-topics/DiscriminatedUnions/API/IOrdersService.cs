using OneOf;

namespace API;

public interface IOrdersService
{
    OneOf<Receipt, PlaceOrderError> PlaceOrder(Order order);
    Product? FindProduct(OneOf<string, int> productNameOrId);
}
