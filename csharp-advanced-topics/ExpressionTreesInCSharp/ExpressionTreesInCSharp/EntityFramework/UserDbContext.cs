using Microsoft.EntityFrameworkCore;

namespace ExpressionTreesInCSharp.EntityFramework;

public class UserDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=users.db");
        }
    }
}