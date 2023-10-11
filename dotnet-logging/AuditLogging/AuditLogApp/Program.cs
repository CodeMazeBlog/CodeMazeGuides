using Microsoft.EntityFrameworkCore;
using AuditLogApp.Data;
using AuditLogApp.Middlewares;

namespace AuditLogApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<ProductsDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("ProductsDbContext") ?? 
            throw new InvalidOperationException("Connection string 'ProductsDbContext' not found.")));

        // Add services to the container.

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

        app.Use(next => context =>
        {
            context.Request.EnableBuffering();
            return next(context);
        });

        app.UseMiddleware<AuditLogMiddleware>();

        app.MapControllers();

        app.Run();
    }
}

