using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    var cacheProfiles = builder.Configuration
            .GetSection("CacheProfiles")
            .GetChildren();

    foreach (var cacheProfile in cacheProfiles)
    {
        options.CacheProfiles
        .Add(cacheProfile.Key, 
        cacheProfile.Get<CacheProfile>());
    }
});

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
