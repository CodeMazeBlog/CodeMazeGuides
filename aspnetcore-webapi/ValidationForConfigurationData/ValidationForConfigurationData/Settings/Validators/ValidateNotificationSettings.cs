using Microsoft.Extensions.Options;

namespace ValidationForConfigurationData.Settings.Validators;

[OptionsValidator]
public partial class ValidateNotificationSettings : IValidateOptions<NotificationSettings>
{
}
