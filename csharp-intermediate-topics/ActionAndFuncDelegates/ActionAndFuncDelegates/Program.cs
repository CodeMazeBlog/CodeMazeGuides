ShoppingCart cart = new ShoppingCart();
cart.AddProduct(new Product { Name = "Apple", Price = 0.25m });
cart.AddProduct(new Product { Name = "Banana", Price = 0.35m });
cart.AddProduct(new Product { Name = "Carrot", Price = 0.15m });

cart.LogCartContents(LogCartToConsole);

decimal totalPrice = cart.GetTotalPrice(GetTotalPriceWithoutDiscount);
Console.WriteLine("Total price: " + totalPrice);

void LogCartToConsole(List<Product> products)
{
    Console.WriteLine("Cart contains: " + string.Join(", ", products.Select(p => p.Name)));
}

decimal GetTotalPriceWithoutDiscount(List<Product> products)
{
    return products.Sum(p => p.Price);
}