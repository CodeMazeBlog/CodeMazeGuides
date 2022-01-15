using  RateLimitingDemo.UsAspNetCoreRateLimitPackage.Model;

namespace  RateLimitingDemo.UsAspNetCoreRateLimitPackage.Repositories;

public interface IProductCatalogRepository
{
    void Create(Product product);
    Product GetById(Guid id);
    List<Product> GetAll();
    void Update(Product product);
    void Delete(Guid id);
}

