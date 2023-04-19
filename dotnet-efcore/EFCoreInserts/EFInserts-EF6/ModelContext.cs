using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using EFInserts_EF6;
using Microsoft.Extensions.Logging;

namespace EFInserts_EF6;

public class ModelContext : DbContext
{
    public ModelContext()
        : base()
    {
    }

    public ModelContext(string connectionString)
        : base(connectionString)
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Model.Person>()
            .ToTable("person-ef6", "public");

        modelBuilder.Entity<Model.Person>()
            .Property(p => p.PersonId)
            .HasColumnName("id")
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
            .IsRequired();
        
        modelBuilder.Entity<Model.Person>()
            .Property(p => p.Name)
            .HasColumnName("name")
            .HasMaxLength(100)
            .IsUnicode()
            .IsRequired();
    }
    
    public virtual DbSet<Model.Person> People { get; set; }

    public virtual void MockableBulkInsert(IList<Model.Person> people)
    {
        this.BulkInsert(people, c => { c.BatchSize = 1000; });
    }
}