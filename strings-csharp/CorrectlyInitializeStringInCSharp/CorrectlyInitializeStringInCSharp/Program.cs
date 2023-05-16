using CorrectlyInitializeStringInCSharp;
class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(StringExamples.MyString1());
        Console.WriteLine(StringExamples.MyString2());
        Console.WriteLine(StringExamples.FullName("John", "Doe"));
        Console.WriteLine(StringExamples.Path());
        Console.WriteLine(StringExamples.MultiLineString());
        Console.WriteLine(StringExamples.EmptyString());
        Console.WriteLine(StringExamples.NullString());
        Console.WriteLine(StringExamples.StringBuilderString());
        Console.WriteLine(StringExamples.SumString(5, 10));
        Console.WriteLine(StringExamples.StringBuilderClear());
        Console.WriteLine(StringExamples.StringBuilderInsert());
        Console.WriteLine(StringExamples.StringBuilderReplace());
        Console.WriteLine(StringExamples.AsteriskString(10));
    }
}