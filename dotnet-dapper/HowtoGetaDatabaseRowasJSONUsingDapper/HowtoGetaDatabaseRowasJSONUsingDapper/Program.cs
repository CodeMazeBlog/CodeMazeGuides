using HowtoGetaDatabaseRowasJSONUsingDapper.Contracts;
using HowtoGetaDatabaseRowasJSONUsingDapper.DbContext;
using HowtoGetaDatabaseRowasJSONUsingDapper.Repository;
using HowtoGetaDatabaseRowasJSONUsingDapper.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IService, Service>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
