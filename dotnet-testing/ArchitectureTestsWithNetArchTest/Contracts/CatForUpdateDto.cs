using System.ComponentModel.DataAnnotations;

namespace Contracts;

public class CatForUpdateDto
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(60, ErrorMessage = "Name can't be longer than 50 characters")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "Breed is required")]
    [StringLength(100, ErrorMessage = "Breed cannot be loner then 50 characters")]
    public required string Breed { get; set; }

    [Required(ErrorMessage = "Date of birth is required")]
    public required DateTime DateOfBirth { get; set; }
}
