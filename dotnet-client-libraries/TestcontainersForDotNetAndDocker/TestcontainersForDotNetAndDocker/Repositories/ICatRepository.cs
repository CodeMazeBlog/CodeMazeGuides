using TestcontainersForDotNetAndDocker.Domain;

namespace TestcontainersForDotNetAndDocker.Repositories;

public interface ICatRepository
{
    Task<bool> CreateCatAsync(Cat Cat);

    Task<Cat?> GetCatAsync(Guid id);

    Task<IEnumerable<Cat>> GetAllCatsAsync();

    Task<bool> UpdateCatAsync(Cat cat);

    Task<bool> DeleteCatAsync(Guid id);
}
