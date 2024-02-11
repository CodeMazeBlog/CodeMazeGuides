using InMemoryZipFilesInNet;
using InMemoryZipFilesInNet.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IService, FileService>();
builder.Services.AddScoped<IService, DbService>();
builder.Services.AddScoped<IService, TimeService>();

builder.Services.AddScoped<IGetFile, GetZipFile>();

WebApplication app = builder.Build();
_ = app.UseSwagger();
_ = app.UseSwaggerUI();
app.UseHttpsRedirection();

app.MapGet("/create-and-read-zip-file", (IGetFile zipFile) =>
    Results.File(zipFile.CreatingNewFileOnDisk(), zipFile.ContentType, "ByCreatingNewFileOnDisk.zip"));

app.MapGet("/create-in-memory-zip-file", (IGetFile zipFile) =>
    Results.File(zipFile.GenerateFileOnFlyReturnStream(), zipFile.ContentType, "GenerateOnFly.zip"));

app.MapGet("/create-in-memory-zip-file-as-byte-array", (IGetFile zipFile) =>
    Results.File(zipFile.GenerateFileOnFlyReturnBytes(), zipFile.ContentType, "GenerateOnFlyAsByteArray.zip"));

app.Run();

