using HexagonalArchitecturalPatternInCSharp.Core.Entities;
using HexagonalArchitecturalPatternInCSharp.Core.Ports.Driven;
using Microsoft.EntityFrameworkCore;

namespace HexagonalArchitecturalPatternInCSharp.Persistence.Database;

public class AuthorRepository : IAuthorRepository
{
    private readonly WritingDbContext _dbContext;

    public AuthorRepository(WritingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Author author)
    {
        await _dbContext.Authors.AddAsync(author);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var author = _dbContext.Authors.FirstOrDefault(x => x.Id == id);

        if (author != null)
        {
            _dbContext.Authors.Remove(author);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Author>> GetAllAsync()
    {
        return await _dbContext.Authors.AsNoTracking().ToListAsync();
    }

    public async Task<Author?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Authors.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(Author author)
    {
        _dbContext.Authors.Entry(author).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
}