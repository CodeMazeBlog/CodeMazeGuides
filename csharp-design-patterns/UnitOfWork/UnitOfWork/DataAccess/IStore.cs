using UnitOfWork.Entities;

namespace UnitOfWork.DataAccess;

public interface IStore : IDatabase
{
    IQueryable<TEntity> GetEntitySet<TEntity>() where TEntity : Entity;
    void Add<TEntity>(TEntity order) where TEntity : Entity;
}