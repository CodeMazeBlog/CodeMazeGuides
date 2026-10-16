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
            { "Australia",  new("Australia", "Canberra", "Oceania") },
            { "Kenya", new("Kenya", "Nairobi", "Africa") }
        };

    private static readonly Dictionary<string, string> _expectedCountriesandCapitals
        = new()
        {
            { "Egypt", "Cairo" },
            { "India", "New Delhi" },
            { "Chile", "Santiago" },
            { "Australia", "Canberra" },
            { "Kenya", "Nairobi" }
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

    [Fact]
    public void WhenCallToDictionaryOnKeyValuePairsIsCalled_ThenReturnsDictionary()
    {
        var result = ToDictionaryOperations.CallToDictionaryOnKeyValuePairs();

        Assert.True(_expectedCountriesandCapitals.OrderBy(x => x.Key).SequenceEqual(result.OrderBy(x => x.Key)));
    }

    [Fact]
    public void WhenCallToDictionaryOnTuplesIsCalled_ThenReturnsDictionary()
    {
        var result = ToDictionaryOperations.CallToDictionaryOnTuples();

        Assert.True(_expectedCountriesandCapitals.OrderBy(x => x.Key).SequenceEqual(result.OrderBy(x => x.Key)));
    }

    [Fact]
    public void WhenCallToDictionaryWithComparerIsCalled_ThenLookupIgnoresCase()
    {
        var result = ToDictionaryOperations.CallToDictionaryWithComparer();

        Assert.Same(StringComparer.OrdinalIgnoreCase, result.Comparer);
        Assert.Equal("Cairo", result["egypt"].Capital);
    }

    [Fact]
    public void WhenCallToDictionaryWithDuplicateKeysIsCalled_ThenThrowsArgumentException()
    {
        var exception = Assert.Throws<ArgumentException>(
            () => ToDictionaryOperations.CallToDictionaryWithDuplicateKeys());

        Assert.Equal("An item with the same key has already been added. Key: Africa", exception.Message);
    }

    [Fact]
    public void WhenCallToDictionaryKeepingFirstPerContinentIsCalled_ThenKeepsFirstCountry()
    {
        var result = ToDictionaryOperations.CallToDictionaryKeepingFirstPerContinent();

        Assert.Equal(4, result.Count);
        Assert.Equal("Egypt", result["Africa"].Name);
    }

    [Fact]
    public void WhenCallToLookupOnContinentsIsCalled_ThenGroupsCountriesPerContinent()
    {
        var result = ToDictionaryOperations.CallToLookupOnContinents();

        Assert.Equal(4, result.Count);
        Assert.Equal(2, result["Africa"].Count());
        Assert.Empty(result["Antarctica"]);
    }
}