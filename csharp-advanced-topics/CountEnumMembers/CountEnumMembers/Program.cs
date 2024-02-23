using BenchmarkDotNet.Running;
using CountEnumMembers;
using CountEnumMembersBenchmark;

public class Program
{
    public static void Main()
    {
        BenchmarkRunner.Run<Benchmark>();

        var getnames = Enum.GetNames(typeof(Months));
        var getvalues = Enum.GetValues(typeof(Months));

        Console.WriteLine("The months are: ");
        Console.WriteLine("");

        foreach (var m in getvalues)
        {
            Console.WriteLine(m);
        }

        Console.WriteLine("");
        Console.WriteLine("GetValues Method");
        var values = Values(getvalues);
        Console.WriteLine($"The total number of items is : {values}");

        Console.WriteLine("");

        Console.WriteLine("GetNames Method");
        var names = Names(getnames);
        Console.WriteLine($"The total number of items is : {names}");
    }

    public static int Values(Array months)
    {
        return months.Length;
    }

    public static int Names(string[] months)
    {
        return months.Length;
    }
}