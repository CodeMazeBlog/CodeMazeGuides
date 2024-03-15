using AutomaticRegistrationOfMinimalAPIs.Contracts.Teacher;

namespace AutomaticRegistrationOfMinimalAPIs.Services.Abstractions;

public interface ITeacherService
{
    Task<IEnumerable<TeacherDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<TeacherDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<TeacherDto> CreateAsync(TeacherForCreationDto teacherForCreationDto, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid id, TeacherForUpdateDto teacherForUpdateDto, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
