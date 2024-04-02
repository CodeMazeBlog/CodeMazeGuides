using IntroductionToCarter.Data.Models;
using IntroductionToCarter.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace IntroductionToCarter.Data.Repositories;

public class BookRepository(BooksDbContext context) : IBookRepository
{
    public async Task<IEnumerable<Book>> GetAllAsync(CancellationToken cancellationToken = default)
        => await context.Books.ToListAsync(cancellationToken);

    public async Task<Book?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await context.Books.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public void Insert(Book book)
        => context.Books.Add(book);

    public void Remove(Book book)
        => context.Books.Remove(book);
}
