using BenchmarkDotNet.Running;
using CountEnumMembers;
using CountEnumMembersBenchmark;

public class Program
{
    public static void Main()
    {
        BenchmarkRunner.Run<Benchmark>();

        var getnames = Enum.GetNames(typeof(Months)).Length;
        var getvalues = Enum.GetValues(typeof(Months)).Length;

        Console.WriteLine("Using GetNames: " + getnames);
        Console.WriteLine("Using GetValues: " + getvalues);
    }
}