using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniqueConstraintsInEFCore.Data.Models;

namespace UniqueConstraintsInEFCore.Data.Configurations;

public class PlanetConfiguration : IEntityTypeConfiguration<Planet>
{
    public void Configure(EntityTypeBuilder<Planet> builder)
    {
        builder.HasIndex(p => p.Name)
            .IsUnique();
    }
}
