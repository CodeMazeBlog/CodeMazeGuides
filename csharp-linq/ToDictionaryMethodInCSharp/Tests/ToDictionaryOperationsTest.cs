using ToDictionaryMethodInCSharp;

namespace Tests;

public class ToDictionaryOperationsTest
{
    private static readonly Dictionary<string, Country> _expectedCountries
        = new()
        {
            { "Egypt", new("Egypt", "Cairo", "Africa") },
            { "India", new("India", "New Delhi", "Asia") },
            { "Chile", new("Chile", "Santiago", "South America") },
            { "Australia",  new("Australia", "Canberra", "Oceania") }
        };

    private static readonly Dictionary<string, string> _expectedCountriesandCapitals
        = new()
        {
            { "Egypt", "Cairo" },
            { "India", "New Delhi" },
            { "Chile", "Santiago" },
            { "Australia", "Canberra" }
        };

    [Fact]
    public void WhenCallToDictionaryWithKeysOnlyIsCalled_ThenReturnsDictionary()
    {
        var result = ToDictionaryOperations.CallToDictionaryWithKeysOnly();

        Assert.True(_expectedCountries.OrderBy(x => x.Key).SequenceEqual(result.OrderBy(x => x.Key)));
    }

    [Fact]
    public void WhenCallToDictionaryWithKeysAndValuesIsCalled_ThenReturnsDictionary()
    {
        var result = ToDictionaryOperations.CallToDictionaryWithKeysAndValues();

        Assert.True(_expectedCountriesandCapitals.OrderBy(x => x.Key).SequenceEqual(result.OrderBy(x => x.Key)));
    }
}