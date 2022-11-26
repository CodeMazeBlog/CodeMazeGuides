namespace ActionFuncInCSharp
{
    public class ProductService
    {
        private readonly List<Product> _products;
        private readonly bool _shouldLog;

        public ProductService(List<Product> products, bool shouldLog = true)
        {
            _products = products;
            _shouldLog = shouldLog;
        }

        public List<Product> GetProductsForCategory(ProductCategory productCategory)
        {
            return GetProducts(p => p.ProductCategory == productCategory);
        }

        public List<Product> GetProducts(Func<Product, bool> predicate) 
        {
            var products = _products.Where(predicate).ToList();

            if (_shouldLog)
            {
                //products.ForEach(p => Console.WriteLine($"Product Name: '{p.Name}' Price: '�{p.Price}'"));

                products.ForEach(LoggingActions.LogObjectsToConsole);
            }    

            return products;
        }
    }
}