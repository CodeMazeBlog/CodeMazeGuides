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

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    [MaxLength(150)]
    public string Email { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal CreditLimit { get; set; }

    [Required]
    [MaxLength(50)]
    public string Country { get; set; }

    [Required]
    public DateTime CreatedDate { get; set; }
}
public class Category
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public virtual ICollection<Product>? Products { get; set; }
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
