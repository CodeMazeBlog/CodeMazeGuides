namespace FindTheMaximumValue
{
    public class Program
    {
        private static readonly int[] sourceArray = new int[] { 3, 7, 23, 40, 37, 9, 19 };
        private static readonly ElementFinder elementFinder = new();
        public static int OutputResult = 0;

        public static void Main(string[] args)
        {
            Console.WriteLine("-------------------- Finding the Largest Element");
            Console.WriteLine("------------------------------------------------");

            Console.WriteLine();

            Console.WriteLine("---------- Using Enumerable.Max");
            Console.WriteLine($"   - Value: {elementFinder.GetLargestElementUsingMax(sourceArray)}");

            Console.WriteLine();

            Console.WriteLine("---------- Using OrderByDescending");
            Console.WriteLine($"   - Value: {elementFinder.GetLargestElementUsingOrderByDescending(sourceArray)}");
            
            Console.WriteLine();

            Console.WriteLine("---------- Using Enumerable.MaxBy");
            Console.WriteLine($"   - Value: {elementFinder.GetLargestElementUsingMaxBy(sourceArray)}");

            Console.WriteLine();

            Console.WriteLine("---------- Manually");
            Console.WriteLine($"   - Value: {elementFinder.GetLargestElementUsingFor(sourceArray)}");

            OutputResult = 1;
        }
    }
}