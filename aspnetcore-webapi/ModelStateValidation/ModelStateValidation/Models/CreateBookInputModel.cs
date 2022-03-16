using System.ComponentModel.DataAnnotations;

namespace ModelStateValidation.Models;

public class CreateBookInputModel
{
    [Required]
    public string Title { get; set; } = string.Empty;

    [MaxLength(250)]
    public string Description { get; set; } = string.Empty;

    [Required]
    [StringLength(13, MinimumLength = 13)]
    public string ISBN { get; set; } = string.Empty;
}
