namespace HashSetInCSharp
{
    public class HashSetsInCSharpMethods
    {
        public HashSet<string> ProgrammingLanguages() 
        {
            var languages = new HashSet<string>();

            languages.Add("C");
            languages.Add("C++");
            languages.Add("C#");
            languages.Add("Java");
            languages.Add("Scala");
            languages.Add("TypeScript");
            languages.Add("Python");
            languages.Add("JavaScript");
            languages.Add("Rust");

            return languages;
        }

        public HashSet<string> RemoveElement(HashSet<string> hashSet, string value) 
        {
            hashSet.Remove(value);

            return hashSet;
        }

        public HashSet<int> RemoveWhereElement(HashSet<int> hashSet)
        {
            hashSet.RemoveWhere(IsOdd);

            return hashSet;
        }

        public List<int> CreateList(HashSet<int> hashSet)
        {
            var list = new List<int>();

            foreach (var item in hashSet) 
            {
                list.Add(item);
            }

            return list;
        }

        public HashSet<string> CreateFromList(List<string> languageList)
        {
            var fromList = languageList.ToHashSet();

            return fromList;
        }

        public HashSet<string> CreateCaseInsensitive(List<string> languageList)
        {
            var caseInsensitive = new HashSet<string>(languageList, StringComparer.OrdinalIgnoreCase);

            return caseInsensitive;
        }

        public HashSet<int> RandomInts(int size, int seed = 42)
        {
            var rand = new Random(seed);
            var numbers = new HashSet<int>();

            for (int i = 0; i < size; i++) 
            {
                numbers.Add(rand.Next());
            }

            return numbers;
        }

        public bool IsOdd(int num) 
        {
            return num % 2 != 0;
        }
    }
}
