using SwashbuckleVsNSwag.Models.Products;

namespace SwashbuckleVsNSwag.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Dictionary<Guid, Product> _repository = new Dictionary<Guid, Product>();

        public Product GetById(Guid id)
        {
            return _repository[id];
        }

        public void Add(Product product)
        {
            product.ProductId = Guid.NewGuid();

            _repository[product.ProductId] = product;
        }

        public void Remove(Guid id)
        {
            _repository.Remove(id);
        }
    }
}