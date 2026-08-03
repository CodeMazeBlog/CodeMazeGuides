namespace InterceptorsInCSharp;

public class Program
{
    public static void Main(string[] args)
    {
        var example = new Example();

        var text = example.GetText("Hello");
        var anotherText = example.GetText("Greetings");

        Console.WriteLine(text);
        Console.WriteLine(anotherText);
    }
}