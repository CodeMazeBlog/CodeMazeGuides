using App.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.EntitiesConfiguration;

public class ClothingItemConfig : IEntityTypeConfiguration<ClothingItem>
{
    public void Configure(EntityTypeBuilder<ClothingItem> builder)
    {
        builder.ToTable("ClothingItems");
        builder.Property(x => x.Description).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Price).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(x => x.Size).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Color).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Material).HasMaxLength(100).IsRequired();

        builder.HasData(new List<ClothingItem>()
        {
            new()
            {
                Id = Guid.NewGuid(),
                Description = "Nike Air Max",
                Price = 8000,
                Size = "M",
                Color = "Black",
                Material = "Leather"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Description = "Nike Air Max-2",
                Price = 67275,
                Size = "M",
                Color = "Red",
                Material = "Leather"
            }
        });
    }
}