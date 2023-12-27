using ClientServerArchitecture.Data_Access;
using ClientServerArchitecture.Models;

namespace ClientServerArchitecture.Services;

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

    public void ApplyDiscount(decimal discountPercentage)
    {
        var products = _productRepository.GetProducts();

        foreach (var product in products)
        {
            var discountedPrice = product.Price - (product.Price * discountPercentage / 100);

            product.Price = discountedPrice;
        }

        _productRepository.SaveChanges();
    }
}
