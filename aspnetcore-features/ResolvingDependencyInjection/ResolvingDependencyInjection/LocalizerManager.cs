using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace ResolvingDependencyInjection
{
    public static class LocalizerManager
    {
        private static IStringLocalizer? _localizer;

        public static void SetLocalizationOptions(MvcOptions options)
        {
            options.ModelBindingMessageProvider
                .SetMissingRequestBodyRequiredValueAccessor(() => _localizer.GetString("MissingRequestBodyRequiredValue"));
        }

        public static void SetLocalizer(IStringLocalizer localizer)
        {
            _localizer = localizer;
        }
    }
}
