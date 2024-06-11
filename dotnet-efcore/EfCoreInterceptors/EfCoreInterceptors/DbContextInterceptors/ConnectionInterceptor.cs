namespace EfCoreInterceptors.DbContextInterceptors;

using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

public class ConnectionInterceptor(ILogger<ConnectionInterceptor> logger) : DbConnectionInterceptor
{
    public override async Task ConnectionOpenedAsync(DbConnection connection, ConnectionEndEventData eventData,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Connection opened");

        await base.ConnectionOpenedAsync(connection, eventData, cancellationToken);
    }

    public override async Task ConnectionClosedAsync(DbConnection connection, ConnectionEndEventData eventData)
    {
        logger.LogInformation("Connection closed");

        await base.ConnectionClosedAsync(connection, eventData);
    }
}