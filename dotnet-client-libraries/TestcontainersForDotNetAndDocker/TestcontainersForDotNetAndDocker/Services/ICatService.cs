using TestcontainersForDotNetAndDocker.Domain;

namespace TestcontainersForDotNetAndDocker.Services;

public interface ICatService
{
    Task<bool> CreateCatAsync(Cat Cat);

    Task<Cat?> GetCatAsync(Guid id);

    Task<IEnumerable<Cat>> GetAllCatsAsync();

    Task<bool> UpdateCatAsync(Cat cat);

    Task<bool> DeleteCatAsync(Guid id);
}
