using BenchmarkDotNet.Running;
using FindAllPositionsOfAString.Algorithms;
using FindAllPositionsOfAString.Algorithms.Interfaces;
using FindAllPositionsOfAString.Benchmarks;
using FindAllPositionsOfAString.Samples;

var benchmark = args.Length >= 1;

if (benchmark)
{
    var result = BenchmarkRunner.Run<SearcherBenchmarks>();
}
else
{
    var searchers = new ISearcher[]
    {
        new SearchUsingIndexOf(),
        new SearchUsingRegexWithMatch(),
        new SearchUsingRegexWithMatches(),
        new SearchUsingBruteForceAlgorithm(),
        new SearchUsingKMPAlgorithm(),
    };

    foreach (SearchPair searchPair in SearchingSamples.SampleForProgram())
    {
        foreach (ISearcher searcher in searchers)
        {
            foreach (bool caseSensitivity in new bool[] { true, false })
            {
                foreach (bool skipFoundText in new bool[] { true, false })
                {
                    searcher.CaseSensitive = caseSensitivity;
                    searcher.SkipWholeFoundText = skipFoundText;

                    if ((searcher is SearchUsingRegexWithMatches) && (!skipFoundText))
                        continue;

                    if ((searcher is SearchUsingKMPAlgorithm) && (skipFoundText))
                        continue;

                    List<int> positions = searcher.FindAll(searchPair.Text, searchPair.SearchText);

                    Console.WriteLine($"Using {searcher.GetType().Name}");
                    Console.WriteLine($" ** CaseSensitivity == {caseSensitivity}");
                    Console.WriteLine($" ** SkipWholeFoundText == {skipFoundText}");
                    Console.WriteLine($" ** Found '{searchPair.SearchText}' {positions.Count} times in the text.");
                    // Console.WriteLine($" ** Positions: {string.Join(", ", positions)}");
                }
            }

            Console.WriteLine($"\n");
        }
        Console.WriteLine($"\n\n");
    }
}
