using Microsoft.Extensions.Options;

namespace ValidationForConfigurationData;

[OptionsValidator]
public partial class ValidateNotificationSettings : IValidateOptions<NotificationSettings>
{
}
