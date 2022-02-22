namespace IterateThroughDictionary
{
    public  class Program
    {
        public static void Main(string[]args)
        {
            var pTest = new PerformAnalysisTest();

            var monthsInYear = new Dictionary<int, string>
            {
                {1,"January" },
                {2,"February" },
                {3,"March" },
                {4,"April" }
            };

            SubDictionaryUsingForEach(monthsInYear);
            SubDictionaryKeyValuePair(monthsInYear);
            SubDictionaryForLoop(monthsInYear);
            SubDictionaryParallelEnumerable(monthsInYear);
            SubDictionaryStringJoin(monthsInYear);
            pTest.TestDictionaryLoopResult();
        }
        
        public static void SubDictionaryUsingForEach(Dictionary<int,string> monthsinyear)
        {
            foreach (var month in monthsinyear)
            {
                Console.WriteLine($"{month.Key } : {month.Value}");
            }
        }

        public static void SubDictionaryKeyValuePair(Dictionary<int,string> monthsinyear)
        {
            foreach (KeyValuePair<int,string> entry in monthsinyear)
            {
                Console.WriteLine($"{entry.Key} : {entry.Value}");
            }

            foreach (var (key,value) in monthsinyear)
            {
                Console.WriteLine($"{key} : {value}");   
            }
        }

        public static void SubDictionaryForLoop(Dictionary<int, string> monthsinyear)
        {
            for (int index = 0; index < monthsinyear.Count; index ++)
            {
                KeyValuePair<int, string> month = monthsinyear.ElementAt(index);

                Console.WriteLine($"{month.Key} : {month.Value}");
            }
        }

        public static void SubDictionaryParallelEnumerable(Dictionary<int, string> monthsinyear)
        {
            monthsinyear.AsParallel()
                        .OrderBy(month => month.Key)
                        .ForAll(month => Console.WriteLine($"{month.Key} : {month.Value}"));
                        
        }

        public static void SubDictionaryStringJoin(Dictionary<int, string> monthsinyear)
        {
            Console.WriteLine(String.Join(Environment.NewLine, monthsinyear));
        }
    }
}
