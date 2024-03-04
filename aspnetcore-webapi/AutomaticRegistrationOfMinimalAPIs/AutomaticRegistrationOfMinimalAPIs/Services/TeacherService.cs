using AutomaticRegistrationOfMinimalAPIs.Contracts.Teacher;
using AutomaticRegistrationOfMinimalAPIs.Data;
using AutomaticRegistrationOfMinimalAPIs.Data.Exceptions;
using AutomaticRegistrationOfMinimalAPIs.Data.Models;
using AutomaticRegistrationOfMinimalAPIs.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace AutomaticRegistrationOfMinimalAPIs.Services;

public class TeacherService(SchoolDbContext context) : ITeacherService
{
    public async Task<TeacherDto> CreateAsync(TeacherForCreationDto teacherForCreationDto, CancellationToken cancellationToken = default)
    {
        var teacher = new Teacher
        {
            Id = Guid.NewGuid(),
            Name = teacherForCreationDto.Name,
            Subject = teacherForCreationDto.Subject
        };

        await context.Teachers.AddAsync(teacher, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return new TeacherDto
        {
            Id = teacher.Id,
            Name = teacher.Name,
            Subject = teacher.Subject
        };
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var teacher = await context.Teachers
           .FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
           ?? throw new TeacherNotFoundException(id);

        context.Teachers.Remove(teacher);

        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<TeacherDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var teachers = await context.Teachers.ToListAsync(cancellationToken);

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
        var teacher = await context.Teachers
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
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
        var teacher = await context.Teachers
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
            ?? throw new TeacherNotFoundException(id);

        teacher.Name = teacherForUpdateDto.Name;
        teacher.Subject = teacherForUpdateDto.Subject;

        await context.SaveChangesAsync(cancellationToken);
    }
}
