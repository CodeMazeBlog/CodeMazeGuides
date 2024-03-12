using BenchmarkDotNet.Running;
using CountEnumMembers;
using CountEnumMembersBenchmark;

public class Program
{
    public static void Main()
    {
        BenchmarkRunner.Run<Benchmark>();

        var names = Enum.GetNames<Months>();
        var values = Enum.GetValues<Seasons>();
        var getnames = Enum.GetNames<Months>().Length;
        var getvalues = Enum.GetValues<Months>().Length;
        var distinct_values = Enum.GetValues(typeof(Seasons)).Cast<Seasons>().Distinct().Count();

        Console.WriteLine("Names array: ");

        foreach (var n in names)
        {
            Console.WriteLine(n);
        }

        Console.WriteLine("");
        Console.WriteLine("Values array:");

        foreach (var v in values)
        {
            Console.WriteLine(v);
        }        

        Console.WriteLine("");
        Console.WriteLine("Total items by GetNames: " + getnames);
        Console.WriteLine("Total items by GetValues: " + getvalues);
        Console.WriteLine("Total number of distinct values: " + distinct_values);
    }
}