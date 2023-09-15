using UnitOfWork.DataAccess.EntityFramework;
using UnitOfWork.Entities;

namespace UnitOfWork.DataAccess;

public class DummyDatabase : IDatabase
{
    private readonly List<Order> _orders = new List<Order>();
    
    public Task<ITransaction> BeginTransactionAsync()
    {
        return Task.FromResult(new EfTransaction(null) as ITransaction);
    }

    public IQueryable<Order> Orders => _orders.AsQueryable();
    
    public void AddOrder(Order order)
    {
        _orders.Add(order);
    }
}