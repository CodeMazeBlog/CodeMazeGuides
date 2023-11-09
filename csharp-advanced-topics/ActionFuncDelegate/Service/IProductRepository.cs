using ActionFuncDelegate.Data;

namespace ActionFuncDelegate.Service
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll(Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null, Action<IQueryable<Product>> additionalQuery = null);
        Product GetById(int id);
        void Add(Product product);
        void Update(Product product, Action<Product> beforeUpdate = null);
        void Delete(int id, Action<Product> beforeDelete = null);
    }
}
