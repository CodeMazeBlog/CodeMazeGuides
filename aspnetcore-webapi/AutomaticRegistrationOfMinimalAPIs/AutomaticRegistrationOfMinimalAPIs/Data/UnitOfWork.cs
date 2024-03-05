using AutomaticRegistrationOfMinimalAPIs.Data.Repositories;
using AutomaticRegistrationOfMinimalAPIs.Data.Repositories.Abstractions;

namespace AutomaticRegistrationOfMinimalAPIs.Data;

public class UnitOfWork(SchoolDbContext context) : IUnitOfWork
{
    public IStudentRepository StudentRepository => new StudentRepository(context);

    public ITeacherRepository TeacherRepository => new TeacherRepository(context);

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => await context.SaveChangesAsync(cancellationToken);
}
