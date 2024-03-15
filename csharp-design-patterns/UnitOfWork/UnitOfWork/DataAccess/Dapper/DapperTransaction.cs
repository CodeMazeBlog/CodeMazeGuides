using System.Data.Common;

namespace UnitOfWork.DataAccess.Dapper;

public class DapperTransaction : ITransaction
{
    private DbTransaction _dbTransaction;

    public DapperTransaction(DbTransaction dbTransaction)
    {
        _dbTransaction = dbTransaction;
    }

    public Task CommitAsync() => _dbTransaction.CommitAsync();

    public Task RollbackAsync() => _dbTransaction.RollbackAsync();

    public void Dispose()
    {
        _dbTransaction?.Dispose();
        _dbTransaction = null!;
    }
}