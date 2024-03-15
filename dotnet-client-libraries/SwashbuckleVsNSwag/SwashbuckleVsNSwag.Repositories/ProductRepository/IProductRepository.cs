using SwashbuckleVsNSwag.Models.Products;

namespace SwashbuckleVsNSwag.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Product GetById(Guid id);

        void Add(Product product);

        void Remove(Guid id);
    }
}