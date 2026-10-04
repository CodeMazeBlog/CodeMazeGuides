using Microsoft.EntityFrameworkCore;
using Newsroom.Core;

namespace Newsroom.Persistence;

public sealed class NewsroomDbContext(DbContextOptions<NewsroomDbContext> options)
    : DbContext(options)
{
    public DbSet<Article> Articles => Set<Article>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(builder =>
        {
            builder.Property(a => a.Title).HasMaxLength(200);
            builder.Property(a => a.Status).HasConversion<string>().HasMaxLength(20);
        });
    }
}
