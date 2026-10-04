using Banking.Domain;

namespace Banking.Application;

public sealed record TransferMoneyCommand(int FromAccountId, int ToAccountId, decimal Amount, string Reference);

public sealed record TransferReceipt(int TransferId, decimal FromBalance, decimal ToBalance);

public sealed class TransferMoneyHandler(
    IAccountRepository accounts,
    ITransferRepository transfers,
    IUnitOfWork unitOfWork)
{
    public async Task<Result<TransferReceipt>> HandleAsync(
        TransferMoneyCommand command, CancellationToken cancellationToken = default)
    {
        var from = await accounts.GetByIdAsync(command.FromAccountId, cancellationToken);
        if (from is null)
            return AccountErrors.NotFound(command.FromAccountId);

        var to = await accounts.GetByIdAsync(command.ToAccountId, cancellationToken);
        if (to is null)
            return AccountErrors.NotFound(command.ToAccountId);

        var withdrawal = from.Withdraw(command.Amount);
        if (!withdrawal.IsSuccess)
            return withdrawal.Error!;

        to.Deposit(command.Amount);

        var transfer = Transfer.Create(from, to, command.Amount, command.Reference);
        transfers.Add(transfer);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new TransferReceipt(transfer.Id, from.Balance, to.Balance);
    }
}
