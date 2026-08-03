using System.ComponentModel.DataAnnotations;

namespace ClientServerArchitecture.Models;

public class Product
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Please enter the product name.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Please enter the product price.")]
    public decimal? Price { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Please enter a quantity greater than 0.")]
    public int? Quantity { get; set; }
}
