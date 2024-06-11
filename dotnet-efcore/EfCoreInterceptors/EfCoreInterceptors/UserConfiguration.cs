namespace EfCoreInterceptors;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Entities", "master");

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .UseIdentityColumn();

        builder.Property(x => x.Name).HasColumnName("Name");
        builder.Property(x => x.Created).HasColumnName("Created");
        builder.Property(x => x.Modified).HasColumnName("Modified");
    }
}