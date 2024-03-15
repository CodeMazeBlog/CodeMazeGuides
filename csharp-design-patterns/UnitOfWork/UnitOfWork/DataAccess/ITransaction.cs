namespace UnitOfWork.DataAccess;

public interface ITransaction : IDisposable
{
    Task CommitAsync();
    Task RollbackAsync();
}