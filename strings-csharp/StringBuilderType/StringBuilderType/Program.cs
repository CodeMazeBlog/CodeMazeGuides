using System.Text;

namespace StringBuilderType;

class Program
{
    public static readonly StringBuilderMethods stringBuilderMethodImplementations = new StringBuilderMethods();

    static void Main(string[] args)
    {
        Program.StringBuilderTest_Append();

        Console.WriteLine("Hello, World!");

        Console.WriteLine("-------------------- Instantiating StringBuilder");
        Console.WriteLine("-------------------------------------------");

        Console.WriteLine();

        Console.WriteLine("---------- Sample Append Approach");
        PrintResponse("Append method sample: ", stringBuilderMethodImplementations.Append());

        Console.WriteLine("---------- Sample AppendLine Approach");
        PrintResponse("AppendLine method sample: ", stringBuilderMethodImplementations.AppendLine());

        Console.WriteLine("---------- Sample AppendFormat Approach");
        PrintResponse("AppendFormat method sample: ", stringBuilderMethodImplementations.AppendFormat());

        Console.WriteLine("---------- Sample Insert Approach");
        PrintResponse("Insert method sample: ", stringBuilderMethodImplementations.Insert());

        Console.WriteLine("---------- Sample Replace Approach");
        PrintResponse("Replace method sample: ", stringBuilderMethodImplementations.Replace());

        Console.WriteLine("---------- Sample Remove Approach");
        PrintResponse("Remove method sample: ", stringBuilderMethodImplementations.Remove());

        Console.WriteLine("---------- Sample Clear Approach");
        PrintResponse("Clear method sample: ", stringBuilderMethodImplementations.Clear());

        Console.WriteLine("-------------------------------------------");

        var sb = new StringBuilder("1234");
        var sampleLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToArray();

        for (int i = 0; i < 20; i++)
        {
            sb.Insert(i, sampleLetters[i].ToString());
        }

        Console.ReadLine();
    }

    public static void StringBuilderTest_Append()
    {
        var arguments = new List<string>()
            {
                "Welcome to our channel_",
                "Hoping you will learn a thing or two_",
                "bye for now_"
            };

        foreach (var arg in arguments)
        {
            var str = stringBuilderMethodImplementations.Append(arg);
            str.Replace('_', '.');
            str.Insert(0, "String: ");
        }
    }

    public static void PrintResponse(string Method, StringBuilder Result)
    {
        Console.WriteLine($"{Method} {stringBuilderMethodImplementations.ConvertToString(Result)}");

        Console.WriteLine();
    }

    public static void PrintResponse(string Method, int Result)
    {
        Console.WriteLine($"{Method} {Result}");

        Console.WriteLine();
    }
}