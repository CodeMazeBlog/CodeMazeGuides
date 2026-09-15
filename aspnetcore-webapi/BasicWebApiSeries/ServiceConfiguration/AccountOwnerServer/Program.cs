using AccountOwnerServer.Extensions;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureCors();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
// UseForwardedHeaders goes first: every component after it has to see the client's
// scheme and address, not the proxy's, or an HTTPS redirect behind a proxy loops.
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

if (!app.Environment.IsDevelopment())
    app.UseHsts();

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
