namespace IntroductionToScrutorInDotNET.Repositories;

public interface IRepository<TEntity>
{
    Task CreateAsync(TEntity entity);
}
