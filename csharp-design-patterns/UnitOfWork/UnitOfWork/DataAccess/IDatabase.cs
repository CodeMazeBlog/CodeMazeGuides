namespace UnitOfWork.DataAccess;

public interface IDatabase
{
    Task<ITransaction> BeginTransactionAsync();
}