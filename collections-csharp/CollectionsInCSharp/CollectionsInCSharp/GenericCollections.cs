namespace CollectionsInCSharp
{
    public class GenericCollections
    {
        public static List<string> CreateCountries()
        {
            List<string> countries = new();
            countries.Add("Jamaica");
            countries.Add("Switzerland");
            countries.Add("Mexico");
            countries.Add("Malaysia");
            countries.Add("Russia");
            
            return countries;
        }
        
        public static List<string> RemoveFromCountries(List<string> countries)
        {
            countries.Remove("Mexico");
            countries.RemoveAt(3);
            countries.RemoveAll(x => x.EndsWith('a'));
            
            return countries;
        }
        
        public static SortedList<string, string> CreateCountriesAndCapitals()
        {
            SortedList<string, string> countriesAndCapitals = new();
            countriesAndCapitals.Add("Jamaica", "Kingston");
            countriesAndCapitals.Add("Switzerland", "Zurich");
            countriesAndCapitals.Add("Malaysia", "Kuala Lumpur");
            countriesAndCapitals.Add("Russia", "Moscow");
            countriesAndCapitals.TryAdd("Jamaica", "Kingston");

            return countriesAndCapitals;
        }
        
        public static List<string> ReadFromCountriesAndCapitals(SortedList<string, string> countriesAndCapitals)
        {
            var capitals = new List<string>
            {
                countriesAndCapitals.Values[0],
                countriesAndCapitals.Values[1]
            };
            if (countriesAndCapitals.TryGetValue("Russia", out string? value))
            {
                capitals.Add(value);
            }

            return capitals;
        }
        
        public static Dictionary<int, string> CreateCountriesWithRank()
        {
            Dictionary<int, string> countriesWithRank = new();
            countriesWithRank.Add(1, "Jamaica");
            countriesWithRank.Add(2, "Netherlands");
            countriesWithRank.Add(3, "Congo");
            countriesWithRank.TryAdd(4, "England");
            countriesWithRank.TryAdd(5, "India");
            countriesWithRank.TryAdd(5, "India");

            return countriesWithRank;
        }

        public static List<string> ReadFromCountriesWithRank(Dictionary<int, string> countriesWithRank)
        {
            var rankedNations = new List<string>
            {
                countriesWithRank.First().Value,
                countriesWithRank[2],
                countriesWithRank[3]
            };
            if (countriesWithRank.TryGetValue(4, out string? country))
            {
                rankedNations.Add(country);
            }

            return rankedNations;
        }
        
        public static SortedSet<int> CreateNumbersSortedSet()
        {
        SortedSet<int> numbersSortedSet = new();

            numbersSortedSet.Add(3);
            numbersSortedSet.Add(2);
            numbersSortedSet.Add(1);
            numbersSortedSet.Add(3);

            return numbersSortedSet;
        }

        public static List<int> ReadFromNumbersSortedSet(SortedSet<int> numbersSortedSet)
        {
            var sortedNumbersList = new List<int>();
            foreach(var num in numbersSortedSet)
            {
                sortedNumbersList.Add(num);
            }

            return sortedNumbersList;
        }

        public static HashSet<int> CreateNumbersHashSet()
        {
            HashSet<int> numbersHashSet = new();
            numbersHashSet.Add(1);
            numbersHashSet.Add(2);
            numbersHashSet.Add(3);
            numbersHashSet.Add(3);
            
            return numbersHashSet;
        }

        public static List<int> ReadFromNumbersHashSet(HashSet<int> numbersHashSet)
        {
            var numbersList = new List<int>();
            foreach (var num in numbersHashSet)
            {
                numbersList.Add(num);
            }

            return numbersList;
        }

        public static Queue<int> CreateNumbersQueue()
        {
            Queue<int> numbersQueue = new();
            numbersQueue.Enqueue(1);
            numbersQueue.Enqueue(2);
            numbersQueue.Enqueue(3);
            
            return numbersQueue;
        }

        public static int ReadFromNumbersQueue(Queue<int> numbersQueue)
        {
            var number = numbersQueue.Dequeue();
            
            return number;
        }

        public static Stack<string> CreateWordsStack()
        {
            Stack<string> wordsStack = new();
            wordsStack.Push("First");
            wordsStack.Push("Second");
            wordsStack.Push("Third");

            return wordsStack;
        }

        public static string ReadFromWordsStack(Stack<string> wordsStack)
        {
            var word = wordsStack.Pop();

            return word;
        }
    }
}