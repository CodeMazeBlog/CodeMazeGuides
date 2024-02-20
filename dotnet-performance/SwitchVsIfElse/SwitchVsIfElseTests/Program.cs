using BenchmarkDotNet.Running;

namespace SwitchVsIfElseTests;

public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<SwitchVsIfElseBenchmarkTests>();
    }
}