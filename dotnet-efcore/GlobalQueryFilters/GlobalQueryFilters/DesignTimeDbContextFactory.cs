using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GlobalQueryFilters;

public sealed class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SoftDeleteDbContext>
{
    public SoftDeleteDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<SoftDeleteDbContext>();
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=CodeMaze;User Id=sa;Password=Aa332667&;Trusted_Connection=False;Encrypt=False");

        return new(optionsBuilder.Options);
    }
}