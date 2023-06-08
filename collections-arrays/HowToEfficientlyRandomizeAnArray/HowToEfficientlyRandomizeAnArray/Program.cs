namespace HowToEfficientlyRandomizeAnArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var array = ArrayFunctions.GerOrderedArray(100);
            array.OrderBy(x => x);
        }
    }
}