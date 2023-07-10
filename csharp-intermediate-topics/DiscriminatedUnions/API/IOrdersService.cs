using OneOf;
using OneOf.Types;

namespace API;

public interface IOrdersService
{
    OneOf<Receipt, PlaceOrderError> PlaceOrder(Order order);
    OneOf<Product, NotFound> FindProduct(OneOf<string, int> productNameOrId);
}
