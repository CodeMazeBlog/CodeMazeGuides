using BenchmarkDotNet.Running;
using ConvertStringToSpan;
class Program
{
    static void Main(string[] args)
    {
        var stringExample = new StringExample();       

        var span1 = stringExample.ConvertStringToSpanUsingToCharArray();
        Console.WriteLine(span1.ToString());

        var span2 = stringExample.ConvertStringToSpanUsingUnsafe();
        Console.WriteLine(span2.ToString());

        var span3 = stringExample.ConvertStringToSpanUsingAsSpan();
        Console.WriteLine(span3.ToString());

        var span4 = stringExample.ConvertStringToReadOnlySpanUsingAsSpan();
        Console.WriteLine(span4.ToString());

        var span5 = stringExample.ConvertStringToSpan();
        Console.WriteLine(span5.ToString());

        var summary = BenchmarkRunner.Run<StringExample>();    
    }
}