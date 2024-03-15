using IdentityUserExtension.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityUserExtension.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Post>(b =>
        {
            b.HasKey(e => e.Id);
            b.Property(e => e.Title).IsRequired().HasMaxLength(256);
            b.Property(e => e.Text).IsRequired();
        });
        
        builder.Entity<ApplicationUser>(b =>
        {
            b.Property(u => u.DisplayName).IsRequired().HasMaxLength(100);
            b.HasMany(u => u.Posts).WithOne();
        });
    }
}