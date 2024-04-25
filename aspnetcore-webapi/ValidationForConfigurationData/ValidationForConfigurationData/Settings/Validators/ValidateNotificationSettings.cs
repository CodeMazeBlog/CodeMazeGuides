using Microsoft.Extensions.Options;
using ValidationForConfigurationData.Settings;

namespace ValidationForConfigurationData;

[OptionsValidator]
public partial class ValidateNotificationSettings : IValidateOptions<NotificationSettings>
{
}
