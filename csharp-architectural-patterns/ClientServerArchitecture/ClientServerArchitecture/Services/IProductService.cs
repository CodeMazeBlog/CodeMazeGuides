using ClientServerArchitecture.Models;

namespace ClientServerArchitecture.Services;

public interface IProductService
{
    List<Product> GetProducts();
    void AddProduct(Product product);
    void ApplyDiscount(decimal discountPercentage);
}
