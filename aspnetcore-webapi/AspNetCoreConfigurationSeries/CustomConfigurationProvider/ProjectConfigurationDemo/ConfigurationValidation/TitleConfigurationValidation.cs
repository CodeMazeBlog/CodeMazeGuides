using Microsoft.Extensions.Options;
using ProjectConfigurationDemo.Models;

namespace ProjectConfigurationDemo.ConfigurationValidation;

public class TitleConfigurationValidation : IValidateOptions<TitleConfiguration>
{
    private readonly string[] _colors = ["red", "green", "blue", "black", "purple", "yellow", "brown", "pink"];

    public ValidateOptionsResult Validate(string? name, TitleConfiguration options)
    {
        var builder = new ValidateOptionsResultBuilder();

        if (string.IsNullOrEmpty(options.WelcomeMessage) || options.WelcomeMessage.Length > 60)
            builder.AddError("Welcome message must be defined and it must be less than 60 characters long.",
                nameof(options.WelcomeMessage));

        if (!_colors.Contains(options.Color))
            builder.AddError($"Provided title color '{options.Color}' is not among allowed colors.",
                nameof(options.Color));

        return builder.Build();
    }
}
