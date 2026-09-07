using Microsoft.Extensions.Configuration;

namespace ConfigurationProviders.Tests;

public class ProviderOrderTests : IDisposable
{
    private readonly string _directory =
        Directory.CreateTempSubdirectory("ConfigurationProvidersTests").FullName;

    private string WriteJson(string level)
    {
        var path = Path.Combine(_directory, $"appsettings.{Guid.NewGuid():N}.json");
        File.WriteAllText(path, "{\"Logging\":{\"LogLevel\":{\"Default\":\"" + level + "\"}}}");
        return path;
    }

    private string WriteIni(string level)
    {
        var path = Path.Combine(_directory, $"appsettings.{Guid.NewGuid():N}.ini");
        File.WriteAllText(path, $"[Logging:LogLevel]{Environment.NewLine}Default={level}{Environment.NewLine}");
        return path;
    }

    // The article's central claim, executable: when two sources define the same
    // key, the one added last wins.
    [Fact]
    public void GivenJsonThenIni_WhenBothDefineTheSameKey_ThenTheIniValueWins()
    {
        var json = WriteJson("Information");
        var ini = WriteIni("Debug");

        var configuration = new ConfigurationBuilder()
            .AddJsonFile(json)
            .AddIniFile(ini)
            .Build();

        Assert.Equal("Debug", configuration["Logging:LogLevel:Default"]);
    }

    [Fact]
    public void GivenIniThenJson_WhenBothDefineTheSameKey_ThenTheJsonValueWins()
    {
        var json = WriteJson("Information");
        var ini = WriteIni("Debug");

        var configuration = new ConfigurationBuilder()
            .AddIniFile(ini)
            .AddJsonFile(json)
            .Build();

        Assert.Equal("Information", configuration["Logging:LogLevel:Default"]);
    }

    // The repo's appsettings.ini carried the header [Logging:Level], which writes
    // a key the logging system never reads.  The corrected header is the one that
    // actually overrides the JSON value.
    [Fact]
    public void GivenTheCorrectedIniSectionHeader_WhenTheKeyIsRead_ThenItLandsOnTheLoggingKeyPath()
    {
        var ini = Path.Combine(_directory, $"header.{Guid.NewGuid():N}.ini");
        File.WriteAllText(ini,
            $"[Logging:LogLevel]{Environment.NewLine}Default=Warning{Environment.NewLine}");

        var configuration = new ConfigurationBuilder().AddIniFile(ini).Build();

        Assert.Equal("Warning", configuration["Logging:LogLevel:Default"]);
        Assert.Null(configuration["Logging:Level:Default"]);
    }

    [Fact]
    public void GivenEnvironmentVariables_WhenTheDoubleUnderscoreSeparatorIsUsed_ThenItBecomesAKeyPath()
    {
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?> { ["Logging:LogLevel:Default"] = "Information" })
            .AddEnvironmentVariables()
            .Build();

        Environment.SetEnvironmentVariable("Logging__LogLevel__Default", "Critical");
        try
        {
            var rebuilt = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string?> { ["Logging:LogLevel:Default"] = "Information" })
                .AddEnvironmentVariables()
                .Build();

            Assert.Equal("Information", configuration["Logging:LogLevel:Default"]);
            Assert.Equal("Critical", rebuilt["Logging:LogLevel:Default"]);
        }
        finally
        {
            Environment.SetEnvironmentVariable("Logging__LogLevel__Default", null);
        }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        try { Directory.Delete(_directory, recursive: true); } catch (IOException) { }
    }
}
