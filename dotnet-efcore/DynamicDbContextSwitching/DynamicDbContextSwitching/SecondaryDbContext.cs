using Microsoft.EntityFrameworkCore;

namespace DynamicDbContextSwitching;

public class SecondaryDbContext : DbContext
{
    public SecondaryDbContext(DbContextOptions<SecondaryDbContext> options) : base(options)
    {
    }
}