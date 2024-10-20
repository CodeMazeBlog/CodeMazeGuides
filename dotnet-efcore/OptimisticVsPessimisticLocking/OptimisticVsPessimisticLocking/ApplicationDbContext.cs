namespace OptimisticVsPessimisticLocking;

using Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    { }

    protected ApplicationDbContext()
    { }

    public DbSet<WorkItem> WorkItems { get; init; }

    public DbSet<WorkItemAutoVersion> WorkItemsWithAutoVersioning { get; init; }

    public DbSet<WorkItemManualVersion> WorkItemsWithManualVersioning { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<WorkItem>()
            .HasData(new WorkItem
            {
                Id = 1,
                Title = "Optimistic vs Pessimistic locking",
                Description = "Write an article about optimistic and pessimistic database locking",
                Status = "Open",
                DueDate = DateTime.Now.AddDays(5),
                AssignedTo = null
            });


        modelBuilder.Entity<WorkItemAutoVersion>()
            .HasData(new WorkItemAutoVersion
            {
                Id = 2,
                Title = "Optimistic vs Pessimistic locking",
                Description = "Write an article about optimistic and pessimistic database locking",
                Status = "Open",
                DueDate = DateTime.Now.AddDays(5),
                AssignedTo = null
            });

        modelBuilder.Entity<WorkItemManualVersion>()
             .HasData(new WorkItemManualVersion
             {
                 Id = 3,
                 Title = "Optimistic vs Pessimistic locking",
                 Description = "Write an article about optimistic and pessimistic database locking",
                 Status = "Open",
                 DueDate = DateTime.Now.AddDays(5),
                 AssignedTo = null
             });

        base.OnModelCreating(modelBuilder);
    }
}