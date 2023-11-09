using ActionFuncDelegate.Context;
using ActionFuncDelegate.Data;
using ActionFuncDelegate.Service;

namespace ActionFuncDelegate.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> GetAll(Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null, Action<IQueryable<Product>> additionalQuery = null)
        {
            IQueryable<Product> query = _dbContext.Products;

            additionalQuery?.Invoke(query);

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query.ToList();
        }

        public Product GetById(int id) => _dbContext.Products.Find(id);

        public void Add(Product product) => _dbContext.Products.Add(product);

        public void Update(Product product, Action<Product> beforeUpdate = null)
        {
            beforeUpdate?.Invoke(product); // Custom action before updating

            _dbContext.Products.Update(product);
        }

        public void Delete(int id, Action<Product> beforeDelete = null)
        {
            var product = _dbContext.Products.Find(id);

            beforeDelete?.Invoke(product); // Custom action before deleting

            if (product != null)
                _dbContext.Products.Remove(product);
        }
    }
}
