namespace OptimisticVsPessimisticLocking.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
public class WorkItemController(ILogger<WorkItemController> Logger, ApplicationDbContext DbContext) : ControllerBase
{
    [HttpPost("/workItem/assign-pessimistic")]
    public async Task<IActionResult> AssignWorkItemWithPessimisticLockAsync(
        AssignWorkItemRequest assignWorkItemRequest, 
        CancellationToken cancellationToken)
    {
        using var transaction = await DbContext.Database
            .BeginTransactionAsync(System.Data.IsolationLevel.Serializable, cancellationToken);

        var workItem = await DbContext.WorkItems.
            FirstOrDefaultAsync(x => x.Id == assignWorkItemRequest.Id, cancellationToken);

        if (workItem is null)
            return NotFound($"Work Item with Id {assignWorkItemRequest.Id} was not found!");

        workItem.AssignedTo = assignWorkItemRequest.AssignedTo;

        try
        {
            await DbContext.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);

            return Ok("Work item updated successfully with pessimistic locking.");
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);

            Logger.LogError(ex, "Error while saving changes");

            return Problem("An error occurred while updating the resource.");
        }
    }

    [HttpPost("/workItem/assign-optimistic-row-version")]
    public async Task<IActionResult> AssignWorkItemWithAutomaticOptimicsticLockAsync(
        AssignWorkItemRequest assignWorkItemRequest,
        CancellationToken cancellationToken)
    {
        var workItem = await DbContext.WorkItemsWithRowVersion
            .FirstOrDefaultAsync(x => x.Id == assignWorkItemRequest.Id, cancellationToken);

        if (workItem is null)
            return NotFound($"Work Item with Id {assignWorkItemRequest.Id} was not found!");

        workItem.AssignedTo = assignWorkItemRequest.AssignedTo;

        if (assignWorkItemRequest.ForceConflict)
        {
            _ = await DbContext.Database.ExecuteSqlInterpolatedAsync(
                $@"UPDATE dbo.WorkItemsWithRowVersion
                   SET AssignedTo = 'John Stevens'
                   WHERE Id = {assignWorkItemRequest.Id}", cancellationToken);
        }

        try
        {
            await DbContext.SaveChangesAsync(cancellationToken);

            return Ok("Work item updated successfully with optimistic locking.");
        }
        catch (DbUpdateConcurrencyException ex)
        {
            Logger.LogError(ex, "Error while saving changes");

            return Conflict("Resource was already modified. Please retry");
        }
    }

    [HttpPost("/workItem/assign-manual-optimistic-concurrency-token")]
    public async Task<IActionResult> AssignWorkItemWithManualOptimicsticLockAsync(
        AssignWorkItemRequest assignWorkItemRequest,
        CancellationToken cancellationToken)
    {
        var workItem = await DbContext.WorkItemsWithConcurrencyToken
            .FirstOrDefaultAsync(x => x.Id == assignWorkItemRequest.Id, cancellationToken);

        if (workItem is null)
            return NotFound($"Work Item with Id {assignWorkItemRequest.Id} was not found!");

        workItem.AssignedTo = assignWorkItemRequest.AssignedTo;
        workItem.Version++;

        if (assignWorkItemRequest.ForceConflict)
        {
            _ = await DbContext.Database.ExecuteSqlInterpolatedAsync(
                $@"UPDATE dbo.WorkItemsWithConcurrencyToken
                   SET AssignedTo = 'John Stevens', Version = Version + 1
                   WHERE Id = {assignWorkItemRequest.Id}", cancellationToken);
        }

        try
        {
            await DbContext.SaveChangesAsync(cancellationToken);

            return Ok("Work item updated successfully with optimistic locking.");
        }
        catch (DbUpdateConcurrencyException ex)
        {
            Logger.LogError(ex, "Error while saving changes");

            return Conflict("Resource was already modified. Please retry");
        }
    }
}