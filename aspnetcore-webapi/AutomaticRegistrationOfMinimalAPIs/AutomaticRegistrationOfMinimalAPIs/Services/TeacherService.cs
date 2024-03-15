using AutomaticRegistrationOfMinimalAPIs.Contracts.Teacher;
using AutomaticRegistrationOfMinimalAPIs.Data;
using AutomaticRegistrationOfMinimalAPIs.Data.Exceptions;
using AutomaticRegistrationOfMinimalAPIs.Data.Models;
using AutomaticRegistrationOfMinimalAPIs.Services.Abstractions;

namespace AutomaticRegistrationOfMinimalAPIs.Services;

public class TeacherService(IUnitOfWork unitOfWork) : ITeacherService
{
    public async Task<TeacherDto> CreateAsync(TeacherForCreationDto teacherForCreationDto, CancellationToken cancellationToken = default)
    {
        var teacher = new Teacher
        {
            Id = Guid.NewGuid(),
            Name = teacherForCreationDto.Name,
            Subject = teacherForCreationDto.Subject
        };

        unitOfWork.TeacherRepository.Insert(teacher);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new TeacherDto
        {
            Id = teacher.Id,
            Name = teacher.Name,
            Subject = teacher.Subject
        };
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var teacher = await unitOfWork.TeacherRepository
           .GetByIdAsync(id, cancellationToken)
           ?? throw new TeacherNotFoundException(id);

        unitOfWork.TeacherRepository.Remove(teacher);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<TeacherDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var teachers = await unitOfWork.TeacherRepository
            .GetAllAsync(cancellationToken);

        var teachersDtos = new List<TeacherDto>();

        foreach (var teacher in teachers)
        {
            teachersDtos.Add(new TeacherDto
            {
                Id = teacher.Id,
                Name = teacher.Name,
                Subject = teacher.Subject
            });
        }

        return teachersDtos;
    }

    public async Task<TeacherDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var teacher = await unitOfWork.TeacherRepository
           .GetByIdAsync(id, cancellationToken)
            ?? throw new TeacherNotFoundException(id);

        return new TeacherDto
        {
            Id = teacher.Id,
            Name = teacher.Name,
            Subject = teacher.Subject
        };
    }

    public async Task UpdateAsync(Guid id, TeacherForUpdateDto teacherForUpdateDto, CancellationToken cancellationToken = default)
    {
        var teacher = await unitOfWork.TeacherRepository
           .GetByIdAsync(id, cancellationToken)
            ?? throw new TeacherNotFoundException(id);

        teacher.Name = teacherForUpdateDto.Name;
        teacher.Subject = teacherForUpdateDto.Subject;

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
