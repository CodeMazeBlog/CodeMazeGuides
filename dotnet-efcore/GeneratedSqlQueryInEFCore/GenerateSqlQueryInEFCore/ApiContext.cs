using Microsoft.EntityFrameworkCore;

namespace GenerateSqlQueryInEFCore;

public class ApiContext : DbContext
{
    public ApiContext(DbContextOptions<ApiContext> options)
        : base(options)
	{
    }

    public ApiContext()
    {
    }

    public virtual DbSet<Car> Cars { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Car>()
            .HasData(new Car
            {
                Id = 1,
                Brand = "BMW",
                Model = "1 Series",
                Year = 2012,
                Name = "118d HatchBack"
            },
            new Car
            {
                Id = 2,
                Brand = "BMW",
                Model = "1 Series",
                Year = 2013,
                Name = "118d M Sport 3 Door HatchBack"
            },
            new Car
            {
                Id = 3,
                Brand = "BMW",
                Model = "2 Series",
                Year = 2015,
                Name = "228i Sport Convertible"
            },
            new Car
            {
                Id = 4,
                Brand = "BMW",
                Model = "3 Series",
                Year = 2016,
                Name = "328i HatchBack"
            });
    }
}