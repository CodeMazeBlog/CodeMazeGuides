using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EFCoreBestPractices;

public class Product
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    // Navigation property for lazy loading
    public virtual Category? Category { get; set; }
}
public class Customer
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public virtual CustomerProfile? CustomerProfile { get; set; }
}
public class CustomerProfile 
{ 
    public int Id { get; set; } 
    public int CustomerId { get; set; } 
    public virtual Customer? Customer { get; set; } 
}
public class Supplier
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public virtual ICollection<Order>? Orders { get; set; }
}
public class Order
{
    public int Id { get; set; }
    public string? ProductName { get; set; }
    public int SupplierId { get; set; }
    public virtual Supplier? Supplier { get; set; }
}
public class CustomerGroup
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public virtual ICollection<CustomerGroupDiscount>? CustomerGroupDiscounts { get; set; } // Navigation property for the many-to-many relationship
}
public class Discount
{
    public int Id { get; set; }
    public string? Code { get; set; }
    public decimal DiscountAmount { get; set; }
    public virtual ICollection<CustomerGroupDiscount>? CustomerGroupDiscounts { get; set; } // Navigation property for the many-to-many relationship
}
public class CustomerGroupDiscount
{
    public int CustomerGroupId { get; set; }
    public virtual CustomerGroup? CustomerGroup { get; set; } // Navigation property to the CustomerGroup entity
    public int DiscountId { get; set; }
    public virtual Discount? Discount { get; set; } // Navigation property to the Discount entity
}
public class Category
{
    public int Id { get; set; }
    public string? Name { get; set; }

    // Navigation property for the one-to-many relationship with Product
    public virtual ICollection<Product>? Products { get; set; }
}
