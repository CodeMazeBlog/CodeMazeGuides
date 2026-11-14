using SerializationDemo.EmployeeApi.Repositories;
using WebApiContrib.Core.Formatter.Protobuf;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddProtobufFormatters()
    .AddXmlSerializerFormatters();

builder.Services.AddOpenApi();

builder.Services.AddSingleton<IEmployeeRepository, EmployeeRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
