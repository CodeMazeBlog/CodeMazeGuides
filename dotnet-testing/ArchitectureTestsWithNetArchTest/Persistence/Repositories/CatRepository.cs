using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

internal sealed class CatRepository(CatsDbContext context) : ICatRepository
{
    public async Task<IEnumerable<Cat>> GetAllAsync(CancellationToken cancellationToken = default)
        => await context.Cats.ToListAsync(cancellationToken);

    public async Task<Cat?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await context.Cats.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public void Insert(Cat cat) => context.Cats.Add(cat);
    public void Remove(Cat cat) => context.Cats.Remove(cat);
}
