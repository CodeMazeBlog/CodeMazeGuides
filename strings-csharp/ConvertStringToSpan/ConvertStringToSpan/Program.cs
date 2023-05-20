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

        var span4 = StringExample.ConvertStringToReadOnlySpanUsingAsSpan(myString);
        Console.WriteLine(span4.ToString());

        var span5 = StringExample.ConvertStringToSpan(myString);
        Console.WriteLine(span5.ToString());
    }
}