using AutomaticRegistrationOfMinimalAPIs.Data.Models;
using AutomaticRegistrationOfMinimalAPIs.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace AutomaticRegistrationOfMinimalAPIs.Data.Repositories;

public class StudentRepository(SchoolDbContext context) : IStudentRepository
{
    public async Task<IEnumerable<Student>> GetAllAsync(CancellationToken cancellationToken = default)
        => await context.Students.ToListAsync(cancellationToken);

    public async Task<Student?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await context.Students.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public void Insert(Student student)
        => context.Students.Add(student);

    public void Remove(Student student)
        => context.Students.Remove(student);
}
