using RegisterServicesForEnvironments.Models;

namespace RegisterServicesForEnvironments.Services
{
    public class ProductLiveService : IProductService
    {
        private readonly List<Product> _products = new()
        {
            new Product { Name = "Live Product 1", Id = 1 },
            new Product { Name = "Live Product 2", Id = 2 },
            new Product { Name = "Live Product 3", Id = 3 }
        };

        public List<Product> GetAll()
        {
            return _products;
        }
    }
}
