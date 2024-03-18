using AutomaticRegistrationOfMinimalAPIs.Data.Models;

namespace AutomaticRegistrationOfMinimalAPIs.Data.Repositories.Abstractions;

public interface IStudentRepository
{
    Task<IEnumerable<Student>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Student?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Insert(Student student);
    void Remove(Student student);
}
