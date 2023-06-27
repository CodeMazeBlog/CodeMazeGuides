using IntroductionToScrutorInDotNET.Repositories;

namespace IntroductionToScrutorInDotNET.Decorators;

public class RepositoryLoggingDecorator<TEntity> : IRepository<TEntity>
{
    private readonly IRepository<TEntity> _decoratedService;

    public RepositoryLoggingDecorator(IRepository<TEntity> decoratedService)
    {
        _decoratedService = decoratedService;
    }

    public Task CreateAsync(TEntity entity)
    {
        Console.WriteLine($"An object of type {entity.GetType().Name} has been saved to the database.");

        return _decoratedService.CreateAsync(entity);
    }
}
