using AutomaticRegistrationOfMinimalAPIs.Data.Repositories.Abstractions;

namespace AutomaticRegistrationOfMinimalAPIs.Data;

public interface IUnitOfWork
{
    IStudentRepository StudentRepository { get; }
    ITeacherRepository TeacherRepository { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
