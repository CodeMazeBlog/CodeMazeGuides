using UnitOfWork.DataAccess.EntityFramework;
using UnitOfWork.Entities;

namespace UnitOfWork.DataAccess;

public class DummyDatabase : IStore
{
    private readonly List<Order> _orders = new List<Order>();
    
    public IQueryable<TEntity> GetEntitySet<TEntity>() where TEntity : Entity => _orders.AsQueryable() as IQueryable<TEntity>;
    
    public Task<ITransaction> BeginTransactionAsync()
    {
        return Task.FromResult(new EfTransaction(null) as ITransaction);
    }
    
    public void Add<TEntity>(TEntity order) where TEntity : Entity
    {
        _orders.Add(order as Order);
    }
}