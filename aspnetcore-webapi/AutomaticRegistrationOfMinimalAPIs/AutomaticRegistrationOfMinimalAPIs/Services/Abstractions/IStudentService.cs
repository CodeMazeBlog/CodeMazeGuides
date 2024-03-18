using AutomaticRegistrationOfMinimalAPIs.Contracts.Student;

namespace AutomaticRegistrationOfMinimalAPIs.Services.Abstractions;

public interface IStudentService
{
    Task<IEnumerable<StudentDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<StudentDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<StudentDto> CreateAsync(StudentForCreationDto studentForCreationDto, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid id, StudentForUpdateDto studentForUpdateDto, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
