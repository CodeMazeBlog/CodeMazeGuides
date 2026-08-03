using IntroductionToCarter.Data.Repositories;
using IntroductionToCarter.Data.Repositories.Abstractions;

namespace IntroductionToCarter.Data;

public class UnitOfWork(BooksDbContext context) : IUnitOfWork
{
    public IBookRepository BookRepository { get; } = new BookRepository(context);

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => await context.SaveChangesAsync(cancellationToken);
}
