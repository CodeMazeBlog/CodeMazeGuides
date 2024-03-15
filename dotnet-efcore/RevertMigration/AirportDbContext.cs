using Microsoft.EntityFrameworkCore;

public class AirportDbContext : DbContext
{
    public DbSet<Airplane> Airplanes { get; set; }
    public DbSet<Hangar> Hangars { get; set; }

    public string DbPath { get; }

    public AirportDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "airport.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}