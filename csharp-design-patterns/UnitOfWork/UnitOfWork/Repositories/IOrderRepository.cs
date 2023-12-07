using UnitOfWork.Entities;

namespace UnitOfWork.Repositories;

public interface IOrderRepository
{
    void Add(Order order);
}