using Microsoft.EntityFrameworkCore;
using RunningBackgroundTasks.Data.Models;

namespace RunningBackgroundTasks.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
