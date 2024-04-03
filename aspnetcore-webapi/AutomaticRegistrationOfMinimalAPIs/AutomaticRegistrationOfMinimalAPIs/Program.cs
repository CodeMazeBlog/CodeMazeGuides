using AutomaticRegistrationOfMinimalAPIs.Data;
using AutomaticRegistrationOfMinimalAPIs.Endpoints;
using AutomaticRegistrationOfMinimalAPIs.Services;
using AutomaticRegistrationOfMinimalAPIs.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();

builder.Services.AddMinimalEndpoints();

builder.Services.AddDbContext<SchoolDbContext>(options =>
    options.UseInMemoryDatabase("School"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.RegisterStudentEndpoint();

app.RegisterMinimalEndpoints();

app.Run();

public partial class Program { }
