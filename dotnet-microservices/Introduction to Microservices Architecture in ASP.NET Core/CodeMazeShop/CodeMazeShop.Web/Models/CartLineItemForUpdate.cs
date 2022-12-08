using System.ComponentModel.DataAnnotations;

namespace CodeMazeShop.Web.Models;

public class CartLineItemForUpdate
{
    [Required]
    public Guid CartLineItemId { get; set; }
    [Required]
    public int Quantity { get; set; }
}
