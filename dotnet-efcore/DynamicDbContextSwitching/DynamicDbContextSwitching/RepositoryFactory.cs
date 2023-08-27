namespace DynamicDbContextSwitching;

public class RepositoryFactory : IRepositoryFactory
{
    private readonly IEnumerable<IRepository> _repositories;

    public RepositoryFactory(IEnumerable<IRepository> repositories)
    {
        _repositories = repositories;
    }

    public IRepository GetRepository<TRepository>() where TRepository : IRepository
    {
        return _repositories.Single(r => r is TRepository);
    }
}

public interface IRepositoryFactory
{
    IRepository GetRepository<TRepository>() where TRepository : IRepository;
}