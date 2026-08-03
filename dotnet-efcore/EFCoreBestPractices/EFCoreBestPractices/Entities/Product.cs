using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EFCoreBestPractices.Entities;
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
