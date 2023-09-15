using UnitOfWork.Entities;

namespace UnitOfWork.DataAccess;

public interface IDatabase
{
    Task<ITransaction> BeginTransactionAsync();
    IQueryable<Order> Orders { get; }
    void AddOrder(Order order);
}