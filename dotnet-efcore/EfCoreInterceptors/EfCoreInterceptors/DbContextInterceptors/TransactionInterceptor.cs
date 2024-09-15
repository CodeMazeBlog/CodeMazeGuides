using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace EfCoreInterceptors.DbContextInterceptors;

public class TransactionInterceptor(ILogger<TransactionInterceptor> logger) : DbTransactionInterceptor
{
    public override async Task TransactionCommittedAsync(DbTransaction transaction, TransactionEndEventData eventData,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Transaction {TransactionId} successful.", eventData.TransactionId);

        await base.TransactionCommittedAsync(transaction, eventData, cancellationToken);
    }
}