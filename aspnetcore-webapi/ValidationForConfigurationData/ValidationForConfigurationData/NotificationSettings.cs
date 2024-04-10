namespace ValidationForConfigurationData;

public class NotificationSettings
{
	public string Sender { get; init; }
	public bool EnableSms { get; init; }
	public bool EnableEmail { get; init; }
	public int MaxNumberOfRetries { get; init; }
}
