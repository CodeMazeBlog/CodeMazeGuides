using System.ComponentModel.DataAnnotations;

namespace ModelStateValidation.Models;

public class CreateBookInputModel
{
    [Required]
    public string? Title { get; set; }

    [MaxLength(250)]
    public string? Description { get; set; }

    [Required]
    [StringLength(13, MinimumLength = 13, ErrorMessage = "The ISBN must be a string with the exact length of 13.")]
    public string? ISBN { get; set; }
}
