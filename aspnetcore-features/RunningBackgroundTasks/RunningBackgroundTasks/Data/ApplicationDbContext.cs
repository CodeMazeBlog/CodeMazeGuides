using Microsoft.EntityFrameworkCore;
using RunningBackgroundTasks.Data.Models;

namespace RunningBackgroundTasks.Data;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Client> Clients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
