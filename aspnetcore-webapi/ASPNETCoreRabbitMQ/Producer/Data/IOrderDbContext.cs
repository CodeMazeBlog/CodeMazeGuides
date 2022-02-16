using Microsoft.EntityFrameworkCore;

namespace Producer.Data
{
    public interface IOrderDbContext
    {
        DbSet<Order> Order { get; set; }

        Task<int> SaveChangesAsync();
    }
}
