using System.ComponentModel.DataAnnotations;

namespace PasswordlessAuthentication.Models;

public class LoginModel
{
    [Required]
    public string? UserName { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }
}
