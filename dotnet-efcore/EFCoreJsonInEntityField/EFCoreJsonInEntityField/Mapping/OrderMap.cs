using EFCoreJsonInEntityField.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreJsonInEntityField.Mapping
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(
            order => order.ShippingInfo, ownedNavigationBuilder =>
            {
                ownedNavigationBuilder.ToJson();
                ownedNavigationBuilder.OwnsMany(si => si.Shipments);
                ownedNavigationBuilder.OwnsMany(si => si.Deliveries);
            });
        }
    }
}
