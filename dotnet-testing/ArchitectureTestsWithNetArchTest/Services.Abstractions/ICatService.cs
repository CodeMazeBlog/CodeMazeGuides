using Contracts;

namespace Services.Abstractions;

public interface ICatService
{
    Task<IEnumerable<CatDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<CatDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<CatDto> CreateAsync(CatForCreationDto catForCreationDto, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid id, CatForUpdateDto catForUpdateDto, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}

