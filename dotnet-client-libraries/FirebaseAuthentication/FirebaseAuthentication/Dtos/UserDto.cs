using System.ComponentModel.DataAnnotations;

namespace FirebaseAuthentication.Dtos;

public class UserDto
{
    [Required, EmailAddress]
    public required string Email { get; set; }

    [Required]
    public required string Password { get; set; }
}
