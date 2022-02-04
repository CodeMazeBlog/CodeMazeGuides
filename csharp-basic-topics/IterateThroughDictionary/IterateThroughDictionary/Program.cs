namespace IterateThroughDictionary
{
    public  class Program
    {
        public static void Main(string[]args)
        {
            Dictionary<int, string> MonthsInYear = new Dictionary<int, string>
            {
                {1,"January" },
                {2,"February" },
                {3,"March" },
                {4,"April" }
            };

            SubDictionaryUsingForEach(MonthsInYear);
            SubDictionaryKeyValuePair(MonthsInYear);
            SubDictionaryForLoop(MonthsInYear);
            SubDictionaryParallelEnumerable(MonthsInYear);
            SubDictionaryStringJoin(MonthsInYear);

        }
        public static void SubDictionaryUsingForEach(Dictionary<int,string> MonthsInYear)
        {
            foreach (var month in MonthsInYear)
            {
                Console.WriteLine(month.Key + ":" + month.Value);
            }
        }

        public static void SubDictionaryKeyValuePair(Dictionary<int,string> MonthsInYear)
        {
            foreach (KeyValuePair<int,string> entry in MonthsInYear)
            {
                Console.WriteLine(entry.Key + ":" + entry.Value);
            }

            foreach (var (key,value) in MonthsInYear)
            {
                Console.WriteLine(key + ":" + value);   
            }
        }

        public static void SubDictionaryForLoop(Dictionary<int, string> MonthsInYear)
        {
            for (int index = 0; index < MonthsInYear.Count; index ++)
            {
                KeyValuePair<int, string> month = MonthsInYear.ElementAt(index);

                Console.WriteLine(month.Key + ":" + month.Value);
            }
        }

        public static void SubDictionaryParallelEnumerable(Dictionary<int, string> MonthsInYear)
        {
            MonthsInYear.AsParallel()
                        .ForAll(month => Console.WriteLine(month.Key + ":" + month.Value));
        }

        public static void SubDictionaryStringJoin(Dictionary<int, string> MonthsInYear)
        {
            Console.WriteLine(String.Join(Environment.NewLine, MonthsInYear));
        }
    }
}
