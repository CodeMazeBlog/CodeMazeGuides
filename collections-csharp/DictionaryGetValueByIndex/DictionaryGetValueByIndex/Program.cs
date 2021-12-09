
using System.Text;

namespace DictionaryGetValueByIndex
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var capitals = new Dictionary<string, string>()
            {
                {"Turkey", "Ankara"},
                {"UK", "London"},
                {"USA", "Washington"}                
            };

            var element = capitals.ElementAt(2);

            Console.WriteLine(element);

            Console.WriteLine($"Just Key: {capitals.ElementAt(2).Key}");

            Console.WriteLine($"Just Value: {capitals.ElementAt(2).Value}");

            Console.WriteLine($"This is indexer access of UK capital: {capitals["UK"]}");

            Console.ReadLine();
        }
    }
}