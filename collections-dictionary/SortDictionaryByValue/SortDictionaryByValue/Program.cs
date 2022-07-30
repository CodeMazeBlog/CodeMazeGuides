namespace SortDictionaryByValue;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("SortDictionaryValueUsingLinqOrderBy:");

        var dictionary = new Dictionary<string, string>
        {
            { "1", "apple" },
            { "2", "orange" },
            { "3", "banana" },
            { "4", "grape" }
        };

        var sortedDictionary1 = SortDictionary.SortDictionaryValueUsingLinqOrderBy(dictionary);

        foreach (var item in sortedDictionary1)
        {
            Console.WriteLine(item.Key + " " + item.Value);
        }

        Console.WriteLine("SortDictionaryValueUsingLinqQueryExpression:");

        var sortedDictionary2 = SortDictionary.SortDictionaryValueUsingLinqQueryExpression(dictionary);

        foreach (var item in sortedDictionary2)
        {
            Console.WriteLine(item.Key + " " + item.Value);
        }

        Console.WriteLine("SortDictionaryValueUsingSortMethod:");

        var sortedDictionary3 = SortDictionary.SortDictionaryValueUsingSortMethod(dictionary);

        foreach (var item in sortedDictionary3)
        {
            Console.WriteLine(item.Key + " " + item.Value);
        }
    }
}