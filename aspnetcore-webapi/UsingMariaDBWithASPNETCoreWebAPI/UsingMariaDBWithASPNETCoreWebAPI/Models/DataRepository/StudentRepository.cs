using Microsoft.EntityFrameworkCore;
using UsingMariaDBWithASPNETCoreWebAPI.Models.Contracts;

namespace UsingMariaDBWithASPNETCoreWebAPI.Models.DataRepository;

public class StudentRepository(ApplicationContext context) : IDataRepository
{
    readonly ApplicationContext _studentContext = context;

    public async Task AddAsync(Student entity)
    {
        _studentContext.Students.Add(entity);
        await _studentContext.SaveChangesAsync();
    }

    public async Task<Student?> GetAsync(int id) => await _studentContext.Students.FindAsync(id);

    public async Task UpdateAsync(Student entityToUpdate, Student entity)
    {
        entityToUpdate.FirstName = entity.FirstName;
        entityToUpdate.LastName = entity.LastName;
        entityToUpdate.Address = entity.Address;

        await _studentContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Student entity)
    {
        _studentContext.Remove(entity);
        await _studentContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Student>> GetAllAsync()
    {
        return await _studentContext.Students.ToListAsync<Student>();
    }
}