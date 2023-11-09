namespace IterateThroughDictionary
{
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
			SubDictionaryForLoop(monthsInYear);
			SubDictionaryParallelEnumerable(monthsInYear);
		}

		public static void SubDictionaryUsingForEach(Dictionary<int, string> monthsInYear)
		{
			foreach (var month in monthsInYear)
			{
				Console.WriteLine($"{month.Key } : {month.Value}");
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
}
