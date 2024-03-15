namespace IntroductionToScrutorInDotNet.Repositories.Decorators;

public class RepositoryLoggerDecorator<T> : IRepository<T>
{
    private readonly IRepository<T> _decoratedRepository;

    public RepositoryLoggerDecorator(IRepository<T> decoratedRepository)
    {
        _decoratedRepository = decoratedRepository;
    }

    public IEnumerable<T> GetAll()
    {
        Console.WriteLine("The list of all users has been retrieved from the DB");
        
        return _decoratedRepository.GetAll();
    }
}