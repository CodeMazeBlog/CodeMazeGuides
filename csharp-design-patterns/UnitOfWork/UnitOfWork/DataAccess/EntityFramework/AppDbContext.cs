using Microsoft.EntityFrameworkCore;
using UnitOfWork.Entities;

namespace UnitOfWork.DataAccess.EntityFramework;

public class AppDbContext : DbContext, IStore, IUnitOfWork
{
    public DbSet<Order> Orders { get; set; }

    public IQueryable<TEntity> GetEntitySet<TEntity>() where TEntity : Entity => Set<TEntity>();
    
    public async Task<ITransaction> BeginTransactionAsync()
    {
        var transaction = await Database.BeginTransactionAsync();

        return new EfTransaction(transaction);
    }
    
    public void Add<TEntity>(TEntity entity) where TEntity : Entity
    {
        Set<TEntity>().Add(entity);
    }
}