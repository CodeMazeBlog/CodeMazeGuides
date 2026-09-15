using Microsoft.Extensions.Options;
using ProjectConfigurationDemo.Models;

namespace ProjectConfigurationDemo.Services;

public class TitleColorService(IOptionsMonitor<TitleConfiguration> titleConfiguration) : ITitleColorService
{
    private readonly string[] _colors = ["red", "green", "blue", "black", "purple", "yellow", "brown", "pink"];
    private readonly IOptionsMonitor<TitleConfiguration> _titleConfiguration = titleConfiguration;

    public string GetTitleColor()
    {
        var configuration = _titleConfiguration.CurrentValue;

        return configuration.UseRandomTitleColor
            ? _colors[Random.Shared.Next(_colors.Length)]
            : configuration.Color;
    }
}
