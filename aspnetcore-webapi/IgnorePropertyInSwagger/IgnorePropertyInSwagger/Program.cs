using IgnorePropertyInSwagger.Endpoints;
using IgnorePropertyInSwagger.SchemaFilters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o => o.SchemaFilter<SwaggerIgnoreFilter>());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapWeatherForecasts();

app.Run();

