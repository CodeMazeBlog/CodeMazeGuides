namespace ActionFuncInCSharp.Tests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void WhenPassedAProductCategory_ThenProductMatchingCategoryAreReturned()
        {
            List<Product> expected = new()
            {
                new() { Name = "Whole Chicken", Price = 6.99, ProductCategory = ProductCategory.Fresh },
                new() { Name = "Hovis Bread", Price = 1.29, ProductCategory = ProductCategory.Fresh },
                new() { Name = "Whole Milk", Price = 1.09, ProductCategory = ProductCategory.Fresh }
            };

            List<Product> initial = new()
            {
                new() { Name = "Rich Tea Buscuit", Price = 1.99, ProductCategory = ProductCategory.LongLife },
                new() { Name = "Whole Chicken", Price = 6.99, ProductCategory = ProductCategory.Fresh },
                new() { Name = "Hovis Bread", Price = 1.29, ProductCategory = ProductCategory.Fresh },
                new() { Name = "Whole Milk", Price = 1.09, ProductCategory = ProductCategory.Fresh },
                new() { Name = "Paracetamol", Price = 4.99, ProductCategory = ProductCategory.Medical }
            };

            var productService = new ProductService(initial);

            var actual = productService.GetProductsForCategory(ProductCategory.Fresh);

            Assert.AreEqual(3, actual.Count);

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void WhenPassedAPredicateOfPriceIsLessThan_ThenProductsMatchingPredicateAreReturned()
        {
            List<Product> expected = new()
            {
                new() { Name = "Hovis Bread", Price = 1.29, ProductCategory = ProductCategory.Fresh },
                new() { Name = "Whole Milk", Price = 1.09, ProductCategory = ProductCategory.Fresh }
            };

            List<Product> initial = new()
            {
                new() { Name = "Rich Tea Buscuit", Price = 1.99, ProductCategory = ProductCategory.LongLife },
                new() { Name = "Whole Chicken", Price = 6.99, ProductCategory = ProductCategory.Fresh },
                new() { Name = "Hovis Bread", Price = 1.29, ProductCategory = ProductCategory.Fresh },
                new() { Name = "Whole Milk", Price = 1.09, ProductCategory = ProductCategory.Fresh },
                new() { Name = "Paracetamol", Price = 4.99, ProductCategory = ProductCategory.Medical }
            };

            var productService = new ProductService(initial);

            var actual = productService.GetProducts(p => p.Price < 1.99);

            Assert.AreEqual(2, actual.Count);

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void WhenPassedASharedFunctionOfPredicatePriceIsLessThan_ThenProductsMatchingPredicateAreReturned_AndNoLogIsWritten()
        {
            List<Product> expected = new()
            {
                new() { Name = "Hovis Bread", Price = 1.29, ProductCategory = ProductCategory.Fresh },
                new() { Name = "Whole Milk", Price = 1.09, ProductCategory = ProductCategory.Fresh }
            };

            List<Product> initial = new()
            {
                new() { Name = "Rich Tea Buscuit", Price = 1.99, ProductCategory = ProductCategory.LongLife },
                new() { Name = "Whole Chicken", Price = 6.99, ProductCategory = ProductCategory.Fresh },
                new() { Name = "Hovis Bread", Price = 1.29, ProductCategory = ProductCategory.Fresh },
                new() { Name = "Whole Milk", Price = 1.09, ProductCategory = ProductCategory.Fresh },
                new() { Name = "Paracetamol", Price = 4.99, ProductCategory = ProductCategory.Medical }
            };

            var productService = new ProductService(initial, shouldLog: false);

            var actual = productService.GetProducts(ProductFunctions.PriceIsLessThan(1.99));

            Assert.AreEqual(2, actual.Count);

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void WhenPassedASharedFunctionOfPredicatePriceIsLessThan_ThenProductsMatchingPredicateAreReturned_AndLogIsWritten()
        {
            List<Product> expected = new()
            {
                new() { Name = "Hovis Bread", Price = 1.29, ProductCategory = ProductCategory.Fresh },
                new() { Name = "Whole Milk", Price = 1.09, ProductCategory = ProductCategory.Fresh }
            };

            List<Product> initial = new()
            {
                new() { Name = "Rich Tea Buscuit", Price = 1.99, ProductCategory = ProductCategory.LongLife },
                new() { Name = "Whole Chicken", Price = 6.99, ProductCategory = ProductCategory.Fresh },
                new() { Name = "Hovis Bread", Price = 1.29, ProductCategory = ProductCategory.Fresh },
                new() { Name = "Whole Milk", Price = 1.09, ProductCategory = ProductCategory.Fresh },
                new() { Name = "Paracetamol", Price = 4.99, ProductCategory = ProductCategory.Medical }
            };

            var productService = new ProductService(initial, shouldLog: false);

            var actual = productService.GetProducts(ProductFunctions.PriceIsLessThan(1.99, logOnPredicated: true));

            Assert.AreEqual(2, actual.Count);

            CollectionAssert.AreEquivalent(expected, actual);
        }
    }
}