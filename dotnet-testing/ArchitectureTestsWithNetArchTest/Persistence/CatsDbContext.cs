using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public sealed class CatsDbContext(DbContextOptions<CatsDbContext> options) : DbContext(options)
{
    public DbSet<Cat> Cats { get; set; }
}
