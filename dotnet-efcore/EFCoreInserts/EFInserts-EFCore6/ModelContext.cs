using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
#pragma warning disable CS8618

namespace EFInserts_EFCore6;

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
    
    public static readonly ILoggerFactory DbLoggerFactory
        = LoggerFactory.Create(builder => builder.AddConsole());

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
    
    public DbSet<Model.Person> People { get; set; }
    
    public virtual void MockableBulkInsert(IList<Model.Person> people)
    {
        this.BulkInsert(people, c => { c.BatchSize = BulkBatchSize; });
    }
}