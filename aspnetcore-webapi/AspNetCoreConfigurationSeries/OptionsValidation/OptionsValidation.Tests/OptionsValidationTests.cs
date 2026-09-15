using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using ProjectConfigurationDemo.ConfigurationValidation;
using ProjectConfigurationDemo.Models;

namespace OptionsValidation.Tests;

public class OptionsValidationTests
{
    private static ServiceProvider BuildProvider(Dictionary<string, string?> values)
    {
        var configuration = new ConfigurationBuilder().AddInMemoryCollection(values).Build();
        var services = new ServiceCollection();

        services
            .AddOptionsWithValidateOnStart<TitleConfiguration>()
            .Bind(configuration.GetSection("Pages:HomePage"))
            .ValidateDataAnnotations();

        services.TryAddEnumerable(
            ServiceDescriptor.Singleton<IValidateOptions<TitleConfiguration>, TitleConfigurationValidation>());

        return services.BuildServiceProvider();
    }

    private static Dictionary<string, string?> ValidConfiguration() => new()
    {
        ["Pages:HomePage:WelcomeMessage"] = "Welcome to the Home Page",
        ["Pages:HomePage:ShowWelcomeMessage"] = "true",
        ["Pages:HomePage:Color"] = "black",
        ["Pages:HomePage:UseRandomTitleColor"] = "true"
    };

    [Fact]
    public void GivenAValidConfiguration_WhenTheOptionsAreResolved_ThenTheyBindWithoutThrowing()
    {
        using var provider = BuildProvider(ValidConfiguration());

        var options = provider.GetRequiredService<IOptions<TitleConfiguration>>();

        Assert.Equal("Welcome to the Home Page", options.Value.WelcomeMessage);
        Assert.Equal("black", options.Value.Color);
    }

    [Fact]
    public void GivenAMissingWelcomeMessage_WhenTheOptionsAreResolved_ThenAnOptionsValidationExceptionIsThrown()
    {
        var values = ValidConfiguration();
        values["Pages:HomePage:WelcomeMessage"] = string.Empty;

        using var provider = BuildProvider(values);

        Assert.Throws<OptionsValidationException>(
            () => provider.GetRequiredService<IOptions<TitleConfiguration>>().Value);
    }

    [Fact]
    public void GivenAWelcomeMessageOverSixtyCharacters_WhenTheOptionsAreResolved_ThenAnOptionsValidationExceptionIsThrown()
    {
        var values = ValidConfiguration();
        values["Pages:HomePage:WelcomeMessage"] = new string('a', 61);

        using var provider = BuildProvider(values);

        Assert.Throws<OptionsValidationException>(
            () => provider.GetRequiredService<IOptions<TitleConfiguration>>().Value);
    }

    [Fact]
    public void GivenAColorOutsideTheAllowedList_WhenTheOptionsAreResolved_ThenTheValidatorsMessageIsReported()
    {
        var values = ValidConfiguration();
        values["Pages:HomePage:Color"] = "magenta";

        using var provider = BuildProvider(values);

        var exception = Assert.Throws<OptionsValidationException>(
            () => provider.GetRequiredService<IOptions<TitleConfiguration>>().Value);

        Assert.Contains("is not among allowed colors", exception.Message);
    }

    // The failure-accumulation change: the hand-written validator reports every
    // broken rule in one pass instead of returning on the first one.
    [Fact]
    public void GivenTwoBrokenRules_WhenTheValidatorRuns_ThenBothFailuresAreReported()
    {
        var validator = new TitleConfigurationValidation();
        var options = new TitleConfiguration { WelcomeMessage = string.Empty, Color = "magenta" };

        var result = validator.Validate(name: null, options);

        Assert.True(result.Failed);
        Assert.Equal(2, result.Failures!.Count());
    }

    [Fact]
    public void GivenAValidOptionsInstance_WhenTheValidatorRuns_ThenItSucceeds()
    {
        var validator = new TitleConfigurationValidation();
        var options = new TitleConfiguration { WelcomeMessage = "Welcome", Color = "blue" };

        var result = validator.Validate(name: null, options);

        Assert.True(result.Succeeded);
    }
}
