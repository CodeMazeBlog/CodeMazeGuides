using BenchmarkDotNet.Attributes;
using System.Text.RegularExpressions;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
public class Benchmarking
{
    private const string str = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                               Nullam quis lorem nec lorem imperdiet tempus. Phasellus lorem justo,
                               consequat ut lorem sit amet, tempor feugiat lorem.
                               Proin lorem velit, aliquam vel lorem in, consequat lorem nulla.
                               Sed lorem justo, eleifend eu lorem id, consectetur lorem neque.
                               Vestibulum lorem mauris, placerat sit amet lorem nec, laoreet lorem nisi.
                               Sed nec lorem libero. Nullam lorem lorem, ullamcorper quis lorem vitae.";

    public string toFind = "Lorem";
    private Regex regex;

    [GlobalSetup]
    public void Setup()
    {
        // Compile the regex pattern into a Regex object using the Compiled option
        regex = new Regex(toFind, RegexOptions.Compiled);
    }

    [Benchmark]
    public void FindAllIndexesWithIndexOf()
    {
        SubstringSearchMethods.FindAllIndexesWithIndexOf(str, toFind);
    }

    [Benchmark]
    public void FindAllIndexesWithSubstring()
    {
        SubstringSearchMethods.FindAllIndexesWithSubstring(str, toFind);
    }

    [Benchmark]
    public void FindAllIndexesWithSplit()
    {
        SubstringSearchMethods.FindAllIndexesWithSplit(str, toFind);
    }

    [Benchmark]
    public void FindAllIndexesWithLINQ()
    {
        SubstringSearchMethods.FindAllIndexesWithLINQ(str, toFind);
    }

    [Benchmark]
    public void FindAllIndexesWithRegex()
    {
        SubstringSearchMethods.FindAllIndexesWithRegex(str, regex);
    }

    [Benchmark]
    public void FindAllIndexesWithSpan()
    {
        SubstringSearchMethods.FindAllIndexesWithSpan(str, toFind);
    }
}
