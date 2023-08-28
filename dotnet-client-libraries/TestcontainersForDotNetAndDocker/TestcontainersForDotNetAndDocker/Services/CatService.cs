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

    public async Task<bool> CreateCatAsync(Cat Cat)
        => await _catRepository.CreateCatAsync(Cat);

    public async Task<bool> DeleteCatAsync(Guid id)
        => await _catRepository.DeleteCatAsync(id);

    public async Task<IEnumerable<Cat>> GetAllCatsAsync()
        => await _catRepository.GetAllCatsAsync();

    public async Task<Cat?> GetCatAsync(Guid id)
        => await _catRepository.GetCatAsync(id);

    public async Task<bool> UpdateCatAsync(Cat cat)
        => await _catRepository.UpdateCatAsync(cat);
}
