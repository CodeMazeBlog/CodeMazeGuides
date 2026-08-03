using HandlingCircularRefsWhenWorkingWithJson.Services;
using HandlingCircularRefsWhenWorkingWithJson.Services.Interfaces;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// For Controllers
builder.Services.AddControllers().AddJsonOptions(options =>
   options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

// For Minimal Apis
//1. Add:
//using Microsoft.AspNetCore.Http.Json;
//2. Syntax:
//builder.Services.Configure<JsonOptions>(options =>
//options.SerializerOptions.ReferenceHandler = ReferenceHandler.Preserve
//);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();



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