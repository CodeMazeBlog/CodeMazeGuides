using Microsoft.Extensions.Options;

namespace ValidationForConfigurationData.Settings.Validators;

[OptionsValidator]
public partial class ValidateNotificationOptions : IValidateOptions<NotificationOptions>
{
}
