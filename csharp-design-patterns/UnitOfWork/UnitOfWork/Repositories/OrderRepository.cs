using UnitOfWork.DataAccess;
using UnitOfWork.Entities;

namespace UnitOfWork.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly IStore _database;

    public OrderRepository(IStore database)
    {
        _database = database;
    }

    public void Add(Order order)
    {
        _database.Add(order);
    }
}