namespace IntroductionToScrutorInDotNet.Repositories;

public interface IRepository<T>
{
    IEnumerable<T> GetAll();
}