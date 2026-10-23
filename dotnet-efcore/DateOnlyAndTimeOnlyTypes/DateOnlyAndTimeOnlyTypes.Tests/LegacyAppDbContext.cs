using System;
using Microsoft.EntityFrameworkCore;

namespace DateOnlyAndTimeOnlyTypes.Tests;

// An existing database keeps BirthDate in a datetime2 column that we can't change.
public class LegacyAppDbContext(DbContextOptions<LegacyAppDbContext> options) : DbContext(options)
{
    public DbSet<Employee> Employees => Set<Employee>();

    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        base.ConfigureConventions(builder);

        builder.Properties<DateOnly>()
            .HaveConversion<DateOnlyConverter>()
            .HaveColumnType("datetime2");
    }
}
