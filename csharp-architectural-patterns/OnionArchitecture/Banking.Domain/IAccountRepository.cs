namespace Banking.Domain;

public interface IAccountRepository
{
    Task<Account?> GetByIdAsync(int accountId, CancellationToken cancellationToken = default);

    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
