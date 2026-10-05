namespace IterateThroughDictionary;

public class Program
{
	public static void Main(string[] args)
	{
		var monthsInYear = new Dictionary<int, string>
		{
			{1, "January" },
			{2, "February" },
			{3, "March" },
			{4, "April" }
		};

		SubDictionaryUsingForEach(monthsInYear);
		SubDictionaryKeyValuePair(monthsInYear);
		SubDictionaryUsingKeys(monthsInYear);
		SubDictionaryUsingValues(monthsInYear);
		SubDictionaryForLoop(monthsInYear);
		SubDictionaryParallelEnumerable(monthsInYear);
		SubDictionaryRemoveWhileIterating(monthsInYear);
	}

	public static void SubDictionaryUsingForEach(Dictionary<int, string> monthsInYear)
	{
		foreach (var month in monthsInYear)
		{
			Console.WriteLine($"{month.Key} : {month.Value}");
		}
	}

	public static void SubDictionaryKeyValuePair(Dictionary<int, string> monthsInYear)
	{
		foreach (KeyValuePair<int, string> entry in monthsInYear)
		{
			Console.WriteLine($"{entry.Key} : {entry.Value}");
		}

		foreach (var (key, value) in monthsInYear)
		{
			Console.WriteLine($"{key} : {value}");
		}
	}

	public static void SubDictionaryUsingKeys(Dictionary<int, string> monthsInYear)
	{
		foreach (var monthNumber in monthsInYear.Keys)
		{
			Console.WriteLine(monthNumber);
		}
	}

	public static void SubDictionaryUsingValues(Dictionary<int, string> monthsInYear)
	{
		foreach (var monthName in monthsInYear.Values)
		{
			Console.WriteLine(monthName);
		}
	}

	public static void SubDictionaryRemoveWhileIterating(Dictionary<int, string> monthsInYear)
	{
		foreach (var (monthNumber, monthName) in monthsInYear)
		{
			if (monthName.StartsWith('J'))
			{
				monthsInYear.Remove(monthNumber);
			}
		}
	}

	public static void SubDictionaryForLoop(Dictionary<int, string> monthsInYear)
	{
		for (int index = 0; index < monthsInYear.Count; index++)
		{
			KeyValuePair<int, string> month = monthsInYear.ElementAt(index);

			Console.WriteLine($"{month.Key} : {month.Value}");
		}
	}

	public static void SubDictionaryParallelEnumerable(Dictionary<int, string> monthsInYear)
	{
		monthsInYear.AsParallel()
					.ForAll(month => Console.WriteLine($"{month.Key} : {month.Value}"));
	}
}
