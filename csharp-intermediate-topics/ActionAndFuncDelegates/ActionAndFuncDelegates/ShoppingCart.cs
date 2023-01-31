public class ShoppingCart
{
    private List<Product> products = new List<Product>();

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public void RemoveProduct(Product product)
    {
        products.Remove(product);
    }

    public void LogCartContents(Action<List<Product>> logFunction)
    {
        logFunction(products);
    }

    public decimal GetTotalPrice(Func<List<Product>, decimal> totalPriceFunction)
    {
        return totalPriceFunction(products);
    }
}