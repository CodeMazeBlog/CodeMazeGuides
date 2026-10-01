using Banking.Application;
using Banking.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddDbContext<BankDbContext>(options =>
{
    options.UseSqlite("Data Source=bank.db");

    if (args.Contains("--log-sql"))
        options.LogTo(Console.WriteLine,
            [RelationalEventId.TransactionStarted, RelationalEventId.TransactionCommitted,
             RelationalEventId.TransactionDisposed, RelationalEventId.CommandExecuted,
             RelationalEventId.CommandError],
            options: DbContextLoggerOptions.None);
});

services.AddScoped<IAccountRepository, AccountRepository>();
services.AddScoped<ITransferRepository, TransferRepository>();
services.AddScoped<IUnitOfWork, UnitOfWork>();
services.AddScoped<TransferMoneyHandler>();

await using var provider = services.BuildServiceProvider(validateScopes: true);

await using (var scope = provider.CreateAsyncScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BankDbContext>();
    await db.Database.EnsureDeletedAsync();
    await db.Database.EnsureCreatedAsync();
}

await TransferAsync(new TransferMoneyCommand(1, 2, 30m, "TR-1001"));
await TransferAsync(new TransferMoneyCommand(1, 2, 500m, "TR-1002"));
await TransferAsync(new TransferMoneyCommand(1, 2, 30m, "TR-1001"));
await PrintBalancesAsync();

async Task TransferAsync(TransferMoneyCommand command)
{
    await using var scope = provider.CreateAsyncScope();
    var handler = scope.ServiceProvider.GetRequiredService<TransferMoneyHandler>();

    try
    {
        var result = await handler.HandleAsync(command);

        Console.WriteLine(result.IsSuccess
            ? $"{command.Reference}: done, transfer {result.Value.TransferId}, new balance {result.Value.FromBalance:0.00}"
            : $"{command.Reference}: refused, {result.Error!.Description}");
    }
    catch (DbUpdateException ex)
    {
        Console.WriteLine($"{command.Reference}: failed, {ex.InnerException?.Message}");
    }
}

async Task PrintBalancesAsync()
{
    await using var scope = provider.CreateAsyncScope();
    var db = scope.ServiceProvider.GetRequiredService<BankDbContext>();

    foreach (var account in await db.Accounts.AsNoTracking().ToListAsync())
        Console.WriteLine($"{account.Owner}: {account.Balance:0.00}");

    Console.WriteLine($"Transfers: {await db.Transfers.CountAsync()}");
}
