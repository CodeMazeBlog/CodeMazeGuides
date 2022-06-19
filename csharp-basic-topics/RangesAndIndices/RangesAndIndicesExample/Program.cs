namespace RangesAndIndicesExample;

internal class Program
{
    static string[] names = new string[]
    {
        "John",
        "Abdul", 
        "Abby", 
        "Abigail", 
        "Doe",
        "Jerod",
        "Adele",
        "Nader", 
        "Adam",
    };

    private static readonly NameList namelist = new()
    {
        "John",
        "Abdul",
        "Abby",
        "Abigail",
        "Doe",
        "Jerod",
        "Adele",
        "Nader",
        "Adam",
    };

    static void Main(string[] args)
    {
        RunIndexExamples();
        RunRangeExample();
        RunNameListExample();
    }

    static void RunIndexExamples() 
    {
        var name1 = IndexExamples.GetFirst(names);
        var name2 = IndexExamples.GetLastMethod1(names);
        var name3 = IndexExamples.GetLastMethod2(names);

        Console.WriteLine("\n\nIndex Example:");

        Console.WriteLine(name1);
        Console.WriteLine(name2);
        Console.WriteLine(name3);
    }

    static void RunRangeExample() 
    {
        var all = RangeExamples.GetAll(names);
        var firstTwo = RangeExamples.GetFirstTwoElements(names);
        var firstThree = RangeExamples.GetFirstThreeElements(names);
        var lastThree = RangeExamples.GetLastThreeElements(names);
        var middleThree = RangeExamples.GetThreeElementsFromMiddle(names);

        Console.WriteLine("\n\n\n\nRange Examples:");

        PrintEnumerable("All Elements:",all);
        PrintEnumerable("First Two Elements:", firstTwo);
        PrintEnumerable("First Three Elements:", firstThree);
        PrintEnumerable("Last Three Elements:", lastThree);
        PrintEnumerable("Middle Three Elements:", middleThree);
    }

    static void RunNameListExample()
    {
        var all = NameListExamples.GetAll(namelist);
        var firstTwo = NameListExamples.GetFirstTwoElements(namelist);
        var firstThree = NameListExamples.GetFirstThreeElements(namelist);
        var lastThree = NameListExamples.GetLastThreeElements(namelist);
        var middleThree = NameListExamples.GetThreeElementsFromMiddle(namelist);

        Console.WriteLine("\n\n\n\nName List Examples:");

        PrintEnumerable("All Elements:", all);
        PrintEnumerable("First Two Elements:", firstTwo);
        PrintEnumerable("First Three Elements:", firstThree);
        PrintEnumerable("Last Three Elements:", lastThree);
        PrintEnumerable("Middle Three Elements:", middleThree);
    }

    static void PrintEnumerable(string prefix, IEnumerable<string> arr)
    {
        Console.WriteLine($"\n{prefix}");
        Console.Write("\t");
        foreach (var item in arr)
        { 
            Console.Write($"{item}, ");
        }
    }
}