using HowToProperlySetConnectionString.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HowToProperlySetConnectionString.Data;

public class AppDbContext(IConfiguration configuration) : DbContext
{
    public DbSet<Country> Countries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        #region Example of hardcoding connection string
        optionsBuilder.UseSqlServer("Server=10.1.1.120;Database=Database;User=Admin;Password=MyStrongPassword;");
        #endregion

        #region Example from the appsettings
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        #endregion
    }
}
