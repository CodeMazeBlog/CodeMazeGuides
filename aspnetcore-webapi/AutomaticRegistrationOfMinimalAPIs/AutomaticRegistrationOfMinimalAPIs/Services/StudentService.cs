using AutomaticRegistrationOfMinimalAPIs.Contracts.Student;
using AutomaticRegistrationOfMinimalAPIs.Data;
using AutomaticRegistrationOfMinimalAPIs.Data.Exceptions;
using AutomaticRegistrationOfMinimalAPIs.Data.Models;
using AutomaticRegistrationOfMinimalAPIs.Services.Abstractions;

namespace AutomaticRegistrationOfMinimalAPIs.Services;

public class StudentService(IUnitOfWork unitOfWork) : IStudentService
{
    public async Task<StudentDto> CreateAsync(StudentForCreationDto studentForCreationDto, CancellationToken cancellationToken = default)
    {
        var student = new Student
        {
            Id = Guid.NewGuid(),
            Name = studentForCreationDto.Name,
            Age = studentForCreationDto.Age
        };

        unitOfWork.StudentRepository.Insert(student);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new StudentDto
        {
            Id = student.Id,
            Name = student.Name,
            Age = student.Age
        };
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var student = await unitOfWork.StudentRepository
            .GetByIdAsync(id, cancellationToken)
            ?? throw new StudentNotFoundException(id);

        unitOfWork.StudentRepository.Remove(student);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<StudentDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var students = await unitOfWork.StudentRepository
            .GetAllAsync(cancellationToken);

        var studentDtos = new List<StudentDto>();

        foreach (var student in students)
        {
            studentDtos.Add(new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Age = student.Age
            });
        }

        return studentDtos;
    }

    public async Task<StudentDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var student = await unitOfWork.StudentRepository
            .GetByIdAsync(id, cancellationToken)
            ?? throw new StudentNotFoundException(id);

        return new StudentDto
        {
            Id = student.Id,
            Name = student.Name,
            Age = student.Age
        };
    }

    public async Task UpdateAsync(Guid id, StudentForUpdateDto studentForUpdateDto, CancellationToken cancellationToken = default)
    {
        var student = await unitOfWork.StudentRepository
            .GetByIdAsync(id, cancellationToken)
            ?? throw new StudentNotFoundException(id);

        student.Name = studentForUpdateDto.Name;
        student.Age = studentForUpdateDto.Age;

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
