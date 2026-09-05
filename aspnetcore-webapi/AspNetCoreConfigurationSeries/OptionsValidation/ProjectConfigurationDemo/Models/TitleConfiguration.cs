using System.ComponentModel.DataAnnotations;

namespace ProjectConfigurationDemo.Models;

public class TitleConfiguration
{
    [Required]
    [MaxLength(60)]
    public string WelcomeMessage { get; set; } = string.Empty;

    public bool ShowWelcomeMessage { get; set; }

    public string Color { get; set; } = string.Empty;

    public bool UseRandomTitleColor { get; set; }
}
