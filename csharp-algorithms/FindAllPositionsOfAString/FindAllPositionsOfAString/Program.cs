using BenchmarkDotNet.Running;
using FindAllPositionsOfAString.Algorithms;
using FindAllPositionsOfAString.Algorithms.Interfaces;
using FindAllPositionsOfAString.Benchmarks;
using FindAllPositionsOfAString.Samples;

var benchmark = args.Length >= 1;

if (benchmark)
{
    if (args[0] == "regex")
        _ = BenchmarkRunner.Run<RegExSearcherBenchmarks>();
    else
        _ = BenchmarkRunner.Run<SearcherBenchmarks>();
}
else
{

    foreach (SearchPair searchPair in SearchingSamples.SampleForProgram())
    {
        foreach (bool caseSensitivity in new bool[] { true, false })
        {
            foreach (bool skipFoundText in new bool[] { true, false })
            {
                var searchers = new ISearcher[]
                {
                        new SearchUsingIndexOf(searchPair.SearchText, skipFoundText, caseSensitivity),
                        new SearchUsingRegexWithMatch(searchPair.SearchText, skipFoundText, caseSensitivity),
                        new SearchUsingRegexWithMatches(searchPair.SearchText, skipFoundText, caseSensitivity),
                        new SearchUsingBruteForceAlgorithm(searchPair.SearchText, skipFoundText, caseSensitivity),
                        new SearchUsingKMPAlgorithm(searchPair.SearchText, skipFoundText, caseSensitivity),
                };

                foreach (ISearcher searcher in searchers)
                {
                    if ((searcher is SearchUsingRegexWithMatches) && (!skipFoundText))
                        continue;

                    if ((searcher is SearchUsingKMPAlgorithm) && (skipFoundText))
                        continue;

                    List<int> positions = searcher.FindAll(searchPair.Text);

                    Console.WriteLine($"Using {searcher.GetType().Name}");
                    Console.WriteLine($" ** CaseSensitivity == {caseSensitivity}");
                    Console.WriteLine($" ** SkipWholeFoundText == {skipFoundText}");
                    Console.WriteLine($" ** Found '{searchPair.SearchText}' {positions.Count} times in the text.");
                }
            }

            Console.WriteLine($"\n");
        }
        Console.WriteLine($"\n\n");
    }
}
