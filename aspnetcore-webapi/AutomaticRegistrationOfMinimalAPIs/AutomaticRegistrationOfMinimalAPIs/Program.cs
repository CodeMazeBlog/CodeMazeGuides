using AutomaticRegistrationOfMinimalAPIs.Contracts.Student;
using AutomaticRegistrationOfMinimalAPIs.Contracts.Teacher;
using AutomaticRegistrationOfMinimalAPIs.Data;
using AutomaticRegistrationOfMinimalAPIs.Data.Models;
using AutomaticRegistrationOfMinimalAPIs.Services;
using AutomaticRegistrationOfMinimalAPIs.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();

builder.Services.AddDbContext<SchoolDbContext>(options =>
    options.UseInMemoryDatabase("School"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region Student
app.MapGet("/students", async (IStudentService service) =>
{
    var student = await service.GetAllAsync();

    return Results.Ok(student);
})
.WithOpenApi();

app.MapGet("/students/{id:guid}", async (Guid id, IStudentService service) =>
{
    var student = await service.GetAllAsync();

    return Results.Ok(student);
})
.WithOpenApi();

app.MapPost("/students", async (StudentForCreationDto dto, IStudentService service) =>
{
    var student = await service.CreateAsync(dto);

    return Results.Created($"/students/{student.Id}", student);
})
.WithOpenApi();

app.MapPut("/students/{id:guid}", async (Guid id, StudentForUpdateDto dto, IStudentService service) =>
{
    await service.UpdateAsync(id, dto);

    return Results.NoContent();
})
.WithOpenApi();

app.MapDelete("/students/{id:guid}", async (Guid id, IStudentService service) =>
{
    await service.DeleteAsync(id);

    return Results.NoContent();
})
.WithOpenApi();
#endregion

#region Teacher
app.MapGet("/teachers", async (ITeacherService service) =>
{
    var teacher = await service.GetAllAsync();

    return Results.Ok(teacher);
})
.WithOpenApi();

app.MapGet("/teachers/{id:guid}", async (Guid id, ITeacherService service) =>
{
    var teacher = await service.GetAllAsync();

    return Results.Ok(teacher);
})
.WithOpenApi();

app.MapPost("/teachers", async (TeacherForCreationDto dto, ITeacherService service) =>
{
    var teacher = await service.CreateAsync(dto);

    return Results.Created($"/teachers/{teacher.Id}", teacher);
})
.WithOpenApi();

app.MapPut("/teachers/{id:guid}", async (Guid id, TeacherForUpdateDto dto, ITeacherService service) =>
{
    await service.UpdateAsync(id, dto);

    return Results.NoContent();
})
.WithOpenApi();

app.MapDelete("/teachers/{id:guid}", async (Guid id, ITeacherService service) =>
{
    await service.DeleteAsync(id);

    return Results.NoContent();
})
.WithOpenApi();
#endregion

app.Run();

public partial class Program { }
