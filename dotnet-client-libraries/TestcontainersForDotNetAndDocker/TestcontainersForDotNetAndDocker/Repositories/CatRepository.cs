using Microsoft.EntityFrameworkCore;
using TestcontainersForDotNetAndDocker.Database;
using TestcontainersForDotNetAndDocker.Domain;

namespace TestcontainersForDotNetAndDocker.Repositories;

public class CatRepository : ICatRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CatRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> CreateCatAsync(Cat Cat)
    {
        try
        {
            await _dbContext.Cats.AddAsync(Cat);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> DeleteCatAsync(Guid id)
    {
        var cat = await GetCatAsync(id);

        if (cat is not null)
        {
            _dbContext.Cats.Remove(cat);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        return false;
    }

    public async Task<IEnumerable<Cat>> GetAllCatsAsync()
        => await _dbContext.Cats
            .AsNoTracking()
            .ToListAsync();

    public async Task<Cat?> GetCatAsync(Guid id)
        => await _dbContext.Cats
            .FirstOrDefaultAsync(c => c.Id == id);

    public async Task<bool> UpdateCatAsync(Cat cat)
    {
        var catToUpdate = await GetCatAsync(cat.Id);

        if (catToUpdate is not null)
        {
            catToUpdate.Name = cat.Name;
            catToUpdate.Age = cat.Age;
            catToUpdate.Weight = cat.Weight;

            await _dbContext.SaveChangesAsync();

            return true;
        }

        return false;
    }
}
