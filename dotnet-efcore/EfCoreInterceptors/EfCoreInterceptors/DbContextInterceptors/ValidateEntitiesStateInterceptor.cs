using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EfCoreInterceptors.DbContextInterceptors;

internal class ValidateEntitiesStateInterceptor(ILogger<ValidateEntitiesStateInterceptor> logger)
    : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        if (eventData.Context is not null)
            ValidateEntitiesStates(eventData.Context);

        return new ValueTask<InterceptionResult<int>>(result);
    }

    private void ValidateEntitiesStates(DbContext context)
    {
        logger.LogInformation("Validating entities.");

        foreach (var entry in context.ChangeTracker.Entries<User>())
        {
            entry.Entity.ValidateState();
        }
    }
}