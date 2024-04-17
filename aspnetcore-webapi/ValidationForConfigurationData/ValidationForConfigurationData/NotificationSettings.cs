using System.ComponentModel.DataAnnotations;

namespace ValidationForConfigurationData;

public class NotificationSettings
{
	[Required]
	public string Sender { get; init; }
	[Required]
	public bool EnableSms { get; init; }
	[Required]
	public bool EnableEmail { get; init; }
	[Required]
	[DeniedValues([0])]
	public int MaxNumberOfRetries { get; init; }
}
