using ConvertStringToSpan;
class Program
{
    static void Main(string[] args)
    {
        var myString = "Hello, World!";

        var span1 = StringExample.ConvertStringToSpanUsingMemoryMarshal(myString);
        Console.WriteLine(span1.ToString());

        var span2 = StringExample.ConvertStringToSpanUsingUnsafe(myString);
        Console.WriteLine(span2.ToString());

        var span3 = StringExample.ConvertStringToSpanUsingAsSpan(myString);
        Console.WriteLine(span3.ToString());
    }
}


