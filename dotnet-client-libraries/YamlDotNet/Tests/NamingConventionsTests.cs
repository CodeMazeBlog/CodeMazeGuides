using App.Models;
using App.UseCases;
using static System.Environment;
using YamlDotNet.Serialization.NamingConventions;

namespace Tests;

public class NamingConventionsTests
{
    [Fact]
    public void GivenConfig_WhenSerializedWithHyphenatedConvention_ThenKeysAreHyphenated()
    {
        var config = new ServiceConfig { ServiceName = "orders", MaxRetries = 3 };
        var expectedYaml = $"service-name: orders{NewLine}max-retries: 3{NewLine}";
        var actualYaml = NamingConventions.Serialize(config, HyphenatedNamingConvention.Instance);

        Assert.Equal(expectedYaml, actualYaml);
    }

    [Fact]
    public void GivenHyphenatedYaml_WhenDeserializedWithHyphenatedConvention_ThenConfigIsReturned()
    {
        var yaml = $"service-name: orders{NewLine}max-retries: 3";
        var actualConfig = NamingConventions.Deserialize<ServiceConfig>(yaml, HyphenatedNamingConvention.Instance);

        Assert.Equal("orders", actualConfig.ServiceName);
        Assert.Equal(3, actualConfig.MaxRetries);
    }
}
