using Contracts;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Repositories;
using Services;
using Services.Abstractions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

builder.Services.AddDbContextPool<CatsDbContext>(options =>
    options.UseInMemoryDatabase("Cats"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/cats", async (IServiceManager serviceManager) =>
{
    var cats = await serviceManager.CatService.GetAllAsync();

    return Results.Ok(cats);
})
.WithOpenApi();

app.MapGet("/cats/{id:guid}", async (Guid id, IServiceManager serviceManager) =>
{
    var cat = await serviceManager.CatService.GetByIdAsync(id);

    return Results.Ok(cat);
})
.WithOpenApi();

app.MapPost("/cats", async (CatForCreationDto dto, IServiceManager serviceManager) =>
{
    var cat = await serviceManager.CatService.CreateAsync(dto);

    return Results.Created($"/cats/{cat.Id}", cat);
})
.WithOpenApi();

app.MapPut("/cats/{id:guid}", async (Guid id, CatForUpdateDto dto, IServiceManager serviceManager) =>
{
    await serviceManager.CatService.UpdateAsync(id, dto);

    return Results.NoContent();
})
.WithOpenApi();

app.MapDelete("/cats/{id:guid}", async (Guid id, IServiceManager serviceManager) =>
{
    await serviceManager.CatService.DeleteAsync(id);

    return Results.NoContent();
})
.WithOpenApi();

app.Run();
