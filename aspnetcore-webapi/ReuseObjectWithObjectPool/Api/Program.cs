using Api;
using Microsoft.Extensions.ObjectPool;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddObjectPool(() => new MemoryStreamPooledObjectPolicy());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapPost("/upload", async (IFormFile file, ObjectPool<MemoryStream> pool) =>
{
    var stream = pool.Get();
    try
    {
        if (file.ContentType != "text/plain")
        {
            return Results.BadRequest("Only .txt files are allowed");
        }

        await file.CopyToAsync(stream);
        var uploadPath = Path.Combine("uploads", file.FileName);
        var directoryName = Path.GetDirectoryName(uploadPath);
        if (!Directory.Exists(directoryName))
        {
            if (directoryName != null) Directory.CreateDirectory(directoryName);
        }

        await File.WriteAllBytesAsync(uploadPath, stream.ToArray());

        return Results.Ok();
    }
    catch (Exception)
    {
        return Results.Problem("Error uploading file", statusCode: 500);
    }
    finally
    {
        pool.Return(stream);
    }
}).DisableAntiforgery();

app.Run();

public partial class Program;