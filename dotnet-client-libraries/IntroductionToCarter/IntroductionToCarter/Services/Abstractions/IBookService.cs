using IntroductionToCarter.Contracts;

namespace IntroductionToCarter.Services.Abstractions;

public interface IBookService
{
    Task<IEnumerable<BookResponse>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<BookResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<BookResponse> CreateAsync(CreateBookRequest createBookRequest, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid id, UpdateBookRequest updateBookRequest, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
