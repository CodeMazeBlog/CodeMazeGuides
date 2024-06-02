namespace FindAllPositionsOfAString.Samples;

public record SearchPair(string Text, string SearchValue);

public static class SearchingSamples
{
    private readonly static SearchPair[] searchPairs =
    [
        new SearchPair(new string('I', 10), "III"),
        // new SearchPair("ABABABABABABABABABABABABABABABABABABABABABABABABABABABABABAB", "ABABABABABAB"),
        new SearchPair("the The THe THE", "the"),
        // new SearchPair(LoremIpsumGenerator.GenerateWords(1000), "dolor"),
        // new SearchPair(JuliusCaesarText.Read(), "Romans"),
        // new SearchPair(JuliusCaesarText.Read(), "and Lucilius"),
        // new SearchPair(JuliusCaesarText.Read(), "Themselves"),
    ];

    public static IEnumerable<object[]> SamplesForBenchmark()
    {
        foreach (SearchPair searchPair in searchPairs)
        {
            yield return new object[] { searchPair.Text, searchPair.SearchValue };
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
