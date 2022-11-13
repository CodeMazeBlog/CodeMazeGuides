namespace ActionFuncInCSharp.Tests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void LogProductNamesToConsole()
        {
            List<Product> products = new()
            {
                new() { Name = "Rich Tea Buscuit", Price = 1.99 },
                new() { Name = "Hovis Bread", Price = 1.29 }
            };

            products.ForEach(p => Console.WriteLine($"Product Name: '{p.Name}' Price: '�{p.Price}'"));
        }

        [TestMethod]
        public void LogProductNamesToConsoleUsingAssignedAction()
        {
            List<Product> products = new()
            {
                new() { Name = "Rich Tea Buscuit", Price = 1.99 },
                new() { Name = "Hovis Bread", Price = 1.29 }
            };

            Action<Product> loggingAction = p => Console.WriteLine($"Product Name: '{p.Name}' Price: '�{p.Price}'");
            products.ForEach(loggingAction);
        }

        [TestMethod]
        public void LogProductNamesToConsoleUsingLocalFunction()
        {
            List<Product> products = new()
            {
                new() { Name = "Rich Tea Buscuit", Price = 1.99 },
                new() { Name = "Hovis Bread", Price = 1.29 }
            };
            products.ForEach(LoggingAction);

            static void LoggingAction(Product p) => Console.WriteLine($"Product Name: '{p.Name}' Price: '�{p.Price}'");
        }

        [TestMethod]
        public void LogProductsViaLoggingAction()
        {
            List<Product> products = new()
            {
                new() { Name = "Rich Tea Buscuit", Price = 1.99 },
                new() { Name = "Hovis Bread", Price = 1.29 }
            };

            products.ForEach(LoggingActions.LogObjectsToConsole);
        }

        [TestMethod]
        public void FilterProductsByType()
        {
            List<Product> products = new()
            {
                new() { Name = "Rich Tea Buscuit", Price = 1.99, ProductCategory = ProductCategory.LongLife },
                new() { Name = "Whole Chicken", Price = 6.99, ProductCategory = ProductCategory.Fresh },
                new() { Name = "Hovis Bread", Price = 1.29, ProductCategory = ProductCategory.Fresh },
                new() { Name = "While Milk", Price = 1.09, ProductCategory = ProductCategory.Fresh },
                new() { Name = "Paracetamol", Price = 4.99, ProductCategory = ProductCategory.Medical }
            };

            var filteredProducts = products.Where(p => p.ProductCategory == ProductCategory.Fresh);

            Assert.AreEqual(3, filteredProducts.Count());

            //Filtered Products = 
            //Product: {"Name":"Whole Chicken","Price":6.99,"ProductCategory":1}
            //Product: { "Name":"Hovis Bread","Price":1.29,"ProductCategory":1}
            //Product: { "Name":"While Milk","Price":1.09,"ProductCategory":1}

            foreach (var product in filteredProducts)
            {
                LoggingActions.LogObjectsToConsole(product);
            }
        }

        [TestMethod]
        public void FilterProductsByPrice()
        {
            List<Product> products = new()
            {
                new() { Name = "Rich Tea Buscuit", Price = 1.99, ProductCategory = ProductCategory.LongLife },
                new() { Name = "Whole Chicken", Price = 6.99, ProductCategory = ProductCategory.Fresh },
                new() { Name = "Hovis Bread", Price = 1.29, ProductCategory = ProductCategory.Fresh },
                new() { Name = "While Milk", Price = 1.09, ProductCategory = ProductCategory.Fresh },
                new() { Name = "Paracetamol", Price = 4.99, ProductCategory = ProductCategory.Medical }
            };

            var filteredProducts = products.Where(p => p.Price < 1.99);

            Assert.AreEqual(2, filteredProducts.Count());

            //Filtered Products = 
            //Product: {"Name":"Hovis Bread","Price":1.29,"ProductCategory":1}
            //Product: {"Name":"While Milk","Price":1.09,"ProductCategory":1}

            foreach (var product in filteredProducts)
            {
                LoggingActions.LogObjectsToConsole(product);
            }
        }

        [TestMethod]
        public void FilterProductsByPriceUsingSharedFunction()
        {
            List<Product> products = new()
            {
                new() { Name = "Rich Tea Buscuit", Price = 1.99, ProductCategory = ProductCategory.LongLife },
                new() { Name = "Whole Chicken", Price = 6.99, ProductCategory = ProductCategory.Fresh },
                new() { Name = "Hovis Bread", Price = 1.29, ProductCategory = ProductCategory.Fresh },
                new() { Name = "While Milk", Price = 1.09, ProductCategory = ProductCategory.Fresh },
                new() { Name = "Paracetamol", Price = 4.99, ProductCategory = ProductCategory.Medical }
            };

            var filteredProducts = products.Where(ProductFunctions.PriceIsLessThan(1.99));

            Assert.AreEqual(2, filteredProducts.Count());

            //Filtered Products = 
            //Product: {"Name":"Hovis Bread","Price":1.29,"ProductCategory":1}
            //Product: {"Name":"While Milk","Price":1.09,"ProductCategory":1}

            foreach (var product in filteredProducts)
            {
                LoggingActions.LogObjectsToConsole(product);
            }
        }

        [TestMethod]
        public void FilterProductsAndLog()
        {
            List<Product> products = new()
            {
                new() { Name = "Rich Tea Buscuit", Price = 1.99, ProductCategory = ProductCategory.LongLife },
                new() { Name = "Whole Chicken", Price = 6.99, ProductCategory = ProductCategory.Fresh },
                new() { Name = "Hovis Bread", Price = 1.29, ProductCategory = ProductCategory.Fresh },
                new() { Name = "While Milk", Price = 1.09, ProductCategory = ProductCategory.Fresh },
                new() { Name = "Paracetamol", Price = 4.99, ProductCategory = ProductCategory.Medical }
            };

            var filteredProducts = products.Where(ProductFunctions.PriceIsLessThan(1.99, logOnPredicated: true));

            Assert.AreEqual(2, filteredProducts.Count());

            //Filtered Products = 
            //Product: {"Name":"Hovis Bread","Price":1.29,"ProductCategory":1}
            //Product: {"Name":"While Milk","Price":1.09,"ProductCategory":1}
        }
    }
}