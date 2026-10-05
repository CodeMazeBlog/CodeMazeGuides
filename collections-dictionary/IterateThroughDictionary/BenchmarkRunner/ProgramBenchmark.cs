using BenchmarkDotNet.Running;

namespace Benchmark;

public class ProgramBenchmark
{
	static void Main(string[] args)
	{
		BenchmarkRunner.Run(typeof(ProgramBenchmark).Assembly, args: args);
	}
}
