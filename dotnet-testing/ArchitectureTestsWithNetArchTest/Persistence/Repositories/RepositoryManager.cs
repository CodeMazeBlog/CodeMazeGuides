using Domain.Repositories;

namespace Persistence.Repositories;

public sealed class RepositoryManager(CatsDbContext context) : IRepositoryManager
{
    private readonly Lazy<ICatRepository> _lazyCatRepository = new(() => new CatRepository(context));
    private readonly Lazy<IUnitOfWork> _lazyUnitOfWork = new(() => new UnitOfWork(context));

    public ICatRepository CatRepository => _lazyCatRepository.Value;
    public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
}
