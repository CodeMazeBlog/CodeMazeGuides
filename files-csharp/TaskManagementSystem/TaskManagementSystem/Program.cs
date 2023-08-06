using System.Text.Json.Serialization;
using TaskManagementSystem.Application.DependencyInjection;
using TaskManagementSystem.DataLayer.DependencyInjection;
using TaskManagementSystem.Exceptions.Extensions;
using TaskManagementSystem.Mappers;
using TaskManagementSystem.SwaggerSchemaFilters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.SchemaFilter<EnumSchemaFilter>();
});

builder.Services.AddApplicationLayer();
builder.Services.AddDataLayer(builder.Configuration);

builder.Services.AddAutoMapper(config => config.AddProfile<ViewModelMapper>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UserExceptionMiddleware();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
