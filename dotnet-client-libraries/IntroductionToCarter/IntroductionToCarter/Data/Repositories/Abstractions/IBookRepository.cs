using IntroductionToCarter.Data.Models;

namespace IntroductionToCarter.Data.Repositories.Abstractions;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Book?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Insert(Book book);
    void Remove(Book book);
}
