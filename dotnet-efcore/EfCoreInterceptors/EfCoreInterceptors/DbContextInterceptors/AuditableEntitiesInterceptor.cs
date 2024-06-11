namespace EfCoreInterceptors.DbContextInterceptors;

using EfCoreInterceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;

internal class AuditableEntitiesInterceptor(ILogger<AuditableEntitiesInterceptor> logger, TimeProvider timeProvider)
    : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        if (eventData.Context is not null)
            UpdateAuditableEntities(eventData.Context);

        return new ValueTask<InterceptionResult<int>>(result);
    }

    private void UpdateAuditableEntities(DbContext context)
    {
        logger.LogInformation("Auditing entities");

        foreach (var entry in context.ChangeTracker.Entries<IAuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.AuditCreation(timeProvider);
                    break;
                case EntityState.Modified:
                    entry.Entity.AuditModification(timeProvider);
                    break;
                default:
                    continue;
            }
        }
    }
}