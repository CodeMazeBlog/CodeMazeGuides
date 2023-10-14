namespace LocalFunctionInCSharp
{
    public class ShoppingCart
    {
        public List<Product> Products { get; set; }

        public bool Checkout()
        {
            foreach (var product in Products)
            {
                if (!IsItemInStock(product))
                {
                    LogValidationFailure($"Product '{product.Name}' is out of stock.");
                    return false;
                }

                if (!IsQuantityValid(product, product.SelectedQuantity))
                {
                    LogValidationFailure($"Invalid quantity selected for '{product.Name}'.");
                    return false;
                }
            }

            bool IsItemInStock(Product product)
            {
                return product.StockQuantity > 0;
            }

            bool IsQuantityValid(Product product, int quantity)
            {
                return quantity > 0 && quantity <= product.StockQuantity;
            }

            void LogValidationFailure(string message)
            {
                Console.WriteLine($"Validation Error:- {message}");
            }

            return true;
        }
    }
}


