using UnitOfWork.DataAccess;
using UnitOfWork.Entities;

namespace UnitOfWork.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly IDatabase _database;

    public OrderRepository(IDatabase database)
    {
        _database = database;
    }

    public void Add(Order order)
    {
        _database.AddOrder(order);
    }
}

public interface IOrderRepository
{
    void Add(Order order);
}