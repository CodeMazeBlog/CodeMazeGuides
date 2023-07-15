using Microsoft.AspNetCore.Http.HttpResults;
using OneOf;
using OneOf.Types;

namespace API;

public class OrdersService : IOrdersService
{
    private List<Product> _products;
    private List<Receipt> _receipts;
    private int _receiptId;

    public OrdersService()
    {
        _products = new List<Product>
        {
            new Product(1, "Keyboard", 80),
            new Product(2, "Mouse", 50),
            new Product(3, "Monitor", 500)
        };

        _receipts = new List<Receipt>();
    }      

    public OneOf<Receipt, PlaceOrderError> PlaceOrder(Order order)
    {
        var product = _products.SingleOrDefault(p => p.ProductId == order.ProductId);
        
        if (product is null)
        {
            return PlaceOrderError.DoesntExist;
        }

        if (product.Cost > order.Payment)
        {
            return PlaceOrderError.InsufficientFunds;
        }

        var receipt = new Receipt(++_receiptId, order.Payment);
        _receipts.Add(receipt);

        return receipt;
    }

    public OneOf<Product, OneOf.Types.NotFound> FindProduct(OneOf<string, int> productNameOrId)
    {
        Product? product;

        if (productNameOrId.IsT0)
        {
            product = _products.SingleOrDefault(product => product.Name.Equals(productNameOrId.AsT0));
        }
        else
        {
            product = _products.SingleOrDefault(product => product.ProductId == productNameOrId.AsT1);
        }

        return product is null
            ? new OneOf.Types.NotFound()
            : product;
    }
}
