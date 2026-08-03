using EFCoreBestPractices.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EFCoreBestPractices;
public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.HasMany(s => s.Orders)
               .WithOne(o => o.Supplier)
               .HasForeignKey(o => o.SupplierId);
    }
}