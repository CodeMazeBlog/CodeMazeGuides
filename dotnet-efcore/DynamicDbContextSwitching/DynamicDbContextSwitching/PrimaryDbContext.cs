using Microsoft.EntityFrameworkCore;

namespace DynamicDbContextSwitching;

public class PrimaryDbContext : DbContext
{
    public PrimaryDbContext(DbContextOptions<PrimaryDbContext> options) : base(options)
    {
    }
}