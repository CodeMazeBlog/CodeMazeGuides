using BenchmarkDotNet.Attributes;

namespace Benchmark;

public class DictionaryConcatenateBenchmark
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
	public string WhenDictionaryUsingForEach(Dictionary<int, string> dictionaryData, string numberOfItems)
	{
		var result = string.Empty;

		foreach (var testValue in dictionaryData)
		{
			result += testValue.Value;
		}

		return result;
	}

	[Benchmark]
	[ArgumentsSource(nameof(SampleData))]
	public string WhenDictionaryUsingForLoop(Dictionary<int, string> dictionaryData, string numberOfItems)
	{
		var result = string.Empty;

		for (int i = 0; i < dictionaryData.Count; i++)
		{
			var item = dictionaryData.ElementAt(i);
			result += item.Value;
		}

		return result;
	}

	[Benchmark]
	[ArgumentsSource(nameof(SampleData))]
	public string WhenDictionaryParallelEnumerable(Dictionary<int, string> dictionaryData, string numberOfItems)
	{
		using var partialResults = new ThreadLocal<string>(() => string.Empty, trackAllValues: true);

		dictionaryData.AsParallel().ForAll(testValue => partialResults.Value += testValue.Value);

		return string.Concat(partialResults.Values);
	}
}
