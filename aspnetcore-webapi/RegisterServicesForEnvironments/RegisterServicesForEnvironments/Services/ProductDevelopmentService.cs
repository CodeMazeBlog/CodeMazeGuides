using RegisterServicesForEnvironments.Models;

namespace RegisterServicesForEnvironments.Services
{
    public class ProductDevelopmentService : IProductService
    {
        private readonly List<Product> _products = new()
        {
            new Product { Name = "Dev. Product 1", Id = 1 },
            new Product { Name = "Dev. Product 2", Id = 2 },
            new Product { Name = "Dev. Product 3", Id = 3 }
        };

        public List<Product> GetAll()
        {
            return _products;
        }
    }
}
