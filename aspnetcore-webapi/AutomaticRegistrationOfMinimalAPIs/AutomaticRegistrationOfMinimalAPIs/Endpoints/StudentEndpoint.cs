using AutomaticRegistrationOfMinimalAPIs.Contracts.Student;
using AutomaticRegistrationOfMinimalAPIs.Services.Abstractions;

namespace AutomaticRegistrationOfMinimalAPIs.Endpoints;

public static class StudentEndpoint
{
    public static void RegisterStudentEndpoint(this IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapGet("/students", async (IStudentService service) =>
        {
            var student = await service.GetAllAsync();

            return Results.Ok(student);
        })
        .WithOpenApi();

        routeBuilder.MapGet("/students/{id:guid}", async (Guid id, IStudentService service) =>
        {
            var student = await service.GetByIdAsync(id);

            return Results.Ok(student);
        })
        .WithOpenApi();

        routeBuilder.MapPost("/students", async (StudentForCreationDto dto, IStudentService service) =>
        {
            var student = await service.CreateAsync(dto);

            return Results.Created($"/students/{student.Id}", student);
        })
        .WithOpenApi();

        routeBuilder.MapPut("/students/{id:guid}", async (Guid id, StudentForUpdateDto dto, IStudentService service) =>
        {
            await service.UpdateAsync(id, dto);

            return Results.NoContent();
        })
        .WithOpenApi();

        routeBuilder.MapDelete("/students/{id:guid}", async (Guid id, IStudentService service) =>
        {
            await service.DeleteAsync(id);

            return Results.NoContent();
        })
        .WithOpenApi();
    }
}
