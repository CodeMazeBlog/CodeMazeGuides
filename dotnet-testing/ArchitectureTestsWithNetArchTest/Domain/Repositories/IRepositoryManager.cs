namespace Domain.Repositories;

public interface IRepositoryManager
{
    ICatRepository CatRepository { get; }
    IUnitOfWork UnitOfWork { get; }
}
