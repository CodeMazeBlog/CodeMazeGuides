namespace WhatIsServiceDiscovery.Shipping;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.MapGet("/shiporder", () =>
        {
            return $"Your order has been shipped at {DateTimeOffset.UtcNow}";
        });

        app.Run();
    }
}
