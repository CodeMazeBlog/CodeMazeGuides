namespace UnitOfWork.DataAccess;

public interface IUnitOfWork
{
    Task BeginTransactionAsync();
    Task CommitAsync();
}