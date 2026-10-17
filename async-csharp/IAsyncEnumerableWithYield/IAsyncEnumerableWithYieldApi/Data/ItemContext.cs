using Microsoft.EntityFrameworkCore;

public class ItemContext(DbContextOptions<ItemContext> options) : DbContext(options)
{
    public DbSet<Item> Items => Set<Item>();
}
