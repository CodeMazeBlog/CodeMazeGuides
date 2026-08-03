
namespace Lucene.NetBasicExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SearchEngine.GetData();
            Console.WriteLine("Beginning Index");
            SearchEngine.Index();
            Console.WriteLine("Completed Index");
            Console.WriteLine("Beginning Index Update");
            SearchEngine.AddToIndex();
            SearchEngine.ChangeInIndex();
            SearchEngine.DeleteFromIndex();
            Console.WriteLine("Completed Index Update");
            var run = true;
            while (run)
            {
                Console.WriteLine($"{Environment.NewLine} Enter Search Criteria or Just Press Enter to End Program:");
                run = RunSearch();
            }
        }

        private static bool RunSearch()
        {
            var input = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(input))
            {
                SearchEngine.Dispose();
                return false;
            }

            foreach (var s in SearchEngine.Search(input))
            {
                Console.WriteLine(s);
            }

            return true;
        }
    }
}