using AccountOwnerServer.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using NLog;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.ConfigureCors(); 
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureMySqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryWrapper();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) 
    app.UseDeveloperExceptionPage(); 
else
{
    app.Use(async (context, next) => 
    { 
        await next(); 
        if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value)) 
        { 
            context.Request.Path = "/index.html"; await next(); 
        } 
    });

    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseForwardedHeaders(new ForwardedHeadersOptions 
{ 
    ForwardedHeaders = ForwardedHeaders.All 
}); 

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
