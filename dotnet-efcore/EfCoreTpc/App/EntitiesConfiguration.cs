using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App;

public class ItemConfig : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.UseTpcMappingStrategy(); // This is the important line
    }
}

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

public class ElectronicItemConfig : IEntityTypeConfiguration<ElectronicItem>
{
    public void Configure(EntityTypeBuilder<ElectronicItem> builder)
    {
        builder.ToTable("ElectronicItems");
        builder.Property(x => x.Description).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Price).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(x => x.Model).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Manufacturer).HasMaxLength(100).IsRequired();

        builder.HasData(new List<ElectronicItem>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Description = "Samsung Galaxy S21",
                Price = 8000,
                Model = "S21",
                Manufacturer = "Samsung"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Description = "Samsung Galaxy S20",
                Price = 67275,
                Model = "S20",
                Manufacturer = "Samsung"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Description = "Samsung Galaxy S10",
                Price = 600,
                Model = "S10",
                Manufacturer = "Samsung"
            }
        });
    }
}