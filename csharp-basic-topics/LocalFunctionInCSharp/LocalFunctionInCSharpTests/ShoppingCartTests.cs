namespace LocalFunctionInCSharpTests
{
    public class ShoppingCartTests
    {
        [Fact]
        public void GivenLessSelectedQuantityThanStockQuantity_ThenSuccessfulCheckout()
        {
            var cart = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new() { Name = "Product A", StockQuantity = 10, SelectedQuantity = 2 },
                    new() { Name = "Product B", StockQuantity = 5, SelectedQuantity = 3 }
                }
            };

            var result = cart.Checkout();

            Assert.True(result);
        }

        [Fact]
        public void GivenMoreSelectedQuantityThanStockQuantity_ThenProductOutOfStockFails()
        {
            var cart = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new() { Name = "Product A", StockQuantity = 0, SelectedQuantity = 2 },
                    new() { Name = "Product B", StockQuantity = 5, SelectedQuantity = 3 }
                }
            };

            var result = cart.Checkout();

            Assert.False(result);
        }

        [Fact]
        public void GivenInvalidSelectedQuantity_ThenCheckoutFailsWithInvalidQuantity()
        {
            var cart = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new() { Name = "Product A", StockQuantity = 10, SelectedQuantity = 20 },
                    new() { Name = "Product B", StockQuantity = 5, SelectedQuantity = -1 }
                }
            };

            var result = cart.Checkout();

            Assert.False(result);
        }
    }
}