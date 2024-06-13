namespace FindAllPositionsOfAString.Samples;

public record SearchPair(string Text, string SearchText);

public static class SearchingSamples
{
    private static string JuliusCaesar = JuliusCaesarText.Read();

    private static readonly SearchPair[] searchPairs =
    [
        new SearchPair("Some consider the occurrences to be the unconscious mind’s attempts to communicate to the conscious mind.", "the"),
        new SearchPair("The quick brown fox jumps over the lazy dog?", "the"),
        new SearchPair("ABABABABABABABABABABABABABABABABABABABABABABABABABABABABABAB", "ABABABABABAB"),
        new SearchPair(JuliusCaesar, "Themselves"),
    ];

    public static IEnumerable<object[]> SamplesForBenchmark()
    {
        foreach (SearchPair searchPair in searchPairs)
        {
            yield return new object[] { searchPair.Text, searchPair.SearchText };
        }
    }

    public static IEnumerable<SearchPair> SampleForProgram()
    {
        foreach (SearchPair searchPair in searchPairs)
        {
            yield return searchPair;
        }
    }
}
