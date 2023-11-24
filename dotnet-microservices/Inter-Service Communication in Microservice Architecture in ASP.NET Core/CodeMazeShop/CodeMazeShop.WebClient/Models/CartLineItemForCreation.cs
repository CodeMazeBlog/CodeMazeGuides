using System.ComponentModel.DataAnnotations;

namespace CodeMazeShop.WebClient.Models;

public class CartLineItemForCreation
{
    [Required]
    public Guid ProductId { get; set; }
    [Required]
    public int Quantity { get; set; }
    [Required]
    public int Price { get; set; }
}
