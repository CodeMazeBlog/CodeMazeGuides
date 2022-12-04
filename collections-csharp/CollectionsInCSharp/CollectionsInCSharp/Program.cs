namespace CollectionsInCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myColl = ConcurrentCollections.CreateConcurrentNumbersQueue();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(ConcurrentCollections.ReadFromConcurrentNumbersQueue(myColl));
            }
        }
    }
}