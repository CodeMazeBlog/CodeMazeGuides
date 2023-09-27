namespace MergingDictionariesInCSharp
{
    public partial class Methods
    {
        public static void PrintDictionary(Dictionary<int, string> dictionary)
        {
            foreach (var kvp in dictionary)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }
        }
    }
}