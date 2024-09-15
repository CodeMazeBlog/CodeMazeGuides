using System.ComponentModel.DataAnnotations;

namespace ValidationForConfigurationData.Settings;

public class NotificationOptions
{
    [Required]
    public string Sender { get; init; }
    [Required]
    public bool EnableSms { get; init; }
    [Required]
    public bool EnableEmail { get; init; }
    [Required]
    [Range(1, 10)]
    public int MaxNumberOfRetries { get; init; }
}
