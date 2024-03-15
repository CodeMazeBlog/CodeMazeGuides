using Microsoft.EntityFrameworkCore;
using AuditLogApp.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text;

namespace AuditLogApp.Data;

public class ProductsDbContext : DbContext
{
    public ProductsDbContext(DbContextOptions<ProductsDbContext> options)
        : base(options)
    {
    }

    public ProductsDbContext()
    {
    }

    public virtual DbSet<Product> Products { get; set; } = default!;
    public virtual DbSet<AuditLog> AuditLogs { get; set; } = default!;

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var modifiedEntities = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added
            || e.State == EntityState.Modified
            || e.State == EntityState.Deleted)
            .ToList();

        foreach (var modifiedEntity in modifiedEntities)
        {
            var auditLog = new AuditLog
            {
                EntityName = modifiedEntity.Entity.GetType().Name,
                Action = modifiedEntity.State.ToString(),
                Timestamp = DateTime.UtcNow,
                Changes = GetChanges(modifiedEntity)
            };

            AuditLogs.Add(auditLog);
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    private static string GetChanges(EntityEntry entity)
    {
        var changes = new StringBuilder();

        foreach (var property in entity.OriginalValues.Properties)
        {
            var originalValue = entity.OriginalValues[property];
            var currentValue = entity.CurrentValues[property];

            if (!Equals(originalValue, currentValue))
            {
                changes.AppendLine($"{property.Name}: From '{originalValue}' to '{currentValue}'");
            }
        }

        return changes.ToString();
    }
}
