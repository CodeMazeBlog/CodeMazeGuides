using ClientServerArchitecture.Data_Access;
using ClientServerArchitecture.Models;

namespace ClientServerArchitecture.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public void AddProduct(Product product)
        {
            _productRepository.AddProduct(product);
        }
    }
}
