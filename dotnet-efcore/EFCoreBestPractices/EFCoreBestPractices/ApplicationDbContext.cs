using Microsoft.EntityFrameworkCore;

namespace EFCoreBestPractices;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        LoadData();
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerProfile> CustomerProfiles { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<CustomerGroup> CustomerGroups { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<CustomerGroupDiscount> CustomerGroupDiscounts { get; set; }
    public DbSet<Category> Categories { get; set; }

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

        // Configuring one-to-one relationship between Customer and CustomerProfile
        modelBuilder.Entity<Customer>()
            .HasOne(c => c.CustomerProfile)
            .WithOne(p => p.Customer)
            .HasForeignKey<CustomerProfile>(p => p.CustomerId);

        // Configuring one-to-many relationship between Supplier and Orders
        modelBuilder.Entity<Supplier>()
            .HasMany(s => s.Orders)
            .WithOne(o => o.Supplier)
            .HasForeignKey(o => o.SupplierId);

        // Configuring many-to-many relationship between CustomerGroup and Discount via CustomerGroupDiscount
        modelBuilder.Entity<CustomerGroupDiscount>()
            .HasKey(cgd => new { cgd.CustomerGroupId, cgd.DiscountId });

        modelBuilder.Entity<CustomerGroupDiscount>()
            .HasOne(cgd => cgd.CustomerGroup)
            .WithMany(cg => cg.CustomerGroupDiscounts)
            .HasForeignKey(cgd => cgd.CustomerGroupId);

        modelBuilder.Entity<CustomerGroupDiscount>()
            .HasOne(cgd => cgd.Discount)
            .WithMany(d => d.CustomerGroupDiscounts)
            .HasForeignKey(cgd => cgd.DiscountId);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);
    }

    public void LoadData()
    {
        if (Products.Any() || Customers.Any() || Orders.Any() || CustomerProfiles.Any() || Suppliers.Any() || CustomerGroups.Any() || Discounts.Any())
        {
            return;
        }

        // Create sample Products
        var product1 = new Product { Name = "Product 1", Price = 20 };
        var product2 = new Product { Name = "Product 2", Price = 35 };
        var product3 = new Product { Name = "Product 3", Price = 50 };

        // Create sample Customers
        var customer1 = new Customer { Name = "John Doe" };
        var customer2 = new Customer { Name = "Jane Smith" };

        // Create sample Customer Profiles
        var profile1 = new CustomerProfile { Customer = customer1 };
        var profile2 = new CustomerProfile { Customer = customer2 };

        // Create sample Suppliers
        var supplier1 = new Supplier { Name = "Supplier 1" };
        var supplier2 = new Supplier { Name = "Supplier 2" };

        // Create sample Orders
        var order1 = new Order { ProductName = "Order Product 1", Supplier = supplier1 };
        var order2 = new Order { ProductName = "Order Product 2", Supplier = supplier1 };
        var order3 = new Order { ProductName = "Order Product 3", Supplier = supplier2 };

        // Create sample Customer Groups
        var customerGroup1 = new CustomerGroup { Name = "VIP Customers" };
        var customerGroup2 = new CustomerGroup { Name = "Wholesale Buyers" };

        // Create sample Discounts
        var discount1 = new Discount { Code = "DISCOUNT10", DiscountAmount = 10 };
        var discount2 = new Discount { Code = "DISCOUNT20", DiscountAmount = 20 };

        // Create many-to-many relationships between CustomerGroup and Discount
        var customerGroupDiscount1 = new CustomerGroupDiscount { CustomerGroup = customerGroup1, Discount = discount1 };
        var customerGroupDiscount2 = new CustomerGroupDiscount { CustomerGroup = customerGroup1, Discount = discount2 };
        var customerGroupDiscount3 = new CustomerGroupDiscount { CustomerGroup = customerGroup2, Discount = discount1 };

        // Add data to context
        Products.AddRange(product1, product2, product3);
        Customers.AddRange(customer1, customer2);
        CustomerProfiles.AddRange(profile1, profile2);
        Suppliers.AddRange(supplier1, supplier2);
        Orders.AddRange(order1, order2, order3);
        CustomerGroups.AddRange(customerGroup1, customerGroup2);
        Discounts.AddRange(discount1, discount2);
        CustomerGroupDiscounts.AddRange(customerGroupDiscount1, customerGroupDiscount2, customerGroupDiscount3);

        SaveChanges();
    }


}
