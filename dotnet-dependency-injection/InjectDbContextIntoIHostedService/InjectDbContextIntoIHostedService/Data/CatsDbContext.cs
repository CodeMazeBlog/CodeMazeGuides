using Microsoft.EntityFrameworkCore;

namespace InjectDbContextIntoIHostedService.Data;

public class CatsDbContext(DbContextOptions<CatsDbContext> options)
    : DbContext(options)
{
    public virtual DbSet<Cat> Cats { get; set; }
}
