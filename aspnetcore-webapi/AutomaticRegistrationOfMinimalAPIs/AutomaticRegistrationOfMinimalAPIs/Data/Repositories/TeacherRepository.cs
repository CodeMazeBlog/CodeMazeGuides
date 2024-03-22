using AutomaticRegistrationOfMinimalAPIs.Data.Models;
using AutomaticRegistrationOfMinimalAPIs.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace AutomaticRegistrationOfMinimalAPIs.Data.Repositories;

public class TeacherRepository(SchoolDbContext context) : ITeacherRepository
{
    public async Task<IEnumerable<Teacher>> GetAllAsync(CancellationToken cancellationToken = default)
        => await context.Teachers.ToListAsync(cancellationToken);

    public async Task<Teacher?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await context.Teachers.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public void Insert(Teacher teacher)
        => context.Teachers.Add(teacher);

    public void Remove(Teacher teacher)
        => context.Teachers.Remove(teacher);
}
