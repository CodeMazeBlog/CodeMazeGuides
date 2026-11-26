using BenchmarkDotNet.Running;
using BitArray_in_CSharp;

if (args is ["--bench", .. var benchmarkArgs])
{
    BenchmarkSwitcher.FromAssembly(typeof(BitArrayBenchmark).Assembly).Run(benchmarkArgs);
}
else
{
    Examples.Run();
}
