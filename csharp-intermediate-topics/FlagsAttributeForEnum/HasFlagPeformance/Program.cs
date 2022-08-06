using BenchmarkDotNet.Running;
using System;

namespace HasFlagPeformance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<HasFlagBenchmarker>();
        }
    }
}
