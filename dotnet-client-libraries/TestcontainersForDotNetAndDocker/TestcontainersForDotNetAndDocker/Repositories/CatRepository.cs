using TestcontainersForDotNetAndDocker.Domain;

namespace TestcontainersForDotNetAndDocker.Repositories;

public class CatRepository : ICatRepository
{
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
