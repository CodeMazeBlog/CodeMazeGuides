using FeatureFlags;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.FeatureFilters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddFeatureManagement()
    .AddFeatureFilter<PercentageFilter>()
    .AddFeatureFilter<LanguageFilter>()
    .AddFeatureFilter<TimeWindowFilter>();

builder.Services.AddHttpContextAccessor();

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
