namespace UnitOfWork.DataAccess;

public class UnitOfWork : IUnitOfWork
{
    private readonly IDatabase _database;
    private ITransaction? _currentTransaction;

    public UnitOfWork(IDatabase database)
    {
        _database = database;
    }

    public async Task BeginTransactionAsync()
    {
        if (_currentTransaction is not null)
            throw new InvalidOperationException("A transaction has already been started.");
        _currentTransaction = await _database.BeginTransactionAsync();
    }
    
    public async Task CommitAsync()
    {
        if (_currentTransaction is null)
            throw new InvalidOperationException("A transaction has not been started.");
        
        try
        {
            await _currentTransaction.CommitAsync();
            _currentTransaction.Dispose();
            _currentTransaction = null;
        }
        catch (Exception)
        {
            if (_currentTransaction is not null)
                await _currentTransaction.RollbackAsync();
            throw;
        }
    }
}