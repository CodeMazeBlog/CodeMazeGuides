using InMemoryZipFilesInNet;
using InMemoryZipFilesInNet.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Net.Http.Headers;
using System.IO.Compression;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IService, FileService>();
builder.Services.AddScoped<IService, DbService>();
builder.Services.AddScoped<IService, TimeService>();

builder.Services.AddScoped<IGetFile, GetZipFile>();

WebApplication app = builder.Build();
app.UseSwagger()
   .UseSwaggerUI()
   .UseHttpsRedirection();

app.MapGet("/test-file", () => 
    Results.File(MemoryZipFile.Create("Test"), "application/zip", "TestFile.zip"));

app.MapGet("/create-and-read-zip-file", (IGetFile zipFile) =>
    Results.File(zipFile.CreateNewFileOnDisk(), zipFile.ContentType, "ByCreatingNewFileOnDisk.zip"));

app.MapGet("/create-in-memory-zip-file", (IGetFile zipFile) =>
    Results.File(zipFile.GenerateFileOnFlyReturnStream(), zipFile.ContentType, "GenerateOnFly.zip"));

app.MapGet("/create-in-memory-zip-file-as-byte-array", (IGetFile zipFile) =>
    Results.File(zipFile.GenerateFileOnFlyReturnBytes(), zipFile.ContentType, "GenerateOnFlyAsByteArray.zip"));

app.MapGet("/downloading-bigger-file", async (HttpResponse response, IGetFile zipFile) =>
{
    var zipStream = await zipFile.GenerateFileOnFlyReturnStreamAsync();
    zipStream.Position = 0;

    response.ContentType = zipFile.ContentType;
    ContentDispositionHeaderValue contentDisposition = new ContentDispositionHeaderValue("attachment")
    {
        FileName = "BigFile.zip"
    };
    response.Headers[HeaderNames.ContentDisposition] = contentDisposition.ToString();

    await zipStream.CopyToAsync(response.Body);
});

app.Run();