using Microsoft.EntityFrameworkCore;

namespace EFCoreBestPractices;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        LoadData();
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                  .IsRequired()
                  .HasMaxLength(100);
        });

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);

        modelBuilder.Entity<Supplier>()
            .HasMany(s => s.Orders)
            .WithOne(o => o.Supplier)
            .HasForeignKey(o => o.SupplierId);
    }

    public void LoadData()
    {
        if (Products.Any() || Customers.Any() || Suppliers.Any() || Orders.Any())
        {
            return;
        }

        // Create sample Products
        var product1 = new Product { Name = "Product 1", Price = 20 };
        var product2 = new Product { Name = "Product 2", Price = 35 };
        var product3 = new Product { Name = "Product 3", Price = 50 };

        // Create sample Customers
        var customer1 = new Customer
        {
            Name = "John Doe",
            Email = "john@example.com",
            Country = "USA",           
            CreatedDate = DateTime.Now 
        };

        var customer2 = new Customer
        {
            Name = "Jane Smith",
            Email = "jane@example.com",
            Country = "UK",            
            CreatedDate = DateTime.Now 
        };

        // Create sample Suppliers
        var supplier1 = new Supplier { Name = "Supplier 1" };
        var supplier2 = new Supplier { Name = "Supplier 2" };

        // Create sample Orders
        var order1 = new Order { ProductName = "Order Product 1", Supplier = supplier1 };
        var order2 = new Order { ProductName = "Order Product 2", Supplier = supplier1 };
        var order3 = new Order { ProductName = "Order Product 3", Supplier = supplier2 };

        // Add data to context
        Products.AddRange(product1, product2, product3);
        Customers.AddRange(customer1, customer2);
        Suppliers.AddRange(supplier1, supplier2);
        Orders.AddRange(order1, order2, order3);
        SaveChanges();
    }
}
