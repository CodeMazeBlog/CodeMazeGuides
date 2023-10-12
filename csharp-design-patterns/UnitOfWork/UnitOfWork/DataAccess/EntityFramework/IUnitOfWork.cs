namespace UnitOfWork.DataAccess.EntityFramework;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}