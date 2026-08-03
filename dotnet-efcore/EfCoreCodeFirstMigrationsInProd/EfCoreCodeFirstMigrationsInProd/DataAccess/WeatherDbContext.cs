using EfCoreCodeFirstMigrationsInProd.Domain;
using Microsoft.EntityFrameworkCore;

namespace EfCoreCodeFirstMigrationsInProd.DataAccess;

public class WeatherDbContext(DbContextOptions<WeatherDbContext> options) : DbContext(options)
{
    public DbSet<WeatherForecast> WeatherForecasts => Set<WeatherForecast>();
}