using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;

namespace EFInserts_EFCore7;

public static class LoggingOptions
{
    public static DbContextOptionsBuilder UseLoggerByEnvironment(this DbContextOptionsBuilder optionsBuilder)
    {
        if ((Environment.GetEnvironmentVariable("log2console") ?? "false") == "true")
        {
            optionsBuilder.LogTo(Console.WriteLine);
        }

        return optionsBuilder;
    }
}

public class ModelContext : DbContext
{
    private const int BulkBatchSize = 1000;
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .UseLoggerByEnvironment()
            .UseNpgsql(Environment.GetEnvironmentVariable("connectionString") ??
                        throw new Exception("Connection string not found in the environment"),
                o => o.MaxBatchSize(BulkBatchSize));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Model.Person>()
            .ToTable("person-efc7", "public");

        modelBuilder.Entity<Model.Person>()
            .Property(p => p.PersonId)
            .HasColumnName("id")
            .ValueGeneratedOnAdd()
            .IsRequired();
        
        modelBuilder.Entity<Model.Person>()
            .Property(p => p.Name)
            .HasColumnName("name")
            .HasMaxLength(100)
            .IsUnicode()
            .IsRequired();
    }
    
    public DbSet<Model.Person> People { get; set; } = null!;

    public virtual void MockableBulkInsert(IList<Model.Person> people)
    {
        this.BulkInsert(people, c => { c.BatchSize = 1000; });
    }
}