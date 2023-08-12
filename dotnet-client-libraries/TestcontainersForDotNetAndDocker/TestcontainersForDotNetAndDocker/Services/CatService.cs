using TestcontainersForDotNetAndDocker.Domain;
using TestcontainersForDotNetAndDocker.Repositories;

namespace TestcontainersForDotNetAndDocker.Services;

public class CatService : ICatService
{
    private readonly ICatRepository _catRepository;

    public CatService(ICatRepository catRepository)
    {
        _catRepository = catRepository;
    }

    public Task<bool> CreateCatAsync(Cat Cat)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteDeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Cat>> GetAllCatsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Cat?> GetCatAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateCatAsync(Cat cat)
    {
        throw new NotImplementedException();
    }
}
