using IntroductionToCarter.Data.Repositories.Abstractions;

namespace IntroductionToCarter.Data;

public interface IUnitOfWork
{
    IBookRepository BookRepository { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
