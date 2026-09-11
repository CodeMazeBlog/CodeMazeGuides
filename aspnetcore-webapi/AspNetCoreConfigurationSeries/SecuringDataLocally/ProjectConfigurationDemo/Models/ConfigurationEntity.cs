using System.ComponentModel.DataAnnotations;

namespace ProjectConfigurationDemo.Models;

public class ConfigurationEntity
{
    [Key]
    public string Key { get; set; } = string.Empty;

    public string? Value { get; set; }
}
