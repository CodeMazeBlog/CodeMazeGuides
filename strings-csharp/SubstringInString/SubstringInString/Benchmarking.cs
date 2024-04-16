using BenchmarkDotNet.Attributes;
using System.Text.RegularExpressions;

[Config(typeof(AntiVirusFriendlyConfig))]
[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
public class Benchmarking
{
    const string input = """
                          Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                          Nullam quis lorem nec lorem imperdiet tempus. Phasellus lorem justo,
                          consequat ut lorem sit amet, tempor feugiat lorem.
                          Proin lorem velit, aliquam vel lorem in, consequat lorem nulla.
                          Sed lorem justo, eleifend eu lorem id, consectetur lorem neque.
                          Vestibulum lorem mauris, placerat sit amet lorem nec, laoreet lorem nisi.
                          Sed nec lorem libero. Nullam lorem lorem, ullamcorper quis lorem vitae.
                          """;

    const string toFind = "Lorem";
    Regex regex;    

    [GlobalSetup]
    public void Setup()
    {
        regex = new Regex(toFind, RegexOptions.Compiled);
    }

    [Benchmark]
    public void FindAllIndexesWithIndexOf()
    {
        SubstringSearchMethods.FindAllIndexesWithIndexOf(input, toFind);
    }

    [Benchmark]
    public void FindAllIndexesWithSubstring()
    {
        SubstringSearchMethods.FindAllIndexesWithSubstring(input, toFind);
    }

    [Benchmark]
    public void FindAllIndexesWithSplit()
    {
        SubstringSearchMethods.FindAllIndexesWithSplit(input, toFind);
    }

    [Benchmark]
    public void FindAllIndexesWithLINQ()
    {
        SubstringSearchMethods.FindAllIndexesWithLINQ(input, toFind);
    }

    [Benchmark]
    public void FindAllIndexesWithRegex()
    {
        SubstringSearchMethods.FindAllIndexesWithRegex(input, regex);
    }

    [Benchmark]
    public void FindAllIndexesWithSpan()
    {
        SubstringSearchMethods.FindAllIndexesWithSpan(input, toFind);
    }
}
