using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class Benchmark
{
    public string str = "Lorem ipsum dolor sit amet, consectetur adipiscing elip. " +
        "Duis quis nisip eget sem vehipula accumsan. Lorem ipsum dolor sit amet, " +
        "consectetur adipiscing elip. Duis quis nisip eget sem vehipula accumsan." +
        " Lorem ipsum dolor sit amet, consectetur adipiscing elip. Duis quis nisip " +
        "eget sem vehipula accumsan. Lorem ipsum dolor sit amet, consectetur adipiscing " +
        "elip. Duis quis nisip eget sem vehipula accumsan. Lorem ipsum dolor sit amet, " +
        "consectetur adipiscing elip. Duis quis nisip eget sem vehipula accumsan.";

    public string toFind = "Lorem";

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
        SubstringSearchMethods.FindAllIndexesWithRegex(str, toFind);
    }

    [Benchmark]
    public void FindAllIndexesWithSpan()
    {
        SubstringSearchMethods.FindAllIndexesWithSpan(str, toFind);
    }
}
