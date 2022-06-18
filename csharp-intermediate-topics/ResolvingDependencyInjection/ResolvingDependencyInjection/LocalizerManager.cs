using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace ResolvingDependencyInjection
{
    public class LocalizerManager
    {
        public static IStringLocalizer? localizer;

        public static void SetLocalizationOptions(MvcOptions options)
        {

            options.ModelBindingMessageProvider
                .SetMissingRequestBodyRequiredValueAccessor(() => localizer.GetString("MissingRequestBodyRequiredValue"));
        }
    }
}
