using AutomaticRegistrationOfMinimalAPIs.Data.Models;

namespace AutomaticRegistrationOfMinimalAPIs.Data.Repositories.Abstractions;

public interface ITeacherRepository
{
    Task<IEnumerable<Teacher>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Teacher?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Insert(Teacher teacher);
    void Remove(Teacher teacher);
}
