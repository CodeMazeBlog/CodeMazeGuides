using BenchmarkDotNet.Running;

namespace Benchmark
{
	public class ProgramBenchmark
	{
		static void Main(string[] args)
		{
			BenchmarkRunner.Run<DictionaryIterateBenchmark>();

			//var bla = new DictionaryIterateBenchmark();
			//bla.WhenDictionaryUsingForLoop();
			//bla.WhenDictionaryUsingForEach();
			//bla.WhenDictionaryParallelEnumerable();
		}
	}
}
