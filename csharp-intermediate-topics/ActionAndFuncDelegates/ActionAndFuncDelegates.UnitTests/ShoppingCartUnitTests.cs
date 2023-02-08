namespace ActionAndFuncDelegates.UnitTests
{
    public class ShoppingCartUnitTests
    {
        ShoppingCart cart = new ShoppingCart();

        public ShoppingCartUnitTests()
        {
            cart.AddProduct(new Product { Name = "Apple", Price = 0.25m });
            cart.AddProduct(new Product { Name = "Banana", Price = 0.35m });
            cart.AddProduct(new Product { Name = "Carrot", Price = 0.15m });
        }

        [Fact]
        public void WhenGivenCartWithProducts_ThenActionLogsTheContent()
        {
            string expectedResult = "Cart contains: Apple, Banana, Carrot";
            string actualResult = string.Empty;

            cart.LogCartContents(products => actualResult = "Cart contains: " + string.Join(", ", products.Select(p => p.Name)));

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void WhenGivenCartWithProducts_ThenFuncCalculatesTotalValue()
        {
            decimal expectedCost = 0.75m;
            decimal actualCost = 0;

            actualCost = cart.GetTotalPrice(products => products.Sum(p => p.Price));

            Assert.Equal(expectedCost, actualCost);
        }
    }
}