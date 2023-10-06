using LocalFunctionInCSharp;

var cart = new ShoppingCart
{
    Products = new List<Product>
            {
                new Product { Name = "Product A", StockQuantity = 10, SelectedQuantity = 2 },
                new Product { Name = "Product B", StockQuantity = 11, SelectedQuantity = 5 }
            }
};

if (cart.Checkout())
{
    Console.WriteLine("Checkout successful.");
}
else
{
    Console.WriteLine("Checkout failed due to validation errors.");
}