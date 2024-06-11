namespace EfCoreInterceptors.DbContextInterceptors;

using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;
using System.Threading;

public class TransactionInterceptor(ILogger<TransactionInterceptor> logger) : DbTransactionInterceptor
{
    public override async Task TransactionCommittedAsync(DbTransaction transaction, TransactionEndEventData eventData,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Transaction successful {id}", eventData.TransactionId);

        await base.TransactionCommittedAsync(transaction, eventData, cancellationToken);
    }
}