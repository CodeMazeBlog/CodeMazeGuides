using RetrievingDbRowAsJsonWithDapper.Contracts;
using RetrievingDbRowAsJsonWithDapper.DbContext;
using RetrievingDbRowAsJsonWithDapper.Repository;
using RetrievingDbRowAsJsonWithDapper.Services;
using RetrievingDbRowAsJsonWithDapper.Wrapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IService, Service>();
builder.Services.AddSingleton<IConfigurationWrapper, ConfigurationWrapper>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
