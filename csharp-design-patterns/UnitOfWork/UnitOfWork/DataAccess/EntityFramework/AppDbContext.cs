using Microsoft.EntityFrameworkCore;
using UnitOfWork.Entities;

namespace UnitOfWork.DataAccess.EntityFramework;

public class AppDbContext : DbContext, IDatabase, IUnitOfWork
{
    public DbSet<Order> Orders { get; set; }

    IQueryable<Order> IDatabase.Orders => Orders;
    
    public async Task<ITransaction> BeginTransactionAsync()
    {
        var transaction = await Database.BeginTransactionAsync();

        return new EfTransaction(transaction);
    }
    
    public void AddOrder(Order order)
    {
        Orders.Add(order);
    }
}