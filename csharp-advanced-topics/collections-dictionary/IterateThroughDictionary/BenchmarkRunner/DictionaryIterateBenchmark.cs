using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Benchmark
{
	public class DictionaryIterateBenchmark
	{
		private Dictionary<int, string> FillData(int count)
		{
			var testValues = new Dictionary<int, string>();

			for (int i = 0; i < count; i++)
			{
				testValues.Add(i, "value-" + i);
			}

			return testValues;
		}

		public IEnumerable<object[]> SampleData()
		{
			yield return new object[] { FillData(100), "100" };
			yield return new object[] { FillData(1000), "1000" };
			yield return new object[] { FillData(10000), "10000" };
		}

		[Benchmark]
		[ArgumentsSource(nameof(SampleData))]
		public void WhenDictionaryUsingForEach(Dictionary<int, string> dictionaryData, string numberOfItems)
		{
			foreach (var testValue in dictionaryData)
			{
				var result = testValue.Value;
			}
		}

		[Benchmark]
		[ArgumentsSource(nameof(SampleData))]
		public void WhenDictionaryUsingForLoop(Dictionary<int, string> dictionaryData, string numberOfItems)
		{
			for (int i = 0; i < dictionaryData.Count; i++)
			{
				var item = dictionaryData.ElementAt(i);
				var result = item.Value;
			}
		}

		[Benchmark]
		[ArgumentsSource(nameof(SampleData))]
		public void WhenDictionaryParallelEnumerable(Dictionary<int, string> dictionaryData, string numberOfItems)
		{
			var result = string.Empty;

			dictionaryData.AsParallel().ForAll(testValue => result = testValue.Value);
		}
	}
}
