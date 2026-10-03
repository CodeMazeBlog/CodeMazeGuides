using Banking.Application;
using Banking.Domain;

namespace Banking.Infrastructure;

public sealed class TransferRepository(BankDbContext dbContext) : ITransferRepository
{
    public void Add(Transfer transfer) => dbContext.Transfers.Add(transfer);
}
