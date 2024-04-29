
using GettingStartedASPNETMongoDB.Interfaces;
using GettingStartedASPNETMongoDB.Models;
using GettingStartedASPNETMongoDB.Services;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.Configure<SchoolDatabaseSettings>(builder.Configuration.GetSection("SchoolDatabaseSettings"));

builder.Services.AddSingleton<IMongoClient>(_ =>
{
    var connectionString = builder.Configuration.GetSection("SchoolDatabaseSettings:ConnectionString")?.Value;

    return new MongoClient(connectionString);
});

//How to Setup IMongoClient using MongoClientSettings
/*builder.Services.AddSingleton<IMongoClient>(_ =>
{
    var settings = new MongoClientSettings()
    {
        Scheme = ConnectionStringScheme.MongoDB,
        Server = new MongoServerAddress("localhost", 27017)
    };

    return new MongoClient(settings);
});*/

builder.Services.AddSingleton<IStudentService, StudentService>();

builder.Services.AddSingleton<ICourseService, CourseService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();