using Microsoft.EntityFrameworkCore;
using UnitOfWork.Entities;

namespace UnitOfWork.DataAccess.EntityFramework;

public class AppDbContext : DbContext, IDatabase, IUnitOfWork
{
    public async Task<ITransaction> BeginTransactionAsync()
    {
        var transaction = await Database.BeginTransactionAsync();
        return new EfTransaction(transaction);
    }
    
    public DbSet<Order> Orders { get; set; }

    IQueryable<Order> IDatabase.Orders => Orders;
    
    public void AddOrder(Order order)
    {
        Orders.Add(order);
    }
}