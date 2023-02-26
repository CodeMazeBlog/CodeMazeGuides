var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOutputCache(options =>
{
    options.AddBasePolicy(builder =>
        builder.Expire(TimeSpan.FromSeconds(5))
                .Tag("tag-all"));

    options.AddPolicy("CacheForTenSeconds", builder =>
        builder.Expire(TimeSpan.FromSeconds(10))
               .SetVaryByQuery("city")
               .SetVaryByHeader("X-Client-Id"));

    options.AddPolicy("Expensive", builder =>
        builder.Expire(TimeSpan.FromMinutes(1))
                .Tag("tag-expensive"));
});

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

app.UseOutputCache();

app.MapGet("/etag", async (context) =>
{
    var etag = $"\"{Guid.NewGuid():n}\"";
    context.Response.Headers.ETag = etag;
    await context.Response.WriteAsync("hello");

}).CacheOutput();

app.Run();
