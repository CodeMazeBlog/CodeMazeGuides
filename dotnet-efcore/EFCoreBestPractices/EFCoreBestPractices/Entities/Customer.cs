using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EFCoreBestPractices.Entities;
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
